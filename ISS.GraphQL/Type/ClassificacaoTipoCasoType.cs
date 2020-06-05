using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoTipoCasoType : ObjectGraphType<ClassificacaoTipoCaso>
    {
        public ClassificacaoTipoCasoType()
        {
            // Defining the name of the object
            Name = "classificacaoTipoCaso";

            Field(x => x.IdClassificacaoTipoCaso, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodClassificacaoTipoCaso, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoCasoId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCasoType>("tipoCaso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCaso>(c.Source.TipoCasoId)));
            FieldAsync<ListGraphType<CasoClassificacaoType>>("casoClassificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CasoClassificacao>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoTipoCaso)))));
            
        }
    }

    public class ClassificacaoTipoCasoInputType : InputObjectGraphType
	{
		public ClassificacaoTipoCasoInputType()
		{
			// Defining the name of the object
			Name = "classificacaoTipoCasoInput";
			
            //Field<StringGraphType>("idClassificacaoTipoCaso");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codClassificacaoTipoCaso");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("tipoCasoId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TipoCasoInputType>("tipoCaso");
			Field<ListGraphType<CasoClassificacaoInputType>>("casoClassificacao");
			
		}
	}
}