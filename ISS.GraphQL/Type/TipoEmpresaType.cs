using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoEmpresaType : ObjectGraphType<TipoEmpresa>
    {
        public TipoEmpresaType()
        {
            // Defining the name of the object
            Name = "tipoEmpresa";

            Field(x => x.IdTipoEmpresa, nullable: true);
            Field(x => x.CodTipoEmpresa, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<DimensaoEmpresaType>>("dimensaoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DimensaoEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdTipoEmpresa)))));
            
        }
    }

    public class TipoEmpresaInputType : InputObjectGraphType
	{
		public TipoEmpresaInputType()
		{
			// Defining the name of the object
			Name = "tipoEmpresaInput";
			
            //Field<StringGraphType>("idTipoEmpresa");
			Field<StringGraphType>("codTipoEmpresa");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<DimensaoEmpresaInputType>>("dimensaoEmpresa");
			
		}
	}
}