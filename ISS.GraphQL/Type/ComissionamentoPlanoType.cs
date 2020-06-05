using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ComissionamentoPlanoType : ObjectGraphType<ComissionamentoPlano>
    {
        public ComissionamentoPlanoType()
        {
            // Defining the name of the object
            Name = "comissionamentoPlano";

            Field(x => x.IdComissionamentoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.Desconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CanalPlanoId, nullable: true);
            Field(x => x.TipoSegmentoPlano, nullable: true);
            Field(x => x.SectorActividadePlanoId, nullable: true);
            Field(x => x.CapitalMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CapitalMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.FormaPagamentoPlanoId, nullable: true);
            Field(x => x.PapelPlanoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TaxaComissionamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ComissionamentoId, nullable: true);
            Field(x => x.TaxaAtribuir, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescontoMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescontoMax, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<CanalPlanoType>("canalPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalPlano>(c.Source.CanalPlanoId)));
            FieldAsync<ComissionamentoType>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(c.Source.ComissionamentoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoPlanoType>("formaPagamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamentoPlano>(c.Source.FormaPagamentoPlanoId)));
            FieldAsync<PapelPlanoType>("papelPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPlano>(c.Source.PapelPlanoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<SectorActividadePlanoType>("sectorActividadePlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividadePlano>(c.Source.SectorActividadePlanoId)));
            FieldAsync<TipoSegmentoPlanoType>("tipoSegmentoPlanoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmentoPlano>(c.Source.TipoSegmentoPlano)));
            FieldAsync<ListGraphType<LimiteComissionamentoProdutorType>>("limiteComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdComissionamentoPlano)))));
            
        }
    }

    public class ComissionamentoPlanoInputType : InputObjectGraphType
	{
		public ComissionamentoPlanoInputType()
		{
			// Defining the name of the object
			Name = "comissionamentoPlanoInput";
			
            //Field<StringGraphType>("idComissionamentoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<FloatGraphType>("desconto");
			Field<StringGraphType>("canalPlanoId");
			Field<StringGraphType>("tipoSegmentoPlano");
			Field<StringGraphType>("sectorActividadePlanoId");
			Field<FloatGraphType>("capitalMin");
			Field<FloatGraphType>("capitalMax");
			Field<StringGraphType>("formaPagamentoPlanoId");
			Field<StringGraphType>("papelPlanoId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFim");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("taxaComissionamento");
			Field<StringGraphType>("comissionamentoId");
			Field<FloatGraphType>("taxaAtribuir");
			Field<FloatGraphType>("descontoMin");
			Field<FloatGraphType>("descontoMax");
			Field<CanalPlanoInputType>("canalPlano");
			Field<ComissionamentoInputType>("comissionamento");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoPlanoInputType>("formaPagamentoPlano");
			Field<PapelPlanoInputType>("papelPlano");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<SectorActividadePlanoInputType>("sectorActividadePlano");
			Field<TipoSegmentoPlanoInputType>("tipoSegmentoPlanoNavigation");
			Field<ListGraphType<LimiteComissionamentoProdutorInputType>>("limiteComissionamentoProdutor");
			
		}
	}
}