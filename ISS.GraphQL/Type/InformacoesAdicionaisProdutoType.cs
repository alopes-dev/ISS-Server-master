using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class InformacoesAdicionaisProdutoType : ObjectGraphType<InformacoesAdicionaisProduto>
    {
        public InformacoesAdicionaisProdutoType()
        {
            // Defining the name of the object
            Name = "informacoesAdicionaisProduto";

            Field(x => x.IdInformacoesAdicionaisProduto, nullable: true);
            Field(x => x.Titulo, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.CaminhoImagem, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodInformacoesAdicionaisProduto, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            
        }
    }

    public class InformacoesAdicionaisProdutoInputType : InputObjectGraphType
	{
		public InformacoesAdicionaisProdutoInputType()
		{
			// Defining the name of the object
			Name = "informacoesAdicionaisProdutoInput";
			
            //Field<StringGraphType>("idInformacoesAdicionaisProduto");
			Field<StringGraphType>("titulo");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("caminhoImagem");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("codInformacoesAdicionaisProduto");
			Field<EstadoInputType>("estado");
			Field<ProdutoInputType>("produto");
			
		}
	}
}