using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MeioAutorizacaoType : ObjectGraphType<MeioAutorizacao>
    {
        public MeioAutorizacaoType()
        {
            // Defining the name of the object
            Name = "meioAutorizacao";

            Field(x => x.IdMeioAutorizacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodMeioAutorizacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AutorizacaoType>>("autorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Autorizacao>(x => x.Where(e => e.HasValue(c.Source.IdMeioAutorizacao)))));
            
        }
    }

    public class MeioAutorizacaoInputType : InputObjectGraphType
	{
		public MeioAutorizacaoInputType()
		{
			// Defining the name of the object
			Name = "meioAutorizacaoInput";
			
            //Field<StringGraphType>("idMeioAutorizacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codMeioAutorizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AutorizacaoInputType>>("autorizacao");
			
		}
	}
}