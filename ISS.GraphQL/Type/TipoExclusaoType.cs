using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoExclusaoType : ObjectGraphType<TipoExclusao>
    {
        public TipoExclusaoType()
        {
            // Defining the name of the object
            Name = "tipoExclusao";

            Field(x => x.IdTipoExclusao, nullable: true);
            Field(x => x.CodTipoExclusao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ExclusoesType>>("exclusoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Exclusoes>(x => x.Where(e => e.HasValue(c.Source.IdTipoExclusao)))));
            FieldAsync<ListGraphType<RiscosExcluidosType>>("riscosExcluidos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RiscosExcluidos>(x => x.Where(e => e.HasValue(c.Source.IdTipoExclusao)))));
            
        }
    }

    public class TipoExclusaoInputType : InputObjectGraphType
	{
		public TipoExclusaoInputType()
		{
			// Defining the name of the object
			Name = "tipoExclusaoInput";
			
            //Field<StringGraphType>("idTipoExclusao");
			Field<StringGraphType>("codTipoExclusao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ExclusoesInputType>>("exclusoes");
			Field<ListGraphType<RiscosExcluidosInputType>>("riscosExcluidos");
			
		}
	}
}