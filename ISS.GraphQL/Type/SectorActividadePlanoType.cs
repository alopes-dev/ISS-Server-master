using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SectorActividadePlanoType : ObjectGraphType<SectorActividadePlano>
    {
        public SectorActividadePlanoType()
        {
            // Defining the name of the object
            Name = "sectorActividadePlano";

            Field(x => x.IdSectorActividadePlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.SectorActividadeId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodSectorActividadePlano, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<SectorActividadeType>("sectorActividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorActividade>(c.Source.SectorActividadeId)));
            FieldAsync<ListGraphType<ComissionamentoPlanoType>>("comissionamentoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdSectorActividadePlano)))));
            FieldAsync<ListGraphType<CriterioPlanoType>>("criterioPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CriterioPlano>(x => x.Where(e => e.HasValue(c.Source.IdSectorActividadePlano)))));
            FieldAsync<ListGraphType<LimiteComissionamentoPlanoType>>("limiteComissionamentoPlanoSectorActividadePlano1", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdSectorActividadePlano)))));
            FieldAsync<ListGraphType<LimiteComissionamentoPlanoType>>("limiteComissionamentoPlanoSectorActividadePlanoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoPlano>(x => x.Where(e => e.HasValue(c.Source.IdSectorActividadePlano)))));
            FieldAsync<ListGraphType<LimiteComissionamentoProdutorType>>("limiteComissionamentoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteComissionamentoProdutor>(x => x.Where(e => e.HasValue(c.Source.IdSectorActividadePlano)))));
            
        }
    }

    public class SectorActividadePlanoInputType : InputObjectGraphType
	{
		public SectorActividadePlanoInputType()
		{
			// Defining the name of the object
			Name = "sectorActividadePlanoInput";
			
            //Field<StringGraphType>("idSectorActividadePlano");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("sectorActividadeId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codSectorActividadePlano");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<SectorActividadeInputType>("sectorActividade");
			Field<ListGraphType<ComissionamentoPlanoInputType>>("comissionamentoPlano");
			Field<ListGraphType<CriterioPlanoInputType>>("criterioPlano");
			Field<ListGraphType<LimiteComissionamentoPlanoInputType>>("limiteComissionamentoPlanoSectorActividadePlano1");
			Field<ListGraphType<LimiteComissionamentoPlanoInputType>>("limiteComissionamentoPlanoSectorActividadePlanoNavigation");
			Field<ListGraphType<LimiteComissionamentoProdutorInputType>>("limiteComissionamentoProdutor");
			
		}
	}
}