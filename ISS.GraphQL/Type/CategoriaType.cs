using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriaType : ObjectGraphType<Categoria>
    {
        public CategoriaType()
        {
            // Defining the name of the object
            Name = "categoria";

            Field(x => x.IdCategoria, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoCategoriaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodCategoria, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCategoriaType>("tipoCategoria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCategoria>(c.Source.TipoCategoriaId)));
            FieldAsync<ListGraphType<ClassificacaoAutomovelType>>("classificacaoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdCategoria)))));
            
        }
    }

    public class CategoriaInputType : InputObjectGraphType
	{
		public CategoriaInputType()
		{
			// Defining the name of the object
			Name = "categoriaInput";
			
            //Field<StringGraphType>("idCategoria");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoCategoriaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codCategoria");
			Field<EstadoInputType>("estado");
			Field<TipoCategoriaInputType>("tipoCategoria");
			Field<ListGraphType<ClassificacaoAutomovelInputType>>("classificacaoAutomovel");
			
		}
	}
}