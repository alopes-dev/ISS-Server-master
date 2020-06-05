using FluentValidation;
using ISS.Application.Dto.Models;


namespace ISS.Application.Services.Validation
{
    // Pessoa Singular
    public class PessoaSingularValidation : AbstractValidator<PessoaSingular>
    {
        string caracter = @";./?'{}=+$%^!|#@&*()\-1234567890<>:;";
        public PessoaSingularValidation()
        {
            //Validação do Sexo da pessoa
            RuleFor(PessoaSingular => PessoaSingular.SexoId).NotEmpty().WithMessage("Selecione o Sexo !");
            //Validação de Situacao de Emprego
            RuleFor(PessoaSingular => PessoaSingular.SituacaoEmpregoId).NotEmpty().WithMessage("Informe a sua Situacao de Emprego !");
            //Validação do Primeiro Nome
            RuleFor(PessoaSingular => PessoaSingular.PrimeiroNome).NotEmpty().WithMessage("Informe o seu Primeiro Nome!");
            RuleFor(x => x.PrimeiroNome).Must(NomeValidar).When(x => x.PrimeiroNome != null).WithMessage("Nome inválido");
            //Validação do Ultimo Nome
            RuleFor(PessoaSingular => PessoaSingular.UltimoNome).NotEmpty().WithMessage("Informe o seu Ultimo Nome!");
            RuleFor(x => x.UltimoNome).Must(NomeValidar).When(x => x.UltimoNome != null).WithMessage("Nome inválido");
            //Validação do Estado Civil
            RuleFor(PessoaSingular => PessoaSingular.EstadoCivilId).NotEmpty().WithMessage("Informe o seu Estado Civil!");
            //Validação do Titulo
            RuleFor(PessoaSingular => PessoaSingular.TituloId).NotEmpty().WithMessage("Informe o seu Titulo!");
            //Validação do Tipo Sanguineo
            RuleFor(PessoaSingular => PessoaSingular.TipoSanguineoId).NotEmpty().WithMessage("Informe seu Tipo Sanguineo!");
        }
        protected bool NomeValidar(string Nome)
        {
            char retorno = ' ';
            for (int i = 0; i < Nome.Length; i++)
            {
                for (int y = 0; y < caracter.Length; y++)
                {
                    if (Nome[i] == caracter[y]) retorno = Nome[i];
                }
            }
            if (retorno == ' ') return true;
            else return false;
        }
    }
    public class PessoaColectivaValidation : AbstractValidator<PessoaColectiva>
    {
        public PessoaColectivaValidation()
        {
            //Validação do Despesa Total Dos Funcionarios
            RuleFor(PessoaColectiva => PessoaColectiva.DespesaTotalDosFuncionarios).NotEmpty().WithMessage("Informe Despesa Total Do Funcionario!");
            //Validação do Numero de Alvara
            RuleFor(PessoaColectiva => PessoaColectiva.NumAlvara).NotEmpty().WithMessage("Informe o Numero de Alvara!");
            //Validação do Numero do Registro Comercial 
            RuleFor(PessoaColectiva => PessoaColectiva.NumRegistroComercial).NotEmpty().WithMessage("Informe Numero do Registro Comercial!");
        }
    }
}
