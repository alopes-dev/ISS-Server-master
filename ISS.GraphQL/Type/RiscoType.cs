using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RiscoType : ObjectGraphType<Risco>
    {
        public RiscoType()
        {
            // Defining the name of the object
            Name = "risco";

            Field(x => x.IdRisco, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.CodRisco, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Agravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Descricao, nullable: true);
            Field(x => x.RiscoPaiId, nullable: true);
            Field(x => x.TipoRiscoId, nullable: true);
            Field(x => x.Nota, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<RiscoType>("riscoPai", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Risco>(c.Source.RiscoPaiId)));
            FieldAsync<TipoRiscoType>("tipoRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRisco>(c.Source.TipoRiscoId)));
            FieldAsync<ListGraphType<ExclusoesType>>("exclusoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exclusoes>(x => x.Where(e => e.HasValue(c.Source.IdRisco)))));
            FieldAsync<ListGraphType<RiscoType>>("inverseRiscoPai", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Risco>(x => x.Where(e => e.HasValue(c.Source.IdRisco)))));
            FieldAsync<ListGraphType<RiscoOutraSeguradoraContratoType>>("riscoOutraSeguradoraContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RiscoOutraSeguradoraContrato>(x => x.Where(e => e.HasValue(c.Source.IdRisco)))));
            FieldAsync<ListGraphType<SubRiscoType>>("subRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubRisco>(x => x.Where(e => e.HasValue(c.Source.IdRisco)))));
            
        }
    }

    public class RiscoInputType : InputObjectGraphType
	{
		public RiscoInputType()
		{
			// Defining the name of the object
			Name = "riscoInput";
			
            //Field<StringGraphType>("idRisco");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("codRisco");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<FloatGraphType>("agravamento");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("riscoPaiId");
			Field<StringGraphType>("tipoRiscoId");
			Field<StringGraphType>("nota");
			Field<StringGraphType>("planoProdutoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ProdutoInputType>("produto");
			Field<RiscoInputType>("riscoPai");
			Field<TipoRiscoInputType>("tipoRisco");
			Field<ListGraphType<ExclusoesInputType>>("exclusoes");
			Field<ListGraphType<RiscoInputType>>("inverseRiscoPai");
			Field<ListGraphType<RiscoOutraSeguradoraContratoInputType>>("riscoOutraSeguradoraContrato");
			Field<ListGraphType<SubRiscoInputType>>("subRisco");
			
		}
	}
}