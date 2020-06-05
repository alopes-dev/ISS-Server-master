using ISS.Application.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.ViewModels
{
    /// <summary>
    /// Model contendo informações necessárias para logar um possível usuário.
    /// </summary>
    public class RegisterViewModel
    {
        // O Username na pessoa a ser cadastrada.
        public string Username { get; set; }
        // O email da pessoa a ser cadastrada.
        public string Email { get; set; }
        // Password da pessoa a ser cadastrada.
        public string Password { get; set; }
        // Confirmação da password da pessoa a ser cadastrada.
        public string ConfirmarPassword { get; set; }
        [ForeignKey("PessoaId")]
        [InverseProperty("pessoa")]
        public virtual Pessoa Pessoa { get; set; }

    }
}