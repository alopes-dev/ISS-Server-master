using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class IndiceVelocidadePneuType : ObjectGraphType<IndiceVelocidadePneu>
    {
        public IndiceVelocidadePneuType()
        {
            // Defining the name of the object
            Name = "indiceVelocidadePneu";

            Field(x => x.IdIndiceVelocidadePneu, nullable: true);
            Field(x => x.CodIndiceVelocidadePneu, nullable: true);
            Field(x => x.Quilometragem, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PneuType>>("pneu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pneu>(x => x.Where(e => e.HasValue(c.Source.IdIndiceVelocidadePneu)))));
            
        }
    }

    public class IndiceVelocidadePneuInputType : InputObjectGraphType
	{
		public IndiceVelocidadePneuInputType()
		{
			// Defining the name of the object
			Name = "indiceVelocidadePneuInput";
			
            //Field<StringGraphType>("idIndiceVelocidadePneu");
			Field<StringGraphType>("codIndiceVelocidadePneu");
			Field<StringGraphType>("quilometragem");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PneuInputType>>("pneu");
			
		}
	}
}