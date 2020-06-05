using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContaBancariaPosType : ObjectGraphType<ContaBancariaPos>
    {
        public ContaBancariaPosType()
        {
            // Defining the name of the object
            Name = "contaBancariaPos";

            Field(x => x.IdContaPos, nullable: true);
            Field(x => x.Posid, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.InformacaoBancariaId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<InformacaoBancariaType>("informacaoBancaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(c.Source.InformacaoBancariaId)));
            FieldAsync<PosType>("pos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pos>(c.Source.Posid)));
            
        }
    }

    public class ContaBancariaPosInputType : InputObjectGraphType
	{
		public ContaBancariaPosInputType()
		{
			// Defining the name of the object
			Name = "contaBancariaPosInput";
			
            //Field<StringGraphType>("idContaPos");
			Field<StringGraphType>("posid");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("informacaoBancariaId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<InformacaoBancariaInputType>("informacaoBancaria");
			Field<PosInputType>("pos");
			
		}
	}
}