using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarifasResponsabilidadeCivilType : ObjectGraphType<TarifasResponsabilidadeCivil>
    {
        public TarifasResponsabilidadeCivilType()
        {
            // Defining the name of the object
            Name = "tarifasResponsabilidadeCivil";

            Field(x => x.IdTarifa, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.LimiteMinimoUcf, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoTarifasResponsabilidadeId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.CodTarifasResponsabilidadeCivil, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<TipoTarifasResponsabilidadeType>("tipoTarifasResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTarifasResponsabilidade>(c.Source.TipoTarifasResponsabilidadeId)));
            
        }
    }

    public class TarifasResponsabilidadeCivilInputType : InputObjectGraphType
	{
		public TarifasResponsabilidadeCivilInputType()
		{
			// Defining the name of the object
			Name = "tarifasResponsabilidadeCivilInput";
			
            //Field<StringGraphType>("idTarifa");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("limiteMinimoUcf");
			Field<StringGraphType>("tipoTarifasResponsabilidadeId");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("codTarifasResponsabilidadeCivil");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PlanoContasInputType>("subConta");
			Field<TipoTarifasResponsabilidadeInputType>("tipoTarifasResponsabilidade");
			
		}
	}
}