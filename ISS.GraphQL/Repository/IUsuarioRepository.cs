using ISS.Application.Models;
using ISS.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ISS.GraphQL.Repository
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Adicionar um novo usuário contendo apenas as informações
        /// essenciais e com uma senha padrão definida.
        /// <param name="usuario"></param>
        /// </summary>
        Task<RepoResponse<Usuario>> AddUsuarioAsync(Usuario usuario);

        /// <summary>
        /// Buscar pelas informações contidas sobre os usuários.
        /// </summary>
        Task<RepoResponse<IEnumerable<Usuario>>> GetAllUsuarioAsync();

        /// <summary>
        /// Logar um determinado usuário e fornecer o token de acesso
        /// aos recursos restritos.
        /// <param name="credenciais">Objecto contendo informações necessárias para a execução de login.</param>
        /// </summary>
        Task<RepoResponse<LoginResultViewModel>> LoginAsync(LoginViewModel credenciais);

        /// <summary>
        /// Verificar o token de autenticação de dois factores.
        /// </summary>
        /// <param name="tfaToken">O token a ser verificado.</param>
        /// <returns></returns>
        //Task<RepoResponse<LoginResultViewModel>> Verify2FAToken(string tfaToken);

        /// <summary>
        /// Registrar um usuário, bem como logar o mesmo ao sistema, retornando
        /// o token necessário para acesso aos recursos restritos do sistema.
        /// <param name="infoRegistro">Objecto contendo informações necessárias a execução do registro.</param>
        /// </summary>
        Task<RepoResponse<RegisterResultViewModel>> RegisterAsync(RegisterViewModel infoRegistro);

        /// <summary>
        /// Bloquear o acesso aos recursos fornecidos pelo sistema a uma determinado usuário.
        /// <param name="id">Identificador do usuário a ser bloquedo.</param>
        /// </summary>
        Task<bool> Bloquear(string id);

        // TODO: Verificar a existência da necessidade de deletar as informações de um usuário.
    }
}