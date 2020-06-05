using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TransferenciaType : ObjectGraphType<Transferencia>
    {
        public TransferenciaType()
        {
            // Defining the name of the object
            Name = "transferencia";

            Field(x => x.IdTransferencia, nullable: true);
            Field(x => x.ValorTransferencia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.BancoDestino, nullable: true);
            Field(x => x.ContaDestino, nullable: true);
            Field(x => x.TipoTransferenciaId, nullable: true);
            Field(x => x.NumCartao, nullable: true);
            Field(x => x.CodTransferencia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ContaDoTransferidor, nullable: true);
            FieldAsync<BancoType>("bancoDestinoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Banco>(c.Source.BancoDestino)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoTransferenciaType>("tipoTransferencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTransferencia>(c.Source.TipoTransferenciaId)));
            
        }
    }

    public class TransferenciaInputType : InputObjectGraphType
	{
		public TransferenciaInputType()
		{
			// Defining the name of the object
			Name = "transferenciaInput";
			
            //Field<StringGraphType>("idTransferencia");
			Field<FloatGraphType>("valorTransferencia");
			Field<StringGraphType>("bancoDestino");
			Field<StringGraphType>("contaDestino");
			Field<StringGraphType>("tipoTransferenciaId");
			Field<StringGraphType>("numCartao");
			Field<StringGraphType>("codTransferencia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("contaDoTransferidor");
			Field<BancoInputType>("bancoDestinoNavigation");
			Field<EstadoInputType>("estado");
			Field<TipoTransferenciaInputType>("tipoTransferencia");
			
		}
	}
}