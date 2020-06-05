using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoClienteType : ObjectGraphType<TipoCliente>
    {
        public TipoClienteType()
        {
            // Defining the name of the object
            Name = "tipoCliente";

            Field(x => x.IdTipoCliente, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoCliente, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ClienteType>>("cliente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cliente>(x => x.Where(e => e.HasValue(c.Source.IdTipoCliente)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdTipoCliente)))));
            
        }
    }

    public class TipoClienteInputType : InputObjectGraphType
	{
		public TipoClienteInputType()
		{
			// Defining the name of the object
			Name = "tipoClienteInput";
			
            //Field<StringGraphType>("idTipoCliente");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoCliente");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ClienteInputType>>("cliente");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceira");
			
		}
	}
}