using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public class Usuario : IdentityUser
    {
        public string Sufixo { get; set; }
        public bool IsAtivo { get; set; }
        public bool UsuarioComercial { get; set; }
        public bool OfflineUser { get; set; }
        public bool AgenteCampo { get; set; }
        public bool Fluxo { get; set; }
        public bool ServicoNuvem { get; set; }
        public bool ApenasClassico { get; set; }
        public bool GraficoAutoContraste { get; set; }
        public bool PermitePrevisao { get; set; }
        public bool DebugMode { get; set; }
        public bool CheckoutAtivo { get; set; }
        public string PessoaId { get; set; }

        [ForeignKey("PessoaId")]
        [InverseProperty("Usuario")]
        public virtual Pessoa Pessoa { get; set; }
        [InverseProperty("Usuario")]
        public virtual ICollection<HistoricoLogin> HistoricoLogin { get; set; }
        [InverseProperty("Usuario")]
        public virtual ICollection<HistoricoVerificacaoIdentidade> HistoricoVerificacaoIdentidade { get; set; }
    }
}
