using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoeficientePremioPessoasType : ObjectGraphType<CoeficientePremioPessoas>
    {
        public CoeficientePremioPessoasType()
        {
            // Defining the name of the object
            Name = "coeficientePremioPessoas";

            Field(x => x.IdCoeficientePremioPessoas, nullable: true);
            Field(x => x.NumeroMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumeroMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.AgravamentoOuDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodCoeficientePremioPessoas, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            
        }
    }

    public class CoeficientePremioPessoasInputType : InputObjectGraphType
	{
		public CoeficientePremioPessoasInputType()
		{
			// Defining the name of the object
			Name = "coeficientePremioPessoasInput";
			
            //Field<StringGraphType>("idCoeficientePremioPessoas");
			Field<IntGraphType>("numeroMax");
			Field<IntGraphType>("numeroMin");
			Field<FloatGraphType>("agravamentoOuDesconto");
			Field<StringGraphType>("codCoeficientePremioPessoas");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoCoberturaId");
			Field<EstadoInputType>("estado");
			Field<TipoCoberturaInputType>("tipoCobertura");
			
		}
	}
}