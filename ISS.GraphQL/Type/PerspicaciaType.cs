using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PerspicaciaType : ObjectGraphType<Perspicacia>
    {
        public PerspicaciaType()
        {
            // Defining the name of the object
            Name = "perspicacia";

            Field(x => x.IdVantagensProdutos, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodPerspicacia, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            
        }
    }

    public class PerspicaciaInputType : InputObjectGraphType
	{
		public PerspicaciaInputType()
		{
			// Defining the name of the object
			Name = "perspicaciaInput";
			
            //Field<StringGraphType>("idVantagensProdutos");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("codPerspicacia");
			Field<EstadoInputType>("estado");
			Field<ProdutoInputType>("produto");
			
		}
	}
}