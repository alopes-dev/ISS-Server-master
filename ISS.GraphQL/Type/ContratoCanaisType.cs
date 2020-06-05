using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratoCanaisType : ObjectGraphType<ContratoCanais>
    {
        public ContratoCanaisType()
        {
            // Defining the name of the object
            Name = "contratoCanais";

            Field(x => x.IdContratoCanal, nullable: true);
            Field(x => x.CodContratoCanal, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            
        }
    }

    public class ContratoCanaisInputType : InputObjectGraphType
	{
		public ContratoCanaisInputType()
		{
			// Defining the name of the object
			Name = "contratoCanaisInput";
			
            //Field<StringGraphType>("idContratoCanal");
			Field<StringGraphType>("codContratoCanal");
			Field<StringGraphType>("canalId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<CanalInputType>("canal");
			
		}
	}
}