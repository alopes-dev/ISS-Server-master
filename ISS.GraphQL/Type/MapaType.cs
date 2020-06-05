using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MapaType : ObjectGraphType<Mapa>
    {
        public MapaType()
        {
            // Defining the name of the object
            Name = "mapa";

            Field(x => x.IdMapa, nullable: true);
            Field(x => x.ContaId, nullable: true);
            Field(x => x.ModeloMapaId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodMapa, nullable: true);
            FieldAsync<PlanoContasType>("conta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.ContaId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ModeloMapaType>("modeloMapa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModeloMapa>(c.Source.ModeloMapaId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            
        }
    }

    public class MapaInputType : InputObjectGraphType
	{
		public MapaInputType()
		{
			// Defining the name of the object
			Name = "mapaInput";
			
            //Field<StringGraphType>("idMapa");
			Field<StringGraphType>("contaId");
			Field<StringGraphType>("modeloMapaId");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("produtoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codMapa");
			Field<PlanoContasInputType>("conta");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ModeloMapaInputType>("modeloMapa");
			Field<ProdutoInputType>("produto");
			
		}
	}
}