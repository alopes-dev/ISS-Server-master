using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PontosClausulaType : ObjectGraphType<PontosClausula>
    {
        public PontosClausulaType()
        {
            // Defining the name of the object
            Name = "pontosClausula";

            Field(x => x.IdPontosClausula, nullable: true);
            Field(x => x.NumPonto, nullable: true);
            Field(x => x.Conteudo, nullable: true);
            Field(x => x.Obs, nullable: true);
            Field(x => x.ClausulaId, nullable: true);
            Field(x => x.CodPontosClausula, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            FieldAsync<ClausulaType>("clausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Clausula>(c.Source.ClausulaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ListGraphType<SubPontosClausulaType>>("subPontosClausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubPontosClausula>(x => x.Where(e => e.HasValue(c.Source.IdPontosClausula)))));
            
        }
    }

    public class PontosClausulaInputType : InputObjectGraphType
	{
		public PontosClausulaInputType()
		{
			// Defining the name of the object
			Name = "pontosClausulaInput";
			
            //Field<StringGraphType>("idPontosClausula");
			Field<StringGraphType>("numPonto");
			Field<StringGraphType>("conteudo");
			Field<StringGraphType>("obs");
			Field<StringGraphType>("clausulaId");
			Field<StringGraphType>("codPontosClausula");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("linhaProdutoId");
			Field<ClausulaInputType>("clausula");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ListGraphType<SubPontosClausulaInputType>>("subPontosClausula");
			
		}
	}
}