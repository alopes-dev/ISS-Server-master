using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NacionalidadePessoaPlanoType : ObjectGraphType<NacionalidadePessoaPlano>
    {
        public NacionalidadePessoaPlanoType()
        {
            // Defining the name of the object
            Name = "nacionalidadePessoaPlano";

            Field(x => x.IdNacionalidadePessoaPlano, nullable: true);
            Field(x => x.NacionalidadePessoaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodNacionalidadePessoaPlano, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NacionalidadePessoaType>("nacionalidadePessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NacionalidadePessoa>(c.Source.NacionalidadePessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class NacionalidadePessoaPlanoInputType : InputObjectGraphType
	{
		public NacionalidadePessoaPlanoInputType()
		{
			// Defining the name of the object
			Name = "nacionalidadePessoaPlanoInput";
			
            //Field<StringGraphType>("idNacionalidadePessoaPlano");
			Field<StringGraphType>("nacionalidadePessoaId");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codNacionalidadePessoaPlano");
			Field<EstadoInputType>("estado");
			Field<NacionalidadePessoaInputType>("nacionalidadePessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}