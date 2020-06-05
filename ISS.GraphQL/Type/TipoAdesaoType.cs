using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoAdesaoType : ObjectGraphType<TipoAdesao>
    {
        public TipoAdesaoType()
        {
            // Defining the name of the object
            Name = "tipoAdesao";

            Field(x => x.IdTipoAdesao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoAdesao, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.FormaContratacaoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaContratacaoType>("formaContratacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaContratacao>(c.Source.FormaContratacaoId)));
            FieldAsync<ListGraphType<CoeficientePremioAdesaoType>>("coeficientePremioAdesao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoeficientePremioAdesao>(x => x.Where(e => e.HasValue(c.Source.IdTipoAdesao)))));
            
        }
    }

    public class TipoAdesaoInputType : InputObjectGraphType
	{
		public TipoAdesaoInputType()
		{
			// Defining the name of the object
			Name = "tipoAdesaoInput";
			
            //Field<StringGraphType>("idTipoAdesao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoAdesao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("formaContratacaoId");
			Field<EstadoInputType>("estado");
			Field<FormaContratacaoInputType>("formaContratacao");
			Field<ListGraphType<CoeficientePremioAdesaoInputType>>("coeficientePremioAdesao");
			
		}
	}
}