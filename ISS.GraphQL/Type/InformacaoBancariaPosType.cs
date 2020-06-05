using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class InformacaoBancariaPosType : ObjectGraphType<InformacaoBancariaPos>
    {
        public InformacaoBancariaPosType()
        {
            // Defining the name of the object
            Name = "informacaoBancariaPos";

            Field(x => x.IdInformacaoBancariaPos, nullable: true);
            Field(x => x.InformacaoBancariaId, nullable: true);
            Field(x => x.Posid, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodInformacaoBancariaPos, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<InformacaoBancariaType>("informacaoBancaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(c.Source.InformacaoBancariaId)));
            FieldAsync<PosType>("pos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pos>(c.Source.Posid)));
            
        }
    }

    public class InformacaoBancariaPosInputType : InputObjectGraphType
	{
		public InformacaoBancariaPosInputType()
		{
			// Defining the name of the object
			Name = "informacaoBancariaPosInput";
			
            //Field<StringGraphType>("idInformacaoBancariaPos");
			Field<StringGraphType>("informacaoBancariaId");
			Field<StringGraphType>("posid");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("codInformacaoBancariaPos");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<InformacaoBancariaInputType>("informacaoBancaria");
			Field<PosInputType>("pos");
			
		}
	}
}