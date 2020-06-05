using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AreaType : ObjectGraphType<Area>
    {
        public AreaType()
        {
            // Defining the name of the object
            Name = "area";

            Field(x => x.IdArea, nullable: true);
            Field(x => x.CodArea, nullable: true);
            Field(x => x.Ambito, nullable: true);
            Field(x => x.NomeArea, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<CentroCustoType>>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(x => x.Where(e => e.HasValue(c.Source.IdArea)))));
            FieldAsync<ListGraphType<CentroResponsabilidadeType>>("centroResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdArea)))));
            FieldAsync<ListGraphType<CompetenciaAreaType>>("competenciaArea", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CompetenciaArea>(x => x.Where(e => e.HasValue(c.Source.IdArea)))));
            FieldAsync<ListGraphType<FuncionarioType>>("funcionario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(x => x.Where(e => e.HasValue(c.Source.IdArea)))));
            FieldAsync<ListGraphType<ObjectivosAreaType>>("objectivosArea", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectivosArea>(x => x.Where(e => e.HasValue(c.Source.IdArea)))));
            FieldAsync<ListGraphType<OperacoesCrudpessoaType>>("operacoesCrudpessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesCrudpessoa>(x => x.Where(e => e.HasValue(c.Source.IdArea)))));
            
        }
    }

    public class AreaInputType : InputObjectGraphType
	{
		public AreaInputType()
		{
			// Defining the name of the object
			Name = "areaInput";
			
            //Field<StringGraphType>("idArea");
			Field<StringGraphType>("codArea");
			Field<StringGraphType>("ambito");
			Field<StringGraphType>("nomeArea");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("subContaId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<CentroCustoInputType>>("centroCusto");
			Field<ListGraphType<CentroResponsabilidadeInputType>>("centroResponsabilidade");
			Field<ListGraphType<CompetenciaAreaInputType>>("competenciaArea");
			Field<ListGraphType<FuncionarioInputType>>("funcionario");
			Field<ListGraphType<ObjectivosAreaInputType>>("objectivosArea");
			Field<ListGraphType<OperacoesCrudpessoaInputType>>("operacoesCrudpessoa");
			
		}
	}
}