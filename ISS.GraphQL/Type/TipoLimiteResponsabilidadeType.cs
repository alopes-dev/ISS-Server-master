using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoLimiteResponsabilidadeType : ObjectGraphType<TipoLimiteResponsabilidade>
    {
        public TipoLimiteResponsabilidadeType()
        {
            // Defining the name of the object
            Name = "tipoLimiteResponsabilidade";

            Field(x => x.IdTipoLimiteResponsabilidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoLimiteResponsabilidade, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<LimiteResponsabilidadeType>>("limiteResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdTipoLimiteResponsabilidade)))));
            
        }
    }

    public class TipoLimiteResponsabilidadeInputType : InputObjectGraphType
	{
		public TipoLimiteResponsabilidadeInputType()
		{
			// Defining the name of the object
			Name = "tipoLimiteResponsabilidadeInput";
			
            //Field<StringGraphType>("idTipoLimiteResponsabilidade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoLimiteResponsabilidade");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<LimiteResponsabilidadeInputType>>("limiteResponsabilidade");
			
		}
	}
}