using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCartaoType : ObjectGraphType<TipoCartao>
    {
        public TipoCartaoType()
        {
            // Defining the name of the object
            Name = "tipoCartao";

            Field(x => x.IdTipoCartao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.FormaPagamentoId, nullable: true);
            Field(x => x.CodTipoCartao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            
        }
    }

    public class TipoCartaoInputType : InputObjectGraphType
	{
		public TipoCartaoInputType()
		{
			// Defining the name of the object
			Name = "tipoCartaoInput";
			
            //Field<StringGraphType>("idTipoCartao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("formaPagamentoId");
			Field<StringGraphType>("codTipoCartao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoInputType>("formaPagamento");
			
		}
	}
}