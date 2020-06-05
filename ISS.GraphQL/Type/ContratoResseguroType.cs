using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratoResseguroType : ObjectGraphType<ContratoResseguro>
    {
        public ContratoResseguroType()
        {
            // Defining the name of the object
            Name = "contratoResseguro";

            Field(x => x.IdContratoResseguro, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.ResseguroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Retencao, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<ResseguroType>("resseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Resseguro>(c.Source.ResseguroId)));
            FieldAsync<ListGraphType<AssinantesResseguroType>>("assinantesResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AssinantesResseguro>(x => x.Where(e => e.HasValue(c.Source.IdContratoResseguro)))));
            
        }
    }

    public class ContratoResseguroInputType : InputObjectGraphType
	{
		public ContratoResseguroInputType()
		{
			// Defining the name of the object
			Name = "contratoResseguroInput";
			
            //Field<StringGraphType>("idContratoResseguro");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("resseguroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<FloatGraphType>("retencao");
			Field<ContratoInputType>("contrato");
			Field<ResseguroInputType>("resseguro");
			Field<ListGraphType<AssinantesResseguroInputType>>("assinantesResseguro");
			
		}
	}
}