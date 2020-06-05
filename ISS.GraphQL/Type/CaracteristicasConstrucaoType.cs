using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CaracteristicasConstrucaoType : ObjectGraphType<CaracteristicasConstrucao>
    {
        public CaracteristicasConstrucaoType()
        {
            // Defining the name of the object
            Name = "caracteristicasConstrucao";

            Field(x => x.IdCaracteristicasConstrucao, nullable: true);
            Field(x => x.DimensaoOcupadaPeloSegurado, nullable: true);
            Field(x => x.UtilidadePredio, nullable: true);
            Field(x => x.ReparacaoTerreno, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.NumSalasUsadaNegocio, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ClientesNegocioVisitaPropriedade, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DescricaoNegocio, nullable: true);
            Field(x => x.BensGuardadosPropriedade, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PossuiGuarda, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Alarme, nullable: true, type: typeof(BooleanGraphType));
            //FieldAsync<ByteType>("numeroPisosOcupados", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Byte>(c.Source.IdCaracteristicasConstrucao)));
            Field(x => x.SinalDefeito, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.AlgumaAreaArrendada, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.NumVeiculoGaragem, nullable: true, type: typeof(IntGraphType));
            Field(x => x.EntradaBloqueavelSeparada, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataUltimaInspecaoCabos, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ConstrucaoId, nullable: true);
            Field(x => x.CodCaracteristicasConstrucao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ConstrucaoType>("construcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Construcao>(c.Source.ConstrucaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CofreType>>("cofre", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cofre>(x => x.Where(e => e.HasValue(c.Source.IdCaracteristicasConstrucao)))));
            
        }
    }

    public class CaracteristicasConstrucaoInputType : InputObjectGraphType
	{
		public CaracteristicasConstrucaoInputType()
		{
			// Defining the name of the object
			Name = "caracteristicasConstrucaoInput";
			
            //Field<StringGraphType>("idCaracteristicasConstrucao");
			Field<StringGraphType>("dimensaoOcupadaPeloSegurado");
			Field<StringGraphType>("utilidadePredio");
			Field<BooleanGraphType>("reparacaoTerreno");
			Field<IntGraphType>("numSalasUsadaNegocio");
			Field<BooleanGraphType>("clientesNegocioVisitaPropriedade");
			Field<StringGraphType>("descricaoNegocio");
			Field<BooleanGraphType>("bensGuardadosPropriedade");
			Field<BooleanGraphType>("possuiGuarda");
			Field<BooleanGraphType>("alarme");
			//Field<ByteInputType>("numeroPisosOcupados");
			Field<BooleanGraphType>("sinalDefeito");
			Field<BooleanGraphType>("algumaAreaArrendada");
			Field<IntGraphType>("numVeiculoGaragem");
			Field<BooleanGraphType>("entradaBloqueavelSeparada");
			Field<DateTimeGraphType>("dataUltimaInspecaoCabos");
			Field<StringGraphType>("construcaoId");
			Field<StringGraphType>("codCaracteristicasConstrucao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<ConstrucaoInputType>("construcao");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CofreInputType>>("cofre");
			
		}
	}
}