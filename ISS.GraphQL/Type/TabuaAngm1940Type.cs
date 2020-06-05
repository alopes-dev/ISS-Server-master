using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TabuaAngm1940Type : ObjectGraphType<TabuaAngm1940>
    {
        public TabuaAngm1940Type()
        {
            // Defining the name of the object
            Name = "tabuaAngm1940";

            Field(x => x.IdTabua, nullable: true);
            //FieldAsync<ByteType>("idade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Byte>(c.Source.IdTabua)));
            Field(x => x.MX, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.QX, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DX, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PX, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.IX, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LX, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TX, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EX, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.UX, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodTabuaAngm1940, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TabuaAngm1940InputType : InputObjectGraphType
	{
		public TabuaAngm1940InputType()
		{
			// Defining the name of the object
			Name = "tabuaAngm1940Input";
			
            //Field<StringGraphType>("idTabua");
			//Field<ByteInputType>("idade");
			Field<FloatGraphType>("mX");
			Field<FloatGraphType>("qX");
			Field<FloatGraphType>("dX");
			Field<FloatGraphType>("pX");
			Field<FloatGraphType>("iX");
			Field<FloatGraphType>("lX");
			Field<FloatGraphType>("tX");
			Field<FloatGraphType>("eX");
			Field<FloatGraphType>("uX");
			Field<StringGraphType>("codTabuaAngm1940");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}