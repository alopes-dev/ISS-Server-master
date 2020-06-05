using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoFacturacaoType : ObjectGraphType<TipoFacturacao>
    {
        public TipoFacturacaoType()
        {
            // Defining the name of the object
            Name = "tipoFacturacao";

            Field(x => x.IdTipoFacturacao, nullable: true);
            Field(x => x.CodTipoFacturacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<TipoFacturacaoPlanoProdutoType>>("tipoFacturacaoPlanoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoFacturacaoPlanoProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipoFacturacao)))));
            
        }
    }

    public class TipoFacturacaoInputType : InputObjectGraphType
	{
		public TipoFacturacaoInputType()
		{
			// Defining the name of the object
			Name = "tipoFacturacaoInput";
			
            //Field<StringGraphType>("idTipoFacturacao");
			Field<StringGraphType>("codTipoFacturacao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<TipoFacturacaoPlanoProdutoInputType>>("tipoFacturacaoPlanoProduto");
			
		}
	}
}