using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoApoliceType : ObjectGraphType<TipoApolice>
    {
        public TipoApoliceType()
        {
            // Defining the name of the object
            Name = "tipoApolice";

            Field(x => x.IdTipoApolice, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoApolice, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ListGraphType<ApoliceType>>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(x => x.Where(e => e.HasValue(c.Source.IdTipoApolice)))));
            
        }
    }

    public class TipoApoliceInputType : InputObjectGraphType
	{
		public TipoApoliceInputType()
		{
			// Defining the name of the object
			Name = "tipoApoliceInput";
			
            //Field<StringGraphType>("idTipoApolice");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoApolice");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("linhaProdutoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ListGraphType<ApoliceInputType>>("apolice");
			
		}
	}
}