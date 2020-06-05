using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CoPagamentoType : ObjectGraphType<CoPagamento>
    {
        public CoPagamentoType()
        {
            // Defining the name of the object
            Name = "coPagamento";

            Field(x => x.IdCoPagamento, nullable: true);
            Field(x => x.ReferenciaPagamento, nullable: true);
            Field(x => x.DataHora, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TotalPago, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Obs, nullable: true);
            Field(x => x.FornecedorId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.FormaPagamentoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodCoPagamento, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            FieldAsync<PessoaType>("fornecedor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.FornecedorId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            
        }
    }

    public class CoPagamentoInputType : InputObjectGraphType
	{
		public CoPagamentoInputType()
		{
			// Defining the name of the object
			Name = "coPagamentoInput";
			
            //Field<StringGraphType>("idCoPagamento");
			Field<StringGraphType>("referenciaPagamento");
			Field<DateTimeGraphType>("dataHora");
			Field<FloatGraphType>("totalPago");
			Field<StringGraphType>("obs");
			Field<StringGraphType>("fornecedorId");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("formaPagamentoId");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("moedaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codCoPagamento");
			Field<ApoliceInputType>("apolice");
			Field<CanalInputType>("canal");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoInputType>("formaPagamento");
			Field<PessoaInputType>("fornecedor");
			Field<MoedaInputType>("moeda");
			
		}
	}
}