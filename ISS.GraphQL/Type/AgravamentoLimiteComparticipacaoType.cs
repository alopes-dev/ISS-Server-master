using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AgravamentoLimiteComparticipacaoType : ObjectGraphType<AgravamentoLimiteComparticipacao>
    {
        public AgravamentoLimiteComparticipacaoType()
        {
            // Defining the name of the object
            Name = "agravamentoLimiteComparticipacao";

            Field(x => x.IdAgravamentoLimiteComparticipacao, nullable: true);
            Field(x => x.TaxaComparticipacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.AgravamentoOuDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodAgravamentoLimiteComparticipacao, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            
        }
    }

    public class AgravamentoLimiteComparticipacaoInputType : InputObjectGraphType
	{
		public AgravamentoLimiteComparticipacaoInputType()
		{
			// Defining the name of the object
			Name = "agravamentoLimiteComparticipacaoInput";
			
            //Field<StringGraphType>("idAgravamentoLimiteComparticipacao");
			Field<FloatGraphType>("taxaComparticipacao");
			Field<FloatGraphType>("agravamentoOuDesconto");
			Field<StringGraphType>("codAgravamentoLimiteComparticipacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoCoberturaId");
			Field<EstadoInputType>("estado");
			Field<TipoCoberturaInputType>("tipoCobertura");
			
		}
	}
}