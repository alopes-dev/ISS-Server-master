using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubPontosClausulaType : ObjectGraphType<SubPontosClausula>
    {
        public SubPontosClausulaType()
        {
            // Defining the name of the object
            Name = "subPontosClausula";

            Field(x => x.IdSubPontosClausula, nullable: true);
            Field(x => x.NumSubPonto, nullable: true);
            Field(x => x.Conteudo, nullable: true);
            Field(x => x.PontosClausulaId, nullable: true);
            Field(x => x.CodSubPontosClausula, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PontosClausulaType>("pontosClausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PontosClausula>(c.Source.PontosClausulaId)));
            FieldAsync<ListGraphType<SubClausulasPontosType>>("subClausulasPontos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubClausulasPontos>(x => x.Where(e => e.HasValue(c.Source.IdSubPontosClausula)))));
            
        }
    }

    public class SubPontosClausulaInputType : InputObjectGraphType
	{
		public SubPontosClausulaInputType()
		{
			// Defining the name of the object
			Name = "subPontosClausulaInput";
			
            //Field<StringGraphType>("idSubPontosClausula");
			Field<StringGraphType>("numSubPonto");
			Field<StringGraphType>("conteudo");
			Field<StringGraphType>("pontosClausulaId");
			Field<StringGraphType>("codSubPontosClausula");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PontosClausulaInputType>("pontosClausula");
			Field<ListGraphType<SubClausulasPontosInputType>>("subClausulasPontos");
			
		}
	}
}