using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SimulacaoType : ObjectGraphType<Simulacao>
    {
        public SimulacaoType()
        {
            // Defining the name of the object
            Name = "simulacao";

            Field(x => x.IdSimulacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodSimulacao, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.RefSimulacao, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.NumOrdem, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumPessoas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumDias, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CaeId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            //FieldAsync<DecimalType>("valor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Decimal>(c.Source.IdSimulacao)));
            //FieldAsync<DecimalType>("numSalarioPorAno", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Decimal>(c.Source.IdSimulacao)));
            Field(x => x.Cilindrada, nullable: true);
            Field(x => x.FraccionamentoId, nullable: true);
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.CaeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FraccionamentoType>("fraccionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fraccionamento>(c.Source.FraccionamentoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<SimulacaoDependenteType>>("simulacaoDependente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SimulacaoDependente>(x => x.Where(e => e.HasValue(c.Source.IdSimulacao)))));
            
        }
    }

    public class SimulacaoInputType : InputObjectGraphType
	{
		public SimulacaoInputType()
		{
			// Defining the name of the object
			Name = "simulacaoInput";
			
            //Field<StringGraphType>("idSimulacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codSimulacao");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("refSimulacao");
			Field<StringGraphType>("pessoaId");
			Field<IntGraphType>("numOrdem");
			Field<IntGraphType>("numPessoas");
			Field<IntGraphType>("numDias");
			Field<StringGraphType>("caeId");
			Field<StringGraphType>("moedaId");
			//Field<DecimalInputType>("valor");
			//Field<DecimalInputType>("numSalarioPorAno");
			Field<StringGraphType>("cilindrada");
			Field<StringGraphType>("fraccionamentoId");
			Field<CaeInputType>("cae");
			Field<EstadoInputType>("estado");
			Field<FraccionamentoInputType>("fraccionamento");
			Field<MoedaInputType>("moeda");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<SimulacaoDependenteInputType>>("simulacaoDependente");
			
		}
	}
}