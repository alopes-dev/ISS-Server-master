using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoViaNotificacaoType : ObjectGraphType<TipoViaNotificacao>
    {
        public TipoViaNotificacaoType()
        {
            // Defining the name of the object
            Name = "tipoViaNotificacao";

            Field(x => x.IdTipoViaNotificacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoViaNotificacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CoSeguroType>>("coSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoSeguro>(x => x.Where(e => e.HasValue(c.Source.IdTipoViaNotificacao)))));
            
        }
    }

    public class TipoViaNotificacaoInputType : InputObjectGraphType
	{
		public TipoViaNotificacaoInputType()
		{
			// Defining the name of the object
			Name = "tipoViaNotificacaoInput";
			
            //Field<StringGraphType>("idTipoViaNotificacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoViaNotificacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CoSeguroInputType>>("coSeguro");
			
		}
	}
}