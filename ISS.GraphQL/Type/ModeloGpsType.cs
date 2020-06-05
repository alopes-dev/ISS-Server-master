using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModeloGpsType : ObjectGraphType<ModeloGps>
    {
        public ModeloGpsType()
        {
            // Defining the name of the object
            Name = "modeloGps";

            Field(x => x.IdModeloGps, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.MarcaGpsId, nullable: true);
            Field(x => x.CodModeloGps, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MarcaGpsType>("marcaGps", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MarcaGps>(c.Source.MarcaGpsId)));
            FieldAsync<ListGraphType<GpsautomovelType>>("gpsautomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Gpsautomovel>(x => x.Where(e => e.HasValue(c.Source.IdModeloGps)))));
            
        }
    }

    public class ModeloGpsInputType : InputObjectGraphType
	{
		public ModeloGpsInputType()
		{
			// Defining the name of the object
			Name = "modeloGpsInput";
			
            //Field<StringGraphType>("idModeloGps");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("marcaGpsId");
			Field<StringGraphType>("codModeloGps");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<MarcaGpsInputType>("marcaGps");
			Field<ListGraphType<GpsautomovelInputType>>("gpsautomovel");
			
		}
	}
}