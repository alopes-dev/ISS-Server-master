using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FraccionamentoPlanoType : ObjectGraphType<FraccionamentoPlano>
    {
        public FraccionamentoPlanoType()
        {
            // Defining the name of the object
            Name = "fraccionamentoPlano";

            Field(x => x.IdFraccionamentoPlano, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.FraccionamentoId, nullable: true);
            Field(x => x.FormaLiquidacaoPremioId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaLiquidacaoPremioType>("formaLiquidacaoPremio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaLiquidacaoPremio>(c.Source.FormaLiquidacaoPremioId)));
            FieldAsync<FraccionamentoType>("fraccionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fraccionamento>(c.Source.FraccionamentoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class FraccionamentoPlanoInputType : InputObjectGraphType
	{
		public FraccionamentoPlanoInputType()
		{
			// Defining the name of the object
			Name = "fraccionamentoPlanoInput";
			
            //Field<StringGraphType>("idFraccionamentoPlano");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("fraccionamentoId");
			Field<StringGraphType>("formaLiquidacaoPremioId");
			Field<EstadoInputType>("estado");
			Field<FormaLiquidacaoPremioInputType>("formaLiquidacaoPremio");
			Field<FraccionamentoInputType>("fraccionamento");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}