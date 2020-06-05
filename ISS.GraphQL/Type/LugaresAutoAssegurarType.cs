using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LugaresAutoAssegurarType : ObjectGraphType<LugaresAutoAssegurar>
    {
        public LugaresAutoAssegurarType()
        {
            // Defining the name of the object
            Name = "lugaresAutoAssegurar";

            Field(x => x.IdLugaresAutoAssegurar, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TaxaAgravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MinLugares, nullable: true, type: typeof(IntGraphType));
            Field(x => x.MaxLugares, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodLugaresAutoAssegurar, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ClassificacaoAutomovelId, nullable: true);
            FieldAsync<ClassificacaoAutomovelType>("classificacaoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAutomovel>(c.Source.ClassificacaoAutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdLugaresAutoAssegurar)))));
            
        }
    }

    public class LugaresAutoAssegurarInputType : InputObjectGraphType
	{
		public LugaresAutoAssegurarInputType()
		{
			// Defining the name of the object
			Name = "lugaresAutoAssegurarInput";
			
            //Field<StringGraphType>("idLugaresAutoAssegurar");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("taxaAgravamento");
			Field<IntGraphType>("minLugares");
			Field<IntGraphType>("maxLugares");
			Field<StringGraphType>("codLugaresAutoAssegurar");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("classificacaoAutomovelId");
			Field<ClassificacaoAutomovelInputType>("classificacaoAutomovel");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			
		}
	}
}