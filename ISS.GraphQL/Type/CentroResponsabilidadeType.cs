using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CentroResponsabilidadeType : ObjectGraphType<CentroResponsabilidade>
    {
        public CentroResponsabilidadeType()
        {
            // Defining the name of the object
            Name = "centroResponsabilidade";

            Field(x => x.IdCentroResponsabilidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.DepartamentoId, nullable: true);
            Field(x => x.SeccaoId, nullable: true);
            Field(x => x.SectorId, nullable: true);
            Field(x => x.AreaId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodCentroResponsabilidade, nullable: true);
            FieldAsync<AreaType>("area", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Area>(c.Source.AreaId)));
            FieldAsync<DepartamentoType>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(c.Source.DepartamentoId)));
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SeccaoType>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(c.Source.SeccaoId)));
            FieldAsync<SectorType>("sector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sector>(c.Source.SectorId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<ContratoType>>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdCentroResponsabilidade)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdCentroResponsabilidade)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdCentroResponsabilidade)))));
            
        }
    }

    public class CentroResponsabilidadeInputType : InputObjectGraphType
	{
		public CentroResponsabilidadeInputType()
		{
			// Defining the name of the object
			Name = "centroResponsabilidadeInput";
			
            //Field<StringGraphType>("idCentroResponsabilidade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("departamentoId");
			Field<StringGraphType>("seccaoId");
			Field<StringGraphType>("sectorId");
			Field<StringGraphType>("areaId");
			Field<StringGraphType>("subContaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("codCentroResponsabilidade");
			Field<AreaInputType>("area");
			Field<DepartamentoInputType>("departamento");
			Field<DireccaoInputType>("direccao");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<SeccaoInputType>("seccao");
			Field<SectorInputType>("sector");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<ContratoInputType>>("contrato");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			
		}
	}
}