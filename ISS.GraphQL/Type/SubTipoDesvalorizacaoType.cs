using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubTipoDesvalorizacaoType : ObjectGraphType<SubTipoDesvalorizacao>
    {
        public SubTipoDesvalorizacaoType()
        {
            // Defining the name of the object
            Name = "subTipoDesvalorizacao";

            Field(x => x.IdSubTipoDesvalorizacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodSubTipoDesvalorizacao, nullable: true);
            Field(x => x.TipoDesvalorizacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoDesvalorizacaoType>("tipoDesvalorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDesvalorizacao>(c.Source.TipoDesvalorizacaoId)));
            FieldAsync<ListGraphType<DesvalorizacaoType>>("desvalorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desvalorizacao>(x => x.Where(e => e.HasValue(c.Source.IdSubTipoDesvalorizacao)))));
            
        }
    }

    public class SubTipoDesvalorizacaoInputType : InputObjectGraphType
	{
		public SubTipoDesvalorizacaoInputType()
		{
			// Defining the name of the object
			Name = "subTipoDesvalorizacaoInput";
			
            //Field<StringGraphType>("idSubTipoDesvalorizacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codSubTipoDesvalorizacao");
			Field<StringGraphType>("tipoDesvalorizacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TipoDesvalorizacaoInputType>("tipoDesvalorizacao");
			Field<ListGraphType<DesvalorizacaoInputType>>("desvalorizacao");
			
		}
	}
}