using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoDesvalorizacaoType : ObjectGraphType<TipoDesvalorizacao>
    {
        public TipoDesvalorizacaoType()
        {
            // Defining the name of the object
            Name = "tipoDesvalorizacao";

            Field(x => x.IdTipoDesvalorizacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoRamoSeguroId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<TipoRamoSeguroType>("tipoRamoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRamoSeguro>(c.Source.TipoRamoSeguroId)));
            FieldAsync<ListGraphType<SubTipoDesvalorizacaoType>>("subTipoDesvalorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTipoDesvalorizacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoDesvalorizacao)))));
            
        }
    }

    public class TipoDesvalorizacaoInputType : InputObjectGraphType
	{
		public TipoDesvalorizacaoInputType()
		{
			// Defining the name of the object
			Name = "tipoDesvalorizacaoInput";
			
            //Field<StringGraphType>("idTipoDesvalorizacao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("tipoRamoSeguroId");
			Field<StringGraphType>("estadoId");
			Field<TipoRamoSeguroInputType>("tipoRamoSeguro");
			Field<ListGraphType<SubTipoDesvalorizacaoInputType>>("subTipoDesvalorizacao");
			
		}
	}
}