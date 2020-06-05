using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoAprovacaoType : ObjectGraphType<TipoAprovacao>
    {
        public TipoAprovacaoType()
        {
            // Defining the name of the object
            Name = "tipoAprovacao";

            Field(x => x.IdTipoAprovacao, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodTipoAprovacao, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ClassificacaoAprovacaoType>>("classificacaoAprovacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAprovacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoAprovacao)))));
            
        }
    }

    public class TipoAprovacaoInputType : InputObjectGraphType
	{
		public TipoAprovacaoInputType()
		{
			// Defining the name of the object
			Name = "tipoAprovacaoInput";
			
            //Field<StringGraphType>("idTipoAprovacao");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codTipoAprovacao");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ClassificacaoAprovacaoInputType>>("classificacaoAprovacao");
			
		}
	}
}