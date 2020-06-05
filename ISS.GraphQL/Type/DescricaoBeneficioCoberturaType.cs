using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescricaoBeneficioCoberturaType : ObjectGraphType<DescricaoBeneficioCobertura>
    {
        public DescricaoBeneficioCoberturaType()
        {
            // Defining the name of the object
            Name = "descricaoBeneficioCobertura";

            Field(x => x.IdDescricaoBeneficioCobertura, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.CodDescricaoBeneficioCobertura, nullable: true);
            Field(x => x.BeneficioCoberturaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<BeneficioCoberturaType>("beneficioCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BeneficioCobertura>(c.Source.BeneficioCoberturaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DescricaoBeneficioCoberturaInputType : InputObjectGraphType
	{
		public DescricaoBeneficioCoberturaInputType()
		{
			// Defining the name of the object
			Name = "descricaoBeneficioCoberturaInput";
			
            //Field<StringGraphType>("idDescricaoBeneficioCobertura");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("codDescricaoBeneficioCobertura");
			Field<StringGraphType>("beneficioCoberturaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("planoProdutoId");
			Field<BeneficioCoberturaInputType>("beneficioCobertura");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}