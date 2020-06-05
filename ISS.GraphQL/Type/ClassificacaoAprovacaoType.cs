using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoAprovacaoType : ObjectGraphType<ClassificacaoAprovacao>
    {
        public ClassificacaoAprovacaoType()
        {
            // Defining the name of the object
            Name = "classificacaoAprovacao";

            Field(x => x.IdClassificacaoAprovacao, nullable: true);
            Field(x => x.AprovacaoId, nullable: true);
            Field(x => x.TipoAprovacaoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodClassificacaoAprovacao, nullable: true);
            FieldAsync<AprovacaoType>("aprovacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Aprovacao>(c.Source.AprovacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoAprovacaoType>("tipoAprovacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoAprovacao>(c.Source.TipoAprovacaoId)));
            
        }
    }

    public class ClassificacaoAprovacaoInputType : InputObjectGraphType
	{
		public ClassificacaoAprovacaoInputType()
		{
			// Defining the name of the object
			Name = "classificacaoAprovacaoInput";
			
            //Field<StringGraphType>("idClassificacaoAprovacao");
			Field<StringGraphType>("aprovacaoId");
			Field<StringGraphType>("tipoAprovacaoId");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codClassificacaoAprovacao");
			Field<AprovacaoInputType>("aprovacao");
			Field<EstadoInputType>("estado");
			Field<TipoAprovacaoInputType>("tipoAprovacao");
			
		}
	}
}