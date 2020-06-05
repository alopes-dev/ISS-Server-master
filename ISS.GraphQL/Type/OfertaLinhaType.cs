using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OfertaLinhaType : ObjectGraphType<OfertaLinha>
    {
        public OfertaLinhaType()
        {
            // Defining the name of the object
            Name = "ofertaLinha";

            Field(x => x.IdOfertaLina, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.HistoricoOfertaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodOfertaLinha, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<HistoricoOfertaType>("historicoOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HistoricoOferta>(c.Source.HistoricoOfertaId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class OfertaLinhaInputType : InputObjectGraphType
	{
		public OfertaLinhaInputType()
		{
			// Defining the name of the object
			Name = "ofertaLinhaInput";
			
            //Field<StringGraphType>("idOfertaLina");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("historicoOfertaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codOfertaLinha");
			Field<EstadoInputType>("estado");
			Field<HistoricoOfertaInputType>("historicoOferta");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}