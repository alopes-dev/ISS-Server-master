using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ReembolsoTratamentoDentarioType : ObjectGraphType<ReembolsoTratamentoDentario>
    {
        public ReembolsoTratamentoDentarioType()
        {
            // Defining the name of the object
            Name = "reembolsoTratamentoDentario";

            Field(x => x.IdReembolsoTratamentoDentario, nullable: true);
            Field(x => x.CodReembolsoTratamentoDentario, nullable: true);
            Field(x => x.PessoaSegura, nullable: true);
            Field(x => x.GrauParentesco, nullable: true);
            Field(x => x.Estomatologista, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.RazaoColocacao, nullable: true);
            Field(x => x.DataColocacaoAnterior, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DescricaoTratamentoDentario, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<DescricaoTratamentoDentarioType>("descricaoTratamentoDentarioNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescricaoTratamentoDentario>(c.Source.DescricaoTratamentoDentario)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FuncionarioType>("estomatologistaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.Estomatologista)));
            FieldAsync<GrauParentescoType>("grauParentescoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GrauParentesco>(c.Source.GrauParentesco)));
            FieldAsync<PessoaType>("pessoaSeguraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaSegura)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class ReembolsoTratamentoDentarioInputType : InputObjectGraphType
	{
		public ReembolsoTratamentoDentarioInputType()
		{
			// Defining the name of the object
			Name = "reembolsoTratamentoDentarioInput";
			
            //Field<StringGraphType>("idReembolsoTratamentoDentario");
			Field<StringGraphType>("codReembolsoTratamentoDentario");
			Field<StringGraphType>("pessoaSegura");
			Field<StringGraphType>("grauParentesco");
			Field<StringGraphType>("estomatologista");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("razaoColocacao");
			Field<DateTimeGraphType>("dataColocacaoAnterior");
			Field<StringGraphType>("descricaoTratamentoDentario");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<DescricaoTratamentoDentarioInputType>("descricaoTratamentoDentarioNavigation");
			Field<EstadoInputType>("estado");
			Field<FuncionarioInputType>("estomatologistaNavigation");
			Field<GrauParentescoInputType>("grauParentescoNavigation");
			Field<PessoaInputType>("pessoaSeguraNavigation");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}