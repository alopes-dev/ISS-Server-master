using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BalcaoPlanoType : ObjectGraphType<BalcaoPlano>
    {
        public BalcaoPlanoType()
        {
            // Defining the name of the object
            Name = "balcaoPlano";

            Field(x => x.IdBalcaoPlano, nullable: true);
            Field(x => x.BalcaoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.PlanoObjectivoComercialId, nullable: true);
            Field(x => x.QtdVenda, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<BalcaoType>("balcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Balcao>(c.Source.BalcaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoObjectivoComercialType>("planoObjectivoComercial", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoObjectivoComercial>(c.Source.PlanoObjectivoComercialId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<PlanoComercialPorProdutorType>>("planoComercialPorProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoComercialPorProdutor>(x => x.Where(e => e.HasValue(c.Source.IdBalcaoPlano)))));
            
        }
    }

    public class BalcaoPlanoInputType : InputObjectGraphType
	{
		public BalcaoPlanoInputType()
		{
			// Defining the name of the object
			Name = "balcaoPlanoInput";
			
            //Field<StringGraphType>("idBalcaoPlano");
			Field<StringGraphType>("balcaoId");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("planoObjectivoComercialId");
			Field<IntGraphType>("qtdVenda");
			Field<FloatGraphType>("valor");
			Field<BalcaoInputType>("balcao");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<PlanoObjectivoComercialInputType>("planoObjectivoComercial");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<PlanoComercialPorProdutorInputType>>("planoComercialPorProdutor");
			
		}
	}
}