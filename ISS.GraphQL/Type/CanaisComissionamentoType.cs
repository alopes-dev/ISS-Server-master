using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CanaisComissionamentoType : ObjectGraphType<CanaisComissionamento>
    {
        public CanaisComissionamentoType()
        {
            // Defining the name of the object
            Name = "canaisComissionamento";

            Field(x => x.IdCanaisComissionamento, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.CodCanaisComissionamento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ComissionamentoId, nullable: true);
            FieldAsync<ComissionamentoType>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(c.Source.ComissionamentoId)));
            
        }
    }

    public class CanaisComissionamentoInputType : InputObjectGraphType
	{
		public CanaisComissionamentoInputType()
		{
			// Defining the name of the object
			Name = "canaisComissionamentoInput";
			
            //Field<StringGraphType>("idCanaisComissionamento");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("codCanaisComissionamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("comissionamentoId");
			Field<ComissionamentoInputType>("comissionamento");
			
		}
	}
}