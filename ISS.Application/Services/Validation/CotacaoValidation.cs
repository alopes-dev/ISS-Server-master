using FluentValidation;
using ISS.Application.Models;
using System;

namespace ISS.Application.Services.Validation
{
    public class CotacaoValidation : AbstractValidator<Cotacao>
    {
        public DateTime DataLocal = DateTime.Now;
        public CotacaoValidation()
        {
            //Verificar a DataInicio da cotação
            RuleFor(cotacao => cotacao.DataInicio).NotEmpty().WithMessage("Insira a data de início!");
            //RuleFor(cotacao => cotacao.DataInicio).Must(FirstMatricula).When(x => x.DataInicio !=null).WithMessage("Data de Início inválida");
            //Verificar Produtor
            RuleFor(cotacao => cotacao.ProdutorId).NotEmpty().WithMessage("Informe o Agente Produtor!");
            //Verificar Cobrador
            RuleFor(cotacao => cotacao.CobradorId).NotEmpty().WithMessage("Selecione o Cobrador!");
            //Verificar Qualidade Em Que Segura
            RuleFor(cotacao => cotacao.QualidadeEmQueSeguraId).NotEmpty().WithMessage("Selecione Qualidade em que Segura!");
            //Verificar Forma de Contratacao)
            RuleFor(cotacao => cotacao.FormaContratacaoId).NotEmpty().WithMessage("Selecione a forma de Contratação!");
            //Verificar Forma Duracao Tipo Contrato
            RuleFor(cotacao => cotacao.DuracaoTipoContratoId).NotEmpty().WithMessage("Selecione duração do Contrato!");
            //Verificar Fraccionamento
            RuleFor(cotacao => cotacao.FraccionamentoId).NotEmpty().WithMessage("Selecione o fracionamento!");
            //Verificar data de Vencimento
            RuleFor(cotacao => cotacao.DataExpiracao).NotEmpty().WithMessage("Selecione a data de Vencimento do Contrato!");
            //Verificar Data atualizacao
            RuleFor(cotacao => cotacao.DataAtualizacao).NotEmpty().WithMessage("Selecione a data de Renovação do Contrato!");
            //Verificar o período do Plano
            RuleFor(cotacao => cotacao.PeriodoPlanoId).NotEmpty().WithMessage("Selecione o período do Plano!");
            //Verificar ActividadeContratada
            RuleFor(cotacao => cotacao.ActividadeContratadaId).NotEmpty().WithMessage("Selecione a ActividadeContratada!");
            //Verificar ActividadeContratada
            RuleFor(cotacao => cotacao.FormaLiquidacaoPremioId).NotEmpty().WithMessage("Selecione a forma de Liquidação!");
            //Verificar Moeda
            RuleFor(cotacao => cotacao.MoedaId).NotEmpty().WithMessage("Selecione o tipo de Moeda!");

        }
        protected bool FirstMatricula(DateTime DataInicio)
        {
            if (DataInicio >= DataLocal)
                return true;
            else
                return false;
        }


    }
}