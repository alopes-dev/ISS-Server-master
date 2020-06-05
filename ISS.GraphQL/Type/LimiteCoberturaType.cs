using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LimiteCoberturaType : ObjectGraphType<LimiteCobertura>
    {
        public LimiteCoberturaType()
        {
            // Defining the name of the object
            Name = "limiteCobertura";

            Field(x => x.IdLimiteCobertura, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ValorBase, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataHoraUltimaRevisao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ExtencaoLimitePadrao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CoberturaProdutoId, nullable: true);
            Field(x => x.QuantidadeLimite, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodLimiteCobertura, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CoberturaType>("coberturaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaProdutoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class LimiteCoberturaInputType : InputObjectGraphType
	{
		public LimiteCoberturaInputType()
		{
			// Defining the name of the object
			Name = "limiteCoberturaInput";
			
            //Field<StringGraphType>("idLimiteCobertura");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("valorBase");
			Field<DateTimeGraphType>("dataHoraUltimaRevisao");
			Field<BooleanGraphType>("extencaoLimitePadrao");
			Field<StringGraphType>("coberturaProdutoId");
			Field<IntGraphType>("quantidadeLimite");
			Field<StringGraphType>("codLimiteCobertura");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CoberturaInputType>("coberturaProduto");
			Field<EstadoInputType>("estado");
			
		}
	}
}