using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class QualidadeSeguraType : ObjectGraphType<QualidadeSegura>
    {
        public QualidadeSeguraType()
        {
            // Defining the name of the object
            Name = "qualidadeSegura";

            Field(x => x.IdQualidadeSegura, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodQualidadeSegura, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdQualidadeSegura)))));
            FieldAsync<ListGraphType<RamoQualidadeSeguraType>>("ramoQualidadeSegura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RamoQualidadeSegura>(x => x.Where(e => e.HasValue(c.Source.IdQualidadeSegura)))));
            
        }
    }

    public class QualidadeSeguraInputType : InputObjectGraphType
	{
		public QualidadeSeguraInputType()
		{
			// Defining the name of the object
			Name = "qualidadeSeguraInput";
			
            //Field<StringGraphType>("idQualidadeSegura");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codQualidadeSegura");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<RamoQualidadeSeguraInputType>>("ramoQualidadeSegura");
			
		}
	}
}