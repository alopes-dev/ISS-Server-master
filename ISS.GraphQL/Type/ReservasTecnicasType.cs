using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ReservasTecnicasType : ObjectGraphType<ReservasTecnicas>
    {
        public ReservasTecnicasType()
        {
            // Defining the name of the object
            Name = "reservasTecnicas";

            Field(x => x.IdReserva, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodReservasTecnicas, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IsIndirecto, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CanalId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.TipoProvisaoId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoOperacaoId, nullable: true);
            Field(x => x.TipoRamoSeguroId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<TipoProvisaoType>("tipoProvisao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoProvisao>(c.Source.TipoProvisaoId)));
            FieldAsync<TipoRamoSeguroType>("tipoRamoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRamoSeguro>(c.Source.TipoRamoSeguroId)));
            
        }
    }

    public class ReservasTecnicasInputType : InputObjectGraphType
	{
		public ReservasTecnicasInputType()
		{
			// Defining the name of the object
			Name = "reservasTecnicasInput";
			
            //Field<StringGraphType>("idReserva");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codReservasTecnicas");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("isTaxa");
			Field<BooleanGraphType>("isIndirecto");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("tipoProvisaoId");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("apoliceId");
			Field<FloatGraphType>("taxa");
			Field<StringGraphType>("tipoOperacaoId");
			Field<StringGraphType>("tipoRamoSeguroId");
			Field<ApoliceInputType>("apolice");
			Field<CanalInputType>("canal");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<MoedaInputType>("moeda");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<TipoProvisaoInputType>("tipoProvisao");
			Field<TipoRamoSeguroInputType>("tipoRamoSeguro");
			
		}
	}
}