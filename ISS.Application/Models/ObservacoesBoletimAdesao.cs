﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISS.Application.Models
{
    public partial class ObservacoesBoletimAdesao
    {
        public ObservacoesBoletimAdesao()
        {
            BoletimAdesaoSaude = new HashSet<BoletimAdesaoSaude>();
        }

        [StringLength(50)]
        public string IdObservacoesBoletimAdesao { get; set; }
        [Column(TypeName = "ntext")]
        public string Observacao { get; set; }
        public bool? Aprovado { get; set; }
        [StringLength(50)]
        public string IntroduzidoPor { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataActualizacao { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataCriacao { get; set; }
        [StringLength(50)]
        public string EstadoId { get; set; }
        [StringLength(50)]
        public string CodObservacoesBoletimAdesao { get; set; }

        [ForeignKey("EstadoId")]
        [InverseProperty("ObservacoesBoletimAdesao")]
        public virtual Estado Estado { get; set; }
        [ForeignKey("IntroduzidoPor")]
        [InverseProperty("ObservacoesBoletimAdesao")]
        public virtual Pessoa IntroduzidoPorNavigation { get; set; }
        [InverseProperty("ObservacoesBoletimAdesaoNavigation")]
        public virtual ICollection<BoletimAdesaoSaude> BoletimAdesaoSaude { get; set; }
    }
}