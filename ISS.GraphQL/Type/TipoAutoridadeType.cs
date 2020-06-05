using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoAutoridadeType : ObjectGraphType<TipoAutoridade>
    {
        public TipoAutoridadeType()
        {
            // Defining the name of the object
            Name = "tipoAutoridade";

            Field(x => x.IdTipo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoAutoridade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AutoridadesContactadasType>>("autoridadesContactadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AutoridadesContactadas>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<RelatorioPoliciaType>>("relatorioPolicia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RelatorioPolicia>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            
        }
    }

    public class TipoAutoridadeInputType : InputObjectGraphType
	{
		public TipoAutoridadeInputType()
		{
			// Defining the name of the object
			Name = "tipoAutoridadeInput";
			
            //Field<StringGraphType>("idTipo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoAutoridade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AutoridadesContactadasInputType>>("autoridadesContactadas");
			Field<ListGraphType<RelatorioPoliciaInputType>>("relatorioPolicia");
			
		}
	}
}