using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GpsautomovelType : ObjectGraphType<Gpsautomovel>
    {
        public GpsautomovelType()
        {
            // Defining the name of the object
            Name = "gpsautomovel";

            Field(x => x.IdGpsautomovel, nullable: true);
            Field(x => x.NumSerie, nullable: true);
            Field(x => x.DataFabrico, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PaisOrigemId, nullable: true);
            Field(x => x.ModeloGpsId, nullable: true);
            Field(x => x.AutomovelId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ModeloGpsType>("modeloGps", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModeloGps>(c.Source.ModeloGpsId)));
            FieldAsync<PaisType>("paisOrigem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisOrigemId)));
            
        }
    }

    public class GpsautomovelInputType : InputObjectGraphType
	{
		public GpsautomovelInputType()
		{
			// Defining the name of the object
			Name = "gpsautomovelInput";
			
            //Field<StringGraphType>("idGpsautomovel");
			Field<StringGraphType>("numSerie");
			Field<DateTimeGraphType>("dataFabrico");
			Field<StringGraphType>("paisOrigemId");
			Field<StringGraphType>("modeloGpsId");
			Field<StringGraphType>("automovelId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<AutomovelInputType>("automovel");
			Field<EstadoInputType>("estado");
			Field<ModeloGpsInputType>("modeloGps");
			Field<PaisInputType>("paisOrigem");
			
		}
	}
}