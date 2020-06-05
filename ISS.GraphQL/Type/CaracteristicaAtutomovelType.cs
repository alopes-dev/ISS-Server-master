using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CaracteristicaAtutomovelType : ObjectGraphType<CaracteristicaAtutomovel>
    {
        public CaracteristicaAtutomovelType()
        {
            // Defining the name of the object
            Name = "caracteristicaAtutomovel";

            Field(x => x.IdCaracteristicaAtutomovel, nullable: true);
            Field(x => x.Altura, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Comprimento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodCaracteristicaAtutomovel, nullable: true);
            Field(x => x.CaacidadeMaxMovimento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumJanelasElectrica, nullable: true, type: typeof(IntGraphType));
            Field(x => x.PesoBruto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PesoBrutoReboque, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumLugares, nullable: true, type: typeof(IntGraphType));
            Field(x => x.AutomovelId, nullable: true);
            Field(x => x.Tara, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Potencia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumAirBags, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ComputadorInstalado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.SistemaAquecimentoAuxiliar, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.TipoGaragemId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoOucupanteId, nullable: true);
            Field(x => x.Versao, nullable: true);
            Field(x => x.ValorAltifalante, nullable: true);
            Field(x => x.ValorBancosPele, nullable: true);
            Field(x => x.ValorRadio, nullable: true);
            Field(x => x.ValorRadioEmCd, nullable: true);
            Field(x => x.ValorJantesLigaLeve, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            FieldAsync<TipoGaragemType>("tipoGaragem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoGaragem>(c.Source.TipoGaragemId)));
            FieldAsync<TipoOucupantesType>("tipoOucupante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOucupantes>(c.Source.TipoOucupanteId)));
            
        }
    }

    public class CaracteristicaAtutomovelInputType : InputObjectGraphType
	{
		public CaracteristicaAtutomovelInputType()
		{
			// Defining the name of the object
			Name = "caracteristicaAtutomovelInput";
			
            //Field<StringGraphType>("idCaracteristicaAtutomovel");
			Field<FloatGraphType>("altura");
			Field<FloatGraphType>("comprimento");
			Field<StringGraphType>("codCaracteristicaAtutomovel");
			Field<FloatGraphType>("caacidadeMaxMovimento");
			Field<IntGraphType>("numJanelasElectrica");
			Field<FloatGraphType>("pesoBruto");
			Field<FloatGraphType>("pesoBrutoReboque");
			Field<IntGraphType>("numLugares");
			Field<StringGraphType>("automovelId");
			Field<FloatGraphType>("tara");
			Field<FloatGraphType>("potencia");
			Field<IntGraphType>("numAirBags");
			Field<BooleanGraphType>("computadorInstalado");
			Field<BooleanGraphType>("sistemaAquecimentoAuxiliar");
			Field<StringGraphType>("tipoGaragemId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("tipoOucupanteId");
			Field<StringGraphType>("versao");
			Field<StringGraphType>("valorAltifalante");
			Field<StringGraphType>("valorBancosPele");
			Field<StringGraphType>("valorRadio");
			Field<StringGraphType>("valorRadioEmCd");
			Field<StringGraphType>("valorJantesLigaLeve");
			Field<AutomovelInputType>("automovel");
			Field<TipoGaragemInputType>("tipoGaragem");
			Field<TipoOucupantesInputType>("tipoOucupante");
			
		}
	}
}