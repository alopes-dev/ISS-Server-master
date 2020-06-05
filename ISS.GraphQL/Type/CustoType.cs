using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CustoType : ObjectGraphType<Custo>
    {
        public CustoType()
        {
            // Defining the name of the object
            Name = "custo";

            Field(x => x.IdCusto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataHoraEfectividade, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorMonetario, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMonetarioIncluindoImposto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMonetarioExcluindoImposto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PercentagemDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ReparacaoId, nullable: true);
            Field(x => x.Imposto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ReparacaoType>("reparacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Reparacao>(c.Source.ReparacaoId)));
            FieldAsync<ListGraphType<PerdaType>>("perda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perda>(x => x.Where(e => e.HasValue(c.Source.IdCusto)))));
            
        }
    }

    public class CustoInputType : InputObjectGraphType
	{
		public CustoInputType()
		{
			// Defining the name of the object
			Name = "custoInput";
			
            //Field<StringGraphType>("idCusto");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataHoraEfectividade");
			Field<FloatGraphType>("valorMonetario");
			Field<FloatGraphType>("valorMonetarioIncluindoImposto");
			Field<FloatGraphType>("valorMonetarioExcluindoImposto");
			Field<FloatGraphType>("percentagemDesconto");
			Field<StringGraphType>("reparacaoId");
			Field<FloatGraphType>("imposto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ReparacaoInputType>("reparacao");
			Field<ListGraphType<PerdaInputType>>("perda");
			
		}
	}
}