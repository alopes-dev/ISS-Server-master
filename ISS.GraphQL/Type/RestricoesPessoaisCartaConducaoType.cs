using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RestricoesPessoaisCartaConducaoType : ObjectGraphType<RestricoesPessoaisCartaConducao>
    {
        public RestricoesPessoaisCartaConducaoType()
        {
            // Defining the name of the object
            Name = "restricoesPessoaisCartaConducao";

            Field(x => x.IdRestricao, nullable: true);
            Field(x => x.CodRestricoesPessoaisCartaConducao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CartaConducaoType>>("cartaConducao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CartaConducao>(x => x.Where(e => e.HasValue(c.Source.IdRestricao)))));
            
        }
    }

    public class RestricoesPessoaisCartaConducaoInputType : InputObjectGraphType
	{
		public RestricoesPessoaisCartaConducaoInputType()
		{
			// Defining the name of the object
			Name = "restricoesPessoaisCartaConducaoInput";
			
            //Field<StringGraphType>("idRestricao");
			Field<StringGraphType>("codRestricoesPessoaisCartaConducao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CartaConducaoInputType>>("cartaConducao");
			
		}
	}
}