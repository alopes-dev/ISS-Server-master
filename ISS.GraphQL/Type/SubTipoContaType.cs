using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubTipoContaType : ObjectGraphType<SubTipoConta>
    {
        public SubTipoContaType()
        {
            // Defining the name of the object
            Name = "subTipoConta";

            Field(x => x.IdSubTipoConta, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodSubTipoConta, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoContaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoContaType>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(c.Source.TipoContaId)));
            FieldAsync<ListGraphType<TipoContaType>>("tipoContaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(x => x.Where(e => e.HasValue(c.Source.IdSubTipoConta)))));
            
        }
    }

    public class SubTipoContaInputType : InputObjectGraphType
	{
		public SubTipoContaInputType()
		{
			// Defining the name of the object
			Name = "subTipoContaInput";
			
            //Field<StringGraphType>("idSubTipoConta");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codSubTipoConta");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("tipoContaId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TipoContaInputType>("tipoConta");
			Field<ListGraphType<TipoContaInputType>>("tipoContaNavigation");
			
		}
	}
}