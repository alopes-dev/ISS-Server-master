using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OperacaoPlanoType : ObjectGraphType<OperacaoPlano>
    {
        public OperacaoPlanoType()
        {
            // Defining the name of the object
            Name = "operacaoPlano";

            Field(x => x.IdOperacaoPlano, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.OperacaoId, nullable: true);
            FieldAsync<OperacaoType>("operacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Operacao>(c.Source.OperacaoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<LocaisOfertaType>>("locaisOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisOferta>(x => x.Where(e => e.HasValue(c.Source.IdOperacaoPlano)))));
            FieldAsync<ListGraphType<SegmentoOfertaType>>("segmentoOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoOferta>(x => x.Where(e => e.HasValue(c.Source.IdOperacaoPlano)))));
            
        }
    }

    public class OperacaoPlanoInputType : InputObjectGraphType
	{
		public OperacaoPlanoInputType()
		{
			// Defining the name of the object
			Name = "operacaoPlanoInput";
			
            //Field<StringGraphType>("idOperacaoPlano");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("operacaoId");
			Field<OperacaoInputType>("operacao");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<LocaisOfertaInputType>>("locaisOferta");
			Field<ListGraphType<SegmentoOfertaInputType>>("segmentoOferta");
			
		}
	}
}