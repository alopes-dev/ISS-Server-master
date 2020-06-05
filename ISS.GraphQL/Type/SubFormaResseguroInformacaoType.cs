using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubFormaResseguroInformacaoType : ObjectGraphType<SubFormaResseguroInformacao>
    {
        public SubFormaResseguroInformacaoType()
        {
            // Defining the name of the object
            Name = "subFormaResseguroInformacao";

            Field(x => x.IdIsubFormaFormaResseguroInformacao, nullable: true);
            Field(x => x.Cedencia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorLiquido, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TotalLiquido, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.AnoTratado, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Tratado, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodSubFormaResseguroInformacao, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ComissaoId, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.SubFormaResseguroId, nullable: true);
            FieldAsync<ComissaoType>("comissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissao>(c.Source.ComissaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            FieldAsync<ListGraphType<TiposContratosResseguroInformacoesTiposContratosResseguroType>>("tiposContratosResseguroInformacoesTiposContratosResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TiposContratosResseguroInformacoesTiposContratosResseguro>(x => x.Where(e => e.HasValue(c.Source.IdIsubFormaFormaResseguroInformacao)))));
            
        }
    }

    public class SubFormaResseguroInformacaoInputType : InputObjectGraphType
	{
		public SubFormaResseguroInformacaoInputType()
		{
			// Defining the name of the object
			Name = "subFormaResseguroInformacaoInput";
			
            //Field<StringGraphType>("idIsubFormaFormaResseguroInformacao");
			Field<FloatGraphType>("cedencia");
			Field<FloatGraphType>("valorLiquido");
			Field<FloatGraphType>("totalLiquido");
			Field<StringGraphType>("moedaId");
			Field<DateTimeGraphType>("anoTratado");
			Field<StringGraphType>("tratado");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codSubFormaResseguroInformacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("comissaoId");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("subFormaResseguroId");
			Field<ComissaoInputType>("comissao");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<SinistroInputType>("sinistro");
			Field<ListGraphType<TiposContratosResseguroInformacoesTiposContratosResseguroInputType>>("tiposContratosResseguroInformacoesTiposContratosResseguro");
			
		}
	}
}