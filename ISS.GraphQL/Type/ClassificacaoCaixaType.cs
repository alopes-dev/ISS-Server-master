using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoCaixaType : ObjectGraphType<ClassificacaoCaixa>
    {
        public ClassificacaoCaixaType()
        {
            // Defining the name of the object
            Name = "classificacaoCaixa";

            Field(x => x.IdClassificacaoCaixa, nullable: true);
            Field(x => x.CodClassificacaoCaixa, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.BancoId, nullable: true);
            Field(x => x.InformacaoBancariaId, nullable: true);
            FieldAsync<BancoType>("banco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Banco>(c.Source.BancoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<InformacaoBancariaType>("informacaoBancaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(c.Source.InformacaoBancariaId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<CaixaType>>("caixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Caixa>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoCaixa)))));
            
        }
    }

    public class ClassificacaoCaixaInputType : InputObjectGraphType
	{
		public ClassificacaoCaixaInputType()
		{
			// Defining the name of the object
			Name = "classificacaoCaixaInput";
			
            //Field<StringGraphType>("idClassificacaoCaixa");
			Field<StringGraphType>("codClassificacaoCaixa");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("subContaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("bancoId");
			Field<StringGraphType>("informacaoBancariaId");
			Field<BancoInputType>("banco");
			Field<EstadoInputType>("estado");
			Field<InformacaoBancariaInputType>("informacaoBancaria");
			Field<MoedaInputType>("moeda");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<CaixaInputType>>("caixa");
			
		}
	}
}