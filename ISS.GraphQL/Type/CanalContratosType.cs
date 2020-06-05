using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CanalContratosType : ObjectGraphType<CanalContratos>
    {
        public CanalContratosType()
        {
            // Defining the name of the object
            Name = "canalContratos";

            Field(x => x.IdCanalContratos, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.CodCanalContratos, nullable: true);
            Field(x => x.CanalContratoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<CanalType>("canalContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalContratoId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            
        }
    }

    public class CanalContratosInputType : InputObjectGraphType
	{
		public CanalContratosInputType()
		{
			// Defining the name of the object
			Name = "canalContratosInput";
			
            //Field<StringGraphType>("idCanalContratos");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("codCanalContratos");
			Field<StringGraphType>("canalContratoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<CanalInputType>("canalContrato");
			Field<ContratoInputType>("contrato");
			
		}
	}
}