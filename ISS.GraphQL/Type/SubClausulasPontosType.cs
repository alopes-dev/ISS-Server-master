using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubClausulasPontosType : ObjectGraphType<SubClausulasPontos>
    {
        public SubClausulasPontosType()
        {
            // Defining the name of the object
            Name = "subClausulasPontos";

            Field(x => x.IdSubClausulasPontos, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.CodSubPontosClausula, nullable: true);
            Field(x => x.SubPontosClausulaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NumClausulaPonto, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SubPontosClausulaType>("subPontosClausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubPontosClausula>(c.Source.SubPontosClausulaId)));
            
        }
    }

    public class SubClausulasPontosInputType : InputObjectGraphType
	{
		public SubClausulasPontosInputType()
		{
			// Defining the name of the object
			Name = "subClausulasPontosInput";
			
            //Field<StringGraphType>("idSubClausulasPontos");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("codSubPontosClausula");
			Field<StringGraphType>("subPontosClausulaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("numClausulaPonto");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<SubPontosClausulaInputType>("subPontosClausula");
			
		}
	}
}