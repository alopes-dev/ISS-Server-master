using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RamoQualidadeSeguraType : ObjectGraphType<RamoQualidadeSegura>
    {
        public RamoQualidadeSeguraType()
        {
            // Defining the name of the object
            Name = "ramoQualidadeSegura";

            Field(x => x.IdRamoQualidadeSegura, nullable: true);
            Field(x => x.RamoSeguroId, nullable: true);
            Field(x => x.CodRamoQualidadeSegura, nullable: true);
            Field(x => x.QualidadeSeguraId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<QualidadeSeguraType>("qualidadeSegura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<QualidadeSegura>(c.Source.QualidadeSeguraId)));
            FieldAsync<TipoRamoSeguroType>("ramoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRamoSeguro>(c.Source.RamoSeguroId)));
            
        }
    }

    public class RamoQualidadeSeguraInputType : InputObjectGraphType
	{
		public RamoQualidadeSeguraInputType()
		{
			// Defining the name of the object
			Name = "ramoQualidadeSeguraInput";
			
            //Field<StringGraphType>("idRamoQualidadeSegura");
			Field<StringGraphType>("ramoSeguroId");
			Field<StringGraphType>("codRamoQualidadeSegura");
			Field<StringGraphType>("qualidadeSeguraId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<QualidadeSeguraInputType>("qualidadeSegura");
			Field<TipoRamoSeguroInputType>("ramoSeguro");
			
		}
	}
}