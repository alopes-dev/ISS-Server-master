using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BandeiraPagamentoType : ObjectGraphType<BandeiraPagamento>
    {
        public BandeiraPagamentoType()
        {
            // Defining the name of the object
            Name = "bandeiraPagamento";

            Field(x => x.IdBandeiraPagamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodBandeiraPagamento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<BandeiraTipoCartaoType>>("bandeiraTipoCartao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BandeiraTipoCartao>(x => x.Where(e => e.HasValue(c.Source.IdBandeiraPagamento)))));
            
        }
    }

    public class BandeiraPagamentoInputType : InputObjectGraphType
	{
		public BandeiraPagamentoInputType()
		{
			// Defining the name of the object
			Name = "bandeiraPagamentoInput";
			
            //Field<StringGraphType>("idBandeiraPagamento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codBandeiraPagamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<BandeiraTipoCartaoInputType>>("bandeiraTipoCartao");
			
		}
	}
}