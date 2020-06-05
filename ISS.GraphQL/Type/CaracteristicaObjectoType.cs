using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CaracteristicaObjectoType : ObjectGraphType<CaracteristicaObjecto>
    {
        public CaracteristicaObjectoType()
        {
            // Defining the name of the object
            Name = "caracteristicaObjecto";

            Field(x => x.IdCaracteristicaObjecto, nullable: true);
            Field(x => x.ObjectoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Valor, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaracteristicaClassificacaoId, nullable: true);
            FieldAsync<CaracteristicaClassificacaoType>("caracteristicaClassificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicaClassificacao>(c.Source.CaracteristicaClassificacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ObjectoSeguradoType>("objecto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoSegurado>(c.Source.ObjectoId)));
            
        }
    }

    public class CaracteristicaObjectoInputType : InputObjectGraphType
	{
		public CaracteristicaObjectoInputType()
		{
			// Defining the name of the object
			Name = "caracteristicaObjectoInput";
			
            //Field<StringGraphType>("idCaracteristicaObjecto");
			Field<StringGraphType>("objectoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("valor");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caracteristicaClassificacaoId");
			Field<CaracteristicaClassificacaoInputType>("caracteristicaClassificacao");
			Field<EstadoInputType>("estado");
			Field<ObjectoSeguradoInputType>("objecto");
			
		}
	}
}