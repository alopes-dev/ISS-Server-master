using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CofreType : ObjectGraphType<Cofre>
    {
        public CofreType()
        {
            // Defining the name of the object
            Name = "cofre";

            Field(x => x.IdCofre, nullable: true);
            Field(x => x.TimeLock, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.RelockingDevice, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Alarme, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.NumSerial, nullable: true);
            Field(x => x.ConteudoCofre, nullable: true);
            Field(x => x.Altura, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Largura, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Comprimento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Peso, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Fabricante, nullable: true);
            Field(x => x.ClasseCofreId, nullable: true);
            Field(x => x.TipoCofreId, nullable: true);
            Field(x => x.CaracteristicasConstrucaoId, nullable: true);
            Field(x => x.CodCofre, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<CaracteristicasConstrucaoType>("caracteristicasConstrucao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicasConstrucao>(c.Source.CaracteristicasConstrucaoId)));
            FieldAsync<ClasseCofreType>("classeCofre", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClasseCofre>(c.Source.ClasseCofreId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCofreType>("tipoCofre", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCofre>(c.Source.TipoCofreId)));
            
        }
    }

    public class CofreInputType : InputObjectGraphType
	{
		public CofreInputType()
		{
			// Defining the name of the object
			Name = "cofreInput";
			
            //Field<StringGraphType>("idCofre");
			Field<BooleanGraphType>("timeLock");
			Field<BooleanGraphType>("relockingDevice");
			Field<BooleanGraphType>("alarme");
			Field<StringGraphType>("numSerial");
			Field<StringGraphType>("conteudoCofre");
			Field<FloatGraphType>("altura");
			Field<FloatGraphType>("largura");
			Field<FloatGraphType>("comprimento");
			Field<FloatGraphType>("peso");
			Field<StringGraphType>("fabricante");
			Field<StringGraphType>("classeCofreId");
			Field<StringGraphType>("tipoCofreId");
			Field<StringGraphType>("caracteristicasConstrucaoId");
			Field<StringGraphType>("codCofre");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<CaracteristicasConstrucaoInputType>("caracteristicasConstrucao");
			Field<ClasseCofreInputType>("classeCofre");
			Field<EstadoInputType>("estado");
			Field<TipoCofreInputType>("tipoCofre");
			
		}
	}
}