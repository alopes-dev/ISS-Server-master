using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DuracaoTipoContratoPlanoType : ObjectGraphType<DuracaoTipoContratoPlano>
    {
        public DuracaoTipoContratoPlanoType()
        {
            // Defining the name of the object
            Name = "duracaoTipoContratoPlano";

            Field(x => x.IdDuracaoTipoContratoPlano, nullable: true);
            Field(x => x.DuracaoTipoContratoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<DuracaoTipoContratoType>("duracaoTipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DuracaoTipoContrato>(c.Source.DuracaoTipoContratoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DuracaoTipoContratoPlanoInputType : InputObjectGraphType
	{
		public DuracaoTipoContratoPlanoInputType()
		{
			// Defining the name of the object
			Name = "duracaoTipoContratoPlanoInput";
			
            //Field<StringGraphType>("idDuracaoTipoContratoPlano");
			Field<StringGraphType>("duracaoTipoContratoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("planoProdutoId");
			Field<DuracaoTipoContratoInputType>("duracaoTipoContrato");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}