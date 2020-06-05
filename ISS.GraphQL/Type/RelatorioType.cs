using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RelatorioType : ObjectGraphType<Relatorio>
    {
        public RelatorioType()
        {
            // Defining the name of the object
            Name = "relatorio";

            Field(x => x.IdRelatorio, nullable: true);
            Field(x => x.Codigo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            FieldAsync<ListGraphType<RelatorioContaType>>("relatorioConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RelatorioConta>(x => x.Where(e => e.HasValue(c.Source.IdRelatorio)))));
            FieldAsync<ListGraphType<RelatorioProdutoType>>("relatorioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RelatorioProduto>(x => x.Where(e => e.HasValue(c.Source.IdRelatorio)))));
            
        }
    }

    public class RelatorioInputType : InputObjectGraphType
	{
		public RelatorioInputType()
		{
			// Defining the name of the object
			Name = "relatorioInput";
			
            //Field<StringGraphType>("idRelatorio");
			Field<StringGraphType>("codigo");
			Field<StringGraphType>("designacao");
			Field<ListGraphType<RelatorioContaInputType>>("relatorioConta");
			Field<ListGraphType<RelatorioProdutoInputType>>("relatorioProduto");
			
		}
	}
}