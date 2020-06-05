using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrejuizoSofridoVeiculoTerceiroType : ObjectGraphType<PrejuizoSofridoVeiculoTerceiro>
    {
        public PrejuizoSofridoVeiculoTerceiroType()
        {
            // Defining the name of the object
            Name = "prejuizoSofridoVeiculoTerceiro";

            Field(x => x.IdPrejuizoSofridoVeiculoTerceiro, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.CodPrejuizoSofridoVeiculoTerceiro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class PrejuizoSofridoVeiculoTerceiroInputType : InputObjectGraphType
	{
		public PrejuizoSofridoVeiculoTerceiroInputType()
		{
			// Defining the name of the object
			Name = "prejuizoSofridoVeiculoTerceiroInput";
			
            //Field<StringGraphType>("idPrejuizoSofridoVeiculoTerceiro");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("codPrejuizoSofridoVeiculoTerceiro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}