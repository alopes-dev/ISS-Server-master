using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratoCaeType : ObjectGraphType<ContratoCae>
    {
        public ContratoCaeType()
        {
            // Defining the name of the object
            Name = "contratoCae";

            Field(x => x.IdContratoCae, nullable: true);
            Field(x => x.CaeId, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.CaeId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            
        }
    }

    public class ContratoCaeInputType : InputObjectGraphType
	{
		public ContratoCaeInputType()
		{
			// Defining the name of the object
			Name = "contratoCaeInput";
			
            //Field<StringGraphType>("idContratoCae");
			Field<StringGraphType>("caeId");
			Field<StringGraphType>("contratoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<CaeInputType>("cae");
			Field<ContratoInputType>("contrato");
			
		}
	}
}