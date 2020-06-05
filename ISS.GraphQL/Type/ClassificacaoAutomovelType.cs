using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoAutomovelType : ObjectGraphType<ClassificacaoAutomovel>
    {
        public ClassificacaoAutomovelType()
        {
            // Defining the name of the object
            Name = "classificacaoAutomovel";

            Field(x => x.IdClassificacaoAutomovel, nullable: true);
            Field(x => x.CodClassificacaoAutomovel, nullable: true);
            Field(x => x.Categoria, nullable: true);
            Field(x => x.Codigo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CategoriaId, nullable: true);
            FieldAsync<CategoriaType>("categoriaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Categoria>(c.Source.CategoriaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAutomovel)))));
            FieldAsync<ListGraphType<CapitalPremioAutomovelType>>("capitalPremioAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CapitalPremioAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAutomovel)))));
            FieldAsync<ListGraphType<CapitalSeguroAutomovelType>>("capitalSeguroAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CapitalSeguroAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAutomovel)))));
            FieldAsync<ListGraphType<CilindragemAutomovelType>>("cilindragemAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CilindragemAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAutomovel)))));
            FieldAsync<ListGraphType<LugaresAutoAssegurarType>>("lugaresAutoAssegurar", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LugaresAutoAssegurar>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAutomovel)))));
            FieldAsync<ListGraphType<PesoAutomovelType>>("pesoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PesoAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAutomovel)))));
            FieldAsync<ListGraphType<SinistroType>>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAutomovel)))));
            FieldAsync<ListGraphType<TarifasDanosPropriosType>>("tarifasDanosProprios", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasDanosProprios>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAutomovel)))));
            FieldAsync<ListGraphType<TipoTarifaType>>("tipoTarifa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTarifa>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAutomovel)))));
            FieldAsync<ListGraphType<ValorCoberturaType>>("valorCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValorCobertura>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAutomovel)))));
            
        }
    }

    public class ClassificacaoAutomovelInputType : InputObjectGraphType
	{
		public ClassificacaoAutomovelInputType()
		{
			// Defining the name of the object
			Name = "classificacaoAutomovelInput";
			
            //Field<StringGraphType>("idClassificacaoAutomovel");
			Field<StringGraphType>("codClassificacaoAutomovel");
			Field<StringGraphType>("categoria");
			Field<StringGraphType>("codigo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("categoriaId");
			Field<CategoriaInputType>("categoriaNavigation");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			Field<ListGraphType<CapitalPremioAutomovelInputType>>("capitalPremioAutomovel");
			Field<ListGraphType<CapitalSeguroAutomovelInputType>>("capitalSeguroAutomovel");
			Field<ListGraphType<CilindragemAutomovelInputType>>("cilindragemAutomovel");
			Field<ListGraphType<LugaresAutoAssegurarInputType>>("lugaresAutoAssegurar");
			Field<ListGraphType<PesoAutomovelInputType>>("pesoAutomovel");
			Field<ListGraphType<SinistroInputType>>("sinistro");
			Field<ListGraphType<TarifasDanosPropriosInputType>>("tarifasDanosProprios");
			Field<ListGraphType<TipoTarifaInputType>>("tipoTarifa");
			Field<ListGraphType<ValorCoberturaInputType>>("valorCobertura");
			
		}
	}
}