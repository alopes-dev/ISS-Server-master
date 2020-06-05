using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoObrigacoesType : ObjectGraphType<TipoObrigacoes>
    {
        public TipoObrigacoesType()
        {
            // Defining the name of the object
            Name = "tipoObrigacoes";

            Field(x => x.IdTipoObrigacoes, nullable: true);
            Field(x => x.CodTipoObrigacoes, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ObrigacoesProdutoType>>("obrigacoesProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObrigacoesProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipoObrigacoes)))));
            
        }
    }

    public class TipoObrigacoesInputType : InputObjectGraphType
	{
		public TipoObrigacoesInputType()
		{
			// Defining the name of the object
			Name = "tipoObrigacoesInput";
			
            //Field<StringGraphType>("idTipoObrigacoes");
			Field<StringGraphType>("codTipoObrigacoes");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ObrigacoesProdutoInputType>>("obrigacoesProduto");
			
		}
	}
}