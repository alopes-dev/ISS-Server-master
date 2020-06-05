using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GlossarioType : ObjectGraphType<Glossario>
    {
        public GlossarioType()
        {
            // Defining the name of the object
            Name = "glossario";

            Field(x => x.IdGlossario, nullable: true);
            Field(x => x.ProcessoElemento, nullable: true);
            Field(x => x.HierarquiaId, nullable: true);
            Field(x => x.ElementoProcesso, nullable: true);
            Field(x => x.Definicao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodGlossario, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.CategoriaGlossarioId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.InApolice, nullable: true, type: typeof(IntGraphType));
            FieldAsync<CategoriaGlossarioType>("categoriaGlossario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaGlossario>(c.Source.CategoriaGlossarioId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            
        }
    }

    public class GlossarioInputType : InputObjectGraphType
	{
		public GlossarioInputType()
		{
			// Defining the name of the object
			Name = "glossarioInput";
			
            //Field<StringGraphType>("idGlossario");
			Field<StringGraphType>("processoElemento");
			Field<StringGraphType>("hierarquiaId");
			Field<StringGraphType>("elementoProcesso");
			Field<StringGraphType>("definicao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codGlossario");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("categoriaGlossarioId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<IntGraphType>("inApolice");
			Field<CategoriaGlossarioInputType>("categoriaGlossario");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			
		}
	}
}