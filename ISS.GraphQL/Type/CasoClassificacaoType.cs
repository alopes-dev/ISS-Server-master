using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CasoClassificacaoType : ObjectGraphType<CasoClassificacao>
    {
        public CasoClassificacaoType()
        {
            // Defining the name of the object
            Name = "casoClassificacao";

            Field(x => x.IdCasoClassificacao, nullable: true);
            Field(x => x.CodCasoClassificacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.ClassificacaoTipoCasoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DepartamentoId, nullable: true);
            FieldAsync<ClassificacaoTipoCasoType>("classificacaoTipoCaso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoTipoCaso>(c.Source.ClassificacaoTipoCasoId)));
            FieldAsync<DepartamentoType>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(c.Source.DepartamentoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class CasoClassificacaoInputType : InputObjectGraphType
	{
		public CasoClassificacaoInputType()
		{
			// Defining the name of the object
			Name = "casoClassificacaoInput";
			
            //Field<StringGraphType>("idCasoClassificacao");
			Field<StringGraphType>("codCasoClassificacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("classificacaoTipoCasoId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("departamentoId");
			Field<ClassificacaoTipoCasoInputType>("classificacaoTipoCaso");
			Field<DepartamentoInputType>("departamento");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}