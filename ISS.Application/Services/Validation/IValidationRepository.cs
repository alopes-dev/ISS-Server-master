using FluentValidation;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace ISS.Application.Services.Validation
{
    public interface IValidationRepository
    {
        void AddValidationRule<TModel>(AbstractValidator<TModel> validator) where TModel : class;
        bool Validate<TModel>(TModel model) where TModel : class;
    }

    public class ValidationRepository : IValidationRepository
    {
        #region Private Members
        /// <summary>
        /// Dicionário de validadores de dados.
        /// </summary>
        private readonly Dictionary<string, IValidator> _validators;
        #endregion

        #region Public Properties
        /// <summary>
        /// Guardar os erros após operação de validação.
        /// </summary>
        /// <typeparam name="string">Erros em forma de string.</typeparam>
        /// <returns></returns>
        public ICollection<string> Errors { get; private set; } = new List<string>();
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logging de tudo o que acontecer com as validações.</param>
        public ValidationRepository(ILogger<ValidationRepository> logger)
        {
            // Inicializar com uma capacidade de 10 elementos.
            _validators = new Dictionary<string, IValidator>(10);
        }
        #endregion

        public void AddValidationRule<TModel>(AbstractValidator<TModel> validator)
            where TModel : class
        {
            var genericType = validator.GetType().GetGenericArguments()[0];
            _validators.Add(genericType.Name, validator);
        }

        public bool Validate<TModel>(TModel model) where TModel : class
        {
            // Pegar o objecto de validação para o modelo em questão.
            _validators.TryGetValue(typeof(TModel).Name, out IValidator validator);
            var result = validator?.Validate(model);

            // Sem resultado
            if (result == null)
                return true;

            // Extrair os erros
            if (!result.IsValid)
            {
                // Limpar a lista de erros.
                Errors.Clear();
                // Extrair os erros
                result.Errors.ToList().ForEach(error => Errors.Add($"{error.PropertyName} : {error.ErrorMessage}"));
                return false;
            }

            return true;
        }
    }
}