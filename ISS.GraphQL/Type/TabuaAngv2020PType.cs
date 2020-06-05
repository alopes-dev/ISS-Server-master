using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TabuaAngv2020PType : ObjectGraphType<TabuaAngv2020P>
    {
        public TabuaAngv2020PType()
        {
            // Defining the name of the object
            Name = "tabuaAngv2020P";

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
            Field(x => x.CodTabuaAngv2020P, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TabuaAngv2020PInputType : InputObjectGraphType
	{
		public TabuaAngv2020PInputType()
		{
			// Defining the name of the object
			Name = "tabuaAngv2020PInput";
			
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
			Field<StringGraphType>("codTabuaAngv2020P");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}