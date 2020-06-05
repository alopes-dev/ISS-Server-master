using ISS.GraphQL.Identity;
using ISS.Application.Extensions;
using ISS.Application.Models;
using ISS.Application.Services;
using ISS.Application.Services.Email;
using ISS.Application.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ISS.GraphQL.Repository
{
    /// <summary>
    // Lidar com as questões de gerenciamento de usuários.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        #region Private Members
        private readonly IEmailService _emailService;
        private readonly IQRCoder _coder;
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _scopeFactory;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor Padrão.
        /// </summary>
        public UsuarioRepository(IServiceScopeFactory scopeFactory,
                                 IEmailService emailService,
                                 IQRCoder coder,
                                 IConfiguration configuration)
        {
            _scopeFactory = scopeFactory;
            _emailService = emailService;
            _coder = coder;
            _configuration = configuration;
        }
        #endregion

        #region Interface Implementations
        /// <summary>
        /// Criar um novo usuário.
        /// <param name="usuario">Model contendo informações do novo usuário a ser adicionado.</param>
        /// </summary>
        public async Task<RepoResponse<Usuario>> AddUsuarioAsync(Usuario usuario)
        {
            IdentityResult result = await _scopeFactory.ExecuteInScopeAsync(async (provider) =>
            {
                var _userManager = provider.GetService<UserManager<Usuario>>();

                // Tentativa de criação de um novo usuário.
                // TODO: Resolver questão da password.
                return await _userManager.CreateAsync(usuario, "@@Snir.!23");
            });

            // Verificar se a tentativa de criação foi bem sucedida.
            if (!result.Succeeded)
                return new RepoResponse<Usuario> { Errors = result.Errors.Select(x => x.Description).ToList() };


            return new RepoResponse<Usuario> { Data = usuario };
        }

        /// <summary>
        /// Buscar por todos os usuários até ao momento cadastrados.
        /// </summary>
        public async Task<RepoResponse<IEnumerable<Usuario>>> GetAllUsuarioAsync()
        {
            return await _scopeFactory.ExecuteInScopeAsync(async (provider) =>
            {
                var _userManager = provider.GetService<UserManager<Usuario>>();

                return new RepoResponse<IEnumerable<Usuario>> { Data = await _userManager.Users.ToListAsync() };
            });
        }

        /// <summary>
        /// Logar um determinado usuário e fornecer o token de acesso
        /// aos recursos restritos.
        /// <param name="credenciais">Objecto contendo informações necessárias para a execução de login.</param>
        /// </summary>
        public async Task<RepoResponse<LoginResultViewModel>> LoginAsync(LoginViewModel loginCredenciais)
        {
            // TODO: Adicionar Model Validation
            bool isEmail = loginCredenciais.NomeUsuarioOuEmail.Contains("@");

            var usuario = await _scopeFactory.ExecuteInScopeAsync(async provider =>
            {
                var userManager = provider.GetService<UserManager<Usuario>>();
                return isEmail ? await userManager.FindByEmailAsync(loginCredenciais.NomeUsuarioOuEmail) :
                        await userManager.FindByNameAsync(loginCredenciais.NomeUsuarioOuEmail);
            });

            // Verificar se o usuário existe. Caso não retorne um erro como resposta.
            if (usuario == null)
                return new RepoResponse<LoginResultViewModel> { Errors = new List<string>(new[] { "Email/Username ou password incorreta." }) };

            var result = await _scopeFactory.ExecuteInScopeAsync(async provider =>
            {
                var signInManager = provider.GetService<SignInManager<Usuario>>();
                return await signInManager.PasswordSignInAsync(usuario, loginCredenciais.Senha, loginCredenciais.LembrarDeMim, false);
            });

            // Caso o password não for válida retorne um erro como resposta.
            if (!result.Succeeded)
                return new RepoResponse<LoginResultViewModel> { Errors = new List<string>(new[] { "Email/Username ou password incorreta." }) };

            return new RepoResponse<LoginResultViewModel>
            {
                Data = new LoginResultViewModel
                {
                    IdUsuario = usuario.Id,
                    NomeUsuarioOuEmail = loginCredenciais.NomeUsuarioOuEmail,
                    LembrarDeMim = loginCredenciais.LembrarDeMim,
                    Token = usuario.GenerateToken(_configuration)
                }
            };
        }

        /// <summary>
        /// Registrar um usuário, bem como logar o mesmo ao sistema, retornando
        /// o token necessário para acesso aos recursos restritos do sistema.
        /// <param name="registerCredentials">Objecto contendo informações necessárias a execução do registro.</param>
        /// </summary>
        public async Task<RepoResponse<RegisterResultViewModel>> RegisterAsync(RegisterViewModel registerCredentials)
        {
            // TODO: Adicionar Model Validation...
            var usuario = new Usuario { Email = registerCredentials.Email, UserName = registerCredentials.Username };
            var identityResult = await _scopeFactory.ExecuteInScopeAsync(async provider =>
           {
               var userManager = provider.GetService<UserManager<Usuario>>();
               var result = await userManager.CreateAsync(usuario, registerCredentials.Password);

               return result;
           });

            if (!identityResult.Succeeded)
                return new RepoResponse<RegisterResultViewModel> { Errors = identityResult.Errors.Select(x => x.Description).ToList() };

//             var code = await _scopeFactory.ExecuteInScopeAsync(async provider =>
//             {
//                 var userManager = provider.GetService<UserManager<Usuario>>();
//                 return await userManager.GenerateEmailConfirmationTokenAsync(usuario);
//             });

//             // TODO: Enviar o token de confirmação ao usuário...
//             var host = string.Empty;
// #if !DEBUG
//             host = "172.16.10.59";
// #else
//             host = "localhost:1214";
// #endif
//             string confirmationUrl = $"http://{host}/api/verify/email/{usuario.Id}/{HttpUtility.UrlEncode(code)}";

//             await _emailService.SendAsync(new EmailViewModel { Assunto = "Teste autenticação", Destinatario = usuario.Email, Conteudo = $"{confirmationUrl}" });

            return new RepoResponse<RegisterResultViewModel>
            {
                Data = new RegisterResultViewModel
                {
                    IdUsuario = usuario.Id,
                    Email = registerCredentials.Email,
                    Username = registerCredentials.Username,
                    Token = usuario.GenerateToken(_configuration)
                }
            };
        }

        /// <summary>
        /// Bloquear o acesso aos recursos fornecidos pelo sistema a uma determinado usuário.
        /// <param name="id">Identificador do usuário a ser bloquedo.</param>
        /// </summary>
        public Task<bool> Bloquear(string id)
        {
            // TODO: Implemetar o metódo para bloqueio.
            throw new System.NotImplementedException();
        }
        #endregion
    }
}