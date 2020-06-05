using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BancoType : ObjectGraphType<Banco>
    {
        public BancoType()
        {
            // Defining the name of the object
            Name = "banco";

            Field(x => x.IdBanco, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.Caeid, nullable: true);
            Field(x => x.ClassificacaoEntidadeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Sigla, nullable: true);
            Field(x => x.SwiftCode, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumeroRegisto, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CaminhoImagem, nullable: true);
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.Caeid)));
            FieldAsync<ClassificacaoEntidadeType>("classificacaoEntidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoEntidade>(c.Source.ClassificacaoEntidadeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ClassificacaoCaixaType>>("classificacaoCaixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoCaixa>(x => x.Where(e => e.HasValue(c.Source.IdBanco)))));
            FieldAsync<ListGraphType<InformacaoBancariaType>>("informacaoBancaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(x => x.Where(e => e.HasValue(c.Source.IdBanco)))));
            FieldAsync<ListGraphType<TransferenciaType>>("transferencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Transferencia>(x => x.Where(e => e.HasValue(c.Source.IdBanco)))));
            
        }
    }

    public class BancoInputType : InputObjectGraphType
	{
		public BancoInputType()
		{
			// Defining the name of the object
			Name = "bancoInput";
			
            //Field<StringGraphType>("idBanco");
			Field<StringGraphType>("nome");
			Field<StringGraphType>("caeid");
			Field<StringGraphType>("classificacaoEntidadeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("sigla");
			Field<IntGraphType>("swiftCode");
			Field<IntGraphType>("numeroRegisto");
			Field<StringGraphType>("caminhoImagem");
			Field<CaeInputType>("cae");
			Field<ClassificacaoEntidadeInputType>("classificacaoEntidade");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ClassificacaoCaixaInputType>>("classificacaoCaixa");
			Field<ListGraphType<InformacaoBancariaInputType>>("informacaoBancaria");
			Field<ListGraphType<TransferenciaInputType>>("transferencia");
			
		}
	}
}