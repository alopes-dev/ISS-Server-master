using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSugestaoType : ObjectGraphType<TipoSugestao>
    {
        public TipoSugestaoType()
        {
            // Defining the name of the object
            Name = "tipoSugestao";

            Field(x => x.IdTipoSugestao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoSugestao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<SugestaoType>>("sugestao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sugestao>(x => x.Where(e => e.HasValue(c.Source.IdTipoSugestao)))));
            
        }
    }

    public class TipoSugestaoInputType : InputObjectGraphType
	{
		public TipoSugestaoInputType()
		{
			// Defining the name of the object
			Name = "tipoSugestaoInput";
			
            //Field<StringGraphType>("idTipoSugestao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoSugestao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<SugestaoInputType>>("sugestao");
			
		}
	}
}