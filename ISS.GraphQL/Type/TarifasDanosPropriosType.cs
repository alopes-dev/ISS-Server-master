using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarifasDanosPropriosType : ObjectGraphType<TarifasDanosProprios>
    {
        public TarifasDanosPropriosType()
        {
            // Defining the name of the object
            Name = "tarifasDanosProprios";

            Field(x => x.IdTarifa, nullable: true);
            Field(x => x.RiscoIii, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.RiscoIv, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.RiscoV, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ClassificacaoAutomovelId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.CodTarifasDanosProprios, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<ClassificacaoAutomovelType>("classificacaoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAutomovel>(c.Source.ClassificacaoAutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            
        }
    }

    public class TarifasDanosPropriosInputType : InputObjectGraphType
	{
		public TarifasDanosPropriosInputType()
		{
			// Defining the name of the object
			Name = "tarifasDanosPropriosInput";
			
            //Field<StringGraphType>("idTarifa");
			Field<FloatGraphType>("riscoIii");
			Field<FloatGraphType>("riscoIv");
			Field<FloatGraphType>("riscoV");
			Field<StringGraphType>("classificacaoAutomovelId");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("codTarifasDanosProprios");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<BooleanGraphType>("contabiliza");
			Field<ClassificacaoAutomovelInputType>("classificacaoAutomovel");
			Field<EstadoInputType>("estado");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PlanoContasInputType>("subConta");
			
		}
	}
}