using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MetodoSistemaAquecimentoType : ObjectGraphType<MetodoSistemaAquecimento>
    {
        public MetodoSistemaAquecimentoType()
        {
            // Defining the name of the object
            Name = "metodoSistemaAquecimento";

            Field(x => x.IdMetodoSistemaAquecimento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodMetodoSistemaAquecimento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<SistemaAquecimentoType>>("sistemaAquecimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SistemaAquecimento>(x => x.Where(e => e.HasValue(c.Source.IdMetodoSistemaAquecimento)))));
            
        }
    }

    public class MetodoSistemaAquecimentoInputType : InputObjectGraphType
	{
		public MetodoSistemaAquecimentoInputType()
		{
			// Defining the name of the object
			Name = "metodoSistemaAquecimentoInput";
			
            //Field<StringGraphType>("idMetodoSistemaAquecimento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codMetodoSistemaAquecimento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<SistemaAquecimentoInputType>>("sistemaAquecimento");
			
		}
	}
}