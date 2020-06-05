using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TaxaSinistralidadeType : ObjectGraphType<TaxaSinistralidade>
    {
        public TaxaSinistralidadeType()
        {
            // Defining the name of the object
            Name = "taxaSinistralidade";

            Field(x => x.IdTaxaSinistralidade, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PercentagemMinSinistralidade, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PercentagemMaxSinistralidade, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Obs, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ListGraphType<AgravamentoAcidentesTrabalhoType>>("agravamentoAcidentesTrabalho", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgravamentoAcidentesTrabalho>(x => x.Where(e => e.HasValue(c.Source.IdTaxaSinistralidade)))));
            FieldAsync<ListGraphType<FranquiaInvalidezTemporariaType>>("franquiaInvalidezTemporaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FranquiaInvalidezTemporaria>(x => x.Where(e => e.HasValue(c.Source.IdTaxaSinistralidade)))));
            FieldAsync<ListGraphType<ReducaoPremioAcidentesTrabalhoType>>("reducaoPremioAcidentesTrabalho", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReducaoPremioAcidentesTrabalho>(x => x.Where(e => e.HasValue(c.Source.IdTaxaSinistralidade)))));
            
        }
    }

    public class TaxaSinistralidadeInputType : InputObjectGraphType
	{
		public TaxaSinistralidadeInputType()
		{
			// Defining the name of the object
			Name = "taxaSinistralidadeInput";
			
            //Field<StringGraphType>("idTaxaSinistralidade");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<StringGraphType>("linhaProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("isTaxa");
			Field<FloatGraphType>("percentagemMinSinistralidade");
			Field<FloatGraphType>("percentagemMaxSinistralidade");
			Field<StringGraphType>("obs");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ListGraphType<AgravamentoAcidentesTrabalhoInputType>>("agravamentoAcidentesTrabalho");
			Field<ListGraphType<FranquiaInvalidezTemporariaInputType>>("franquiaInvalidezTemporaria");
			Field<ListGraphType<ReducaoPremioAcidentesTrabalhoInputType>>("reducaoPremioAcidentesTrabalho");
			
		}
	}
}