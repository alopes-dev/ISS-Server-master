using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModeloMapaType : ObjectGraphType<ModeloMapa>
    {
        public ModeloMapaType()
        {
            // Defining the name of the object
            Name = "modeloMapa";

            Field(x => x.IdModeloMapa, nullable: true);
            Field(x => x.CodModeloMapa, nullable: true);
            Field(x => x.NomeMapa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.OrgaoRegularizadorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<OrgaoRegularizadorType>("orgaoRegularizador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OrgaoRegularizador>(c.Source.OrgaoRegularizadorId)));
            FieldAsync<ListGraphType<MapaType>>("mapa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Mapa>(x => x.Where(e => e.HasValue(c.Source.IdModeloMapa)))));
            
        }
    }

    public class ModeloMapaInputType : InputObjectGraphType
	{
		public ModeloMapaInputType()
		{
			// Defining the name of the object
			Name = "modeloMapaInput";
			
            //Field<StringGraphType>("idModeloMapa");
			Field<StringGraphType>("codModeloMapa");
			Field<StringGraphType>("nomeMapa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("orgaoRegularizadorId");
			Field<EstadoInputType>("estado");
			Field<OrgaoRegularizadorInputType>("orgaoRegularizador");
			Field<ListGraphType<MapaInputType>>("mapa");
			
		}
	}
}