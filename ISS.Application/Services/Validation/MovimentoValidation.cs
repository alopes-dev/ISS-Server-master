using FluentValidation;
using ISS.Application.Models;

namespace ISS.Application.Services.Validation
{
    public class MovimentoValidation : AbstractValidator<Movimento>
    {
        public MovimentoValidation()
        {

            RuleFor(movimento => movimento.CodContaFinanceira).NotEmpty().WithMessage("Insira Nº de conta Financeira");

            RuleFor(movimento => movimento.CodTipoDocumentos).NotEmpty().WithMessage("Informe o tipo de Documentos");

            RuleFor(movimento => movimento.CodCae).NotEmpty().WithMessage("Insira o sector de Actividade");

        }
    }
}