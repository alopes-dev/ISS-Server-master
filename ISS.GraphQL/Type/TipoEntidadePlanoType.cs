using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoEntidadePlanoType : ObjectGraphType<TipoEntidadePlano>
    {
        public TipoEntidadePlanoType()
        {
            // Defining the name of the object
            Name = "tipoEntidadePlano";

            Field(x => x.IdTipoEntidadePlano, nullable: true);
            Field(x => x.TipoEntidadaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoEntidadeType>("tipoEntidada", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEntidade>(c.Source.TipoEntidadaId)));
            
        }
    }

    public class TipoEntidadePlanoInputType : InputObjectGraphType
	{
		public TipoEntidadePlanoInputType()
		{
			// Defining the name of the object
			Name = "tipoEntidadePlanoInput";
			
            //Field<StringGraphType>("idTipoEntidadePlano");
			Field<StringGraphType>("tipoEntidadaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("planoProdutoId");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoEntidadeInputType>("tipoEntidada");
			
		}
	}
}