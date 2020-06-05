using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RelatorioLinksType : ObjectGraphType<RelatorioLinks>
    {
        public RelatorioLinksType()
        {
            // Defining the name of the object
            Name = "relatorioLinks";

            Field(x => x.IdRelatorioLinks, nullable: true);
            Field(x => x.Codigo, nullable: true);
            Field(x => x.Link, nullable: true);
            Field(x => x.CodRelatorioLinks, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Categoria, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class RelatorioLinksInputType : InputObjectGraphType
	{
		public RelatorioLinksInputType()
		{
			// Defining the name of the object
			Name = "relatorioLinksInput";
			
            //Field<StringGraphType>("idRelatorioLinks");
			Field<StringGraphType>("codigo");
			Field<StringGraphType>("link");
			Field<StringGraphType>("codRelatorioLinks");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("categoria");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}