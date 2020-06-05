using FluentValidation;
using ISS.Application.Models;

namespace ISS.Application.Services.Validation
{
    public class AutomovelValidation : AbstractValidator<Automovel>
    {
        protected string maskara = string.Empty;
        protected string[] caracteres = { "abcdefghijklmnopqrstuvwxyz", "0123456789" };
        protected int numeros = 0, letras = 0;
        public AutomovelValidation()
        {
            // Validação de Data da primeira matricula
            RuleFor(x => x.DataPrimeiraMatricula).Cascade(CascadeMode.StopOnFirstFailure)
                                                 .NotEmpty().WithMessage("Insira a data da primeira matricula");

            // Validação de VIN
            //RuleFor(x => x.Vin).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
            //    .WithMessage("O campo vin é obrigatório")
            //    .MaximumLength(17).WithMessage("So é permitido n no intervalo de 4 a 20 caracteres");

            // Validação de Matriculas
            RuleFor(x => x.Matricula).
            Must(FirstMatricula).When(x => x.DataPrimeiraMatricula.Value.Year >= 1955 && x.DataPrimeiraMatricula.Value.Year < 1996).WithMessage("Matrícula inválida");

            // Validação de Matriculas
            RuleFor(x => x.Matricula).Must(SecondMatricula)
                                    .When(x => x.DataPrimeiraMatricula.Value.Year >= 1996)
                                    .WithMessage("Matrícula inválida");

            // Validação de Marcas
            RuleFor(x => x.ExemplarModeloId).Cascade(CascadeMode.StopOnFirstFailure)
                                            .NotEmpty()
                                            .WithMessage("Insira a marca da viatura");

            // Validação para os modelos
            RuleFor(x => x.ExemplarModeloId).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira o modelo da viatura");

            // Validação de Pais da matricula
            RuleFor(x => x.PaisMatriculaId).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira o pais da matrícula");

            // Validação de Ano de construção
            RuleFor(x => x.AnoConstrucao).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira o ano de construção do veiculo.");

            // Validação de Exemplar do modelo
            RuleFor(x => x.ExemplarModeloId).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira o exemplar do modelo");

            // Validação de Cilindragem
            RuleFor(x => x.CilindragemAutomovelId).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira a cilindragem do veiculo");

            // Validação de potencia
            RuleFor(x => x.Potencia.Value).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira a potência do veiculo");

            // Validação de cor
            RuleFor(x => x.CorId).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira a cor do veiculo");

            // Validação de lugares
            RuleFor(x => x.NumLugares).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira o númer de lugares");

            // Validação de chassi
            RuleFor(x => x.NumeroChassi).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira o número do chassi veiculo");

            // Validação de moeda
            RuleFor(x => x.MoedaId).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira a moeda");


            // Validação de proprietário
            RuleFor(x => x.ProprietarioId).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira o proprietário do veiculo");

            // Validação de condutor
            RuleFor(x => x.Motorista).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Insira o motorista do veiculo");

        }
        protected bool FirstMatricula(string matricula)
        {
            numeros = 0;
            letras = 0;

            maskara = "AAA-00-00";
            if (matricula.Length != maskara.Length || matricula[3] != '-' || matricula[6] != '-')
            {
                return false;
            }


            for (int i = 0; i < matricula.Length; i++)
            {
                if (caracteres[0].Contains(matricula[i].ToString()))
                {
                    letras++;
                }
                else if (caracteres[1].Contains(matricula[i].ToString()))
                {
                    numeros++;
                }

                // validar a condição da mascara AAA-00-00

                if (i == 3 && letras < 3)
                {
                    return false;
                }
                if (i == 8 && numeros < 4)
                {
                    return false;
                }
            }

            if (letras == 3 && numeros == 4)
                return true;
            else
                return false;
        }

        protected bool SecondMatricula(string matricula)
        {
            numeros = 0;
            letras = 0;

            maskara = "AA-00-00-AA";

            // Verificar a posicao dos -
            if (matricula.Length != maskara.Length || matricula[2] != '-' || matricula[5] != '-' || matricula[8] != '-')
            {
                return false;
            }

            // contar a quantidade de caracteres e numeros
            for (int i = 0; i < matricula.Length; i++)
            {
                if (caracteres[0].Contains(matricula[i].ToString()))
                {
                    letras++;
                }
                else if (caracteres[1].Contains(matricula[i].ToString()))
                {
                    numeros++;
                }

                // validar a condição da mascara "AA-00-00-AA"

                if (i == 2 && letras < 2)
                {
                    return false;
                }
                if (i == 8 && numeros < 4)
                {
                    return false;
                }
                if (i == 11 && letras < 4)
                {
                    return false;
                }
            }

            if (numeros == 4 && letras == 4)
                return true;
            else
                return false;
        }


    }
}
