using ISS.Application.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.ViewModels
{
    /// <summary>
    /// Model contendo propriedades necessárias para login de usuários.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// O nome ou email email do usuário tentando logar
        /// </summary>
        public string NomeUsuarioOuEmail { get; set; }

        /// <summary>
        /// Senha do usuário
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Lembrar do login do usuário caso necessário.
        /// </summary>
        public bool LembrarDeMim { get; set; } = false;
        /// <summary>
        /// Pessoa.
        /// </summary>
        [ForeignKey("PessoaId")]
        [InverseProperty("pessoa")]
        public virtual Pessoa PessoaLogar { get; set; }
    }

    /// <summary>
    /// ViewModel para lidar com os resultados de login.
    /// </summary>
    public class LoginResultViewModel
    {
        /// <summary>
        /// Identificador do usuário logado.
        /// </summary>
        public string IdUsuario { get; set; }

        /// <summary>
        /// O nome ou email email do usuário tentando logar
        /// </summary>
        public string NomeUsuarioOuEmail { get; set; }

        /// <summary>
        /// Lembrar do login do usuário caso necessário.
        /// </summary>
        public bool LembrarDeMim { get; set; } = false;

        /// <summary>
        /// Token de acesso a recursos de usuário.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Pessoa.
        /// </summary>
        [ForeignKey("PessoaId")]
        [InverseProperty("pessoa")]
        public virtual Pessoa PessoaLogar { get; set; }
    }
}