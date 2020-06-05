using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCasoType : ObjectGraphType<TipoCaso>
    {
        public TipoCasoType()
        {
            // Defining the name of the object
            Name = "tipoCaso";

            Field(x => x.IdTipoCaso, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoCaso, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ClassificacaoTipoCasoType>>("classificacaoTipoCaso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoTipoCaso>(x => x.Where(e => e.HasValue(c.Source.IdTipoCaso)))));
            
        }
    }

    public class TipoCasoInputType : InputObjectGraphType
	{
		public TipoCasoInputType()
		{
			// Defining the name of the object
			Name = "tipoCasoInput";
			
            //Field<StringGraphType>("idTipoCaso");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoCaso");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ClassificacaoTipoCasoInputType>>("classificacaoTipoCaso");
			
		}
	}
}