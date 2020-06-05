using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratoMoedaType : ObjectGraphType<ContratoMoeda>
    {
        public ContratoMoedaType()
        {
            // Defining the name of the object
            Name = "contratoMoeda";

            Field(x => x.IdContratoMoeda, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.CodContratoMoeda, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            
        }
    }

    public class ContratoMoedaInputType : InputObjectGraphType
	{
		public ContratoMoedaInputType()
		{
			// Defining the name of the object
			Name = "contratoMoedaInput";
			
            //Field<StringGraphType>("idContratoMoeda");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("codContratoMoeda");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ContratoInputType>("contrato");
			Field<MoedaInputType>("moeda");
			
		}
	}
}