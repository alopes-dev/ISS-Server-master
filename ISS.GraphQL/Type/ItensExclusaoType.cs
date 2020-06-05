using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ItensExclusaoType : ObjectGraphType<ItensExclusao>
    {
        public ItensExclusaoType()
        {
            // Defining the name of the object
            Name = "itensExclusao";

            Field(x => x.IdItensExclusao, nullable: true);
            Field(x => x.ExclusaoId, nullable: true);
            Field(x => x.CodItensExclusao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ExclusoesType>("exclusao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exclusoes>(c.Source.ExclusaoId)));
            
        }
    }

    public class ItensExclusaoInputType : InputObjectGraphType
	{
		public ItensExclusaoInputType()
		{
			// Defining the name of the object
			Name = "itensExclusaoInput";
			
            //Field<StringGraphType>("idItensExclusao");
			Field<StringGraphType>("exclusaoId");
			Field<StringGraphType>("codItensExclusao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ExclusoesInputType>("exclusao");
			
		}
	}
}