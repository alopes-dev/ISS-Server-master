using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ArtigoType : ObjectGraphType<Artigo>
    {
        public ArtigoType()
        {
            // Defining the name of the object
            Name = "artigo";

            Field(x => x.IdArtigo, nullable: true);
            Field(x => x.NumOrdemArtigo, nullable: true);
            Field(x => x.Titulo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodArtigo, nullable: true);
            Field(x => x.CapituloId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.DescricaoTituloArtigo, nullable: true);
            FieldAsync<CapituloType>("capitulo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Capitulo>(c.Source.CapituloId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ListGraphType<ClausulaType>>("clausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Clausula>(x => x.Where(e => e.HasValue(c.Source.IdArtigo)))));
            
        }
    }

    public class ArtigoInputType : InputObjectGraphType
	{
		public ArtigoInputType()
		{
			// Defining the name of the object
			Name = "artigoInput";
			
            //Field<StringGraphType>("idArtigo");
			Field<StringGraphType>("numOrdemArtigo");
			Field<StringGraphType>("titulo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codArtigo");
			Field<StringGraphType>("capituloId");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("descricaoTituloArtigo");
			Field<CapituloInputType>("capitulo");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ListGraphType<ClausulaInputType>>("clausula");
			
		}
	}
}