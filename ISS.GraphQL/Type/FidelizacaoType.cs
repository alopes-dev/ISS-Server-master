using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FidelizacaoType : ObjectGraphType<Fidelizacao>
    {
        public FidelizacaoType()
        {
            // Defining the name of the object
            Name = "fidelizacao";

            Field(x => x.IdFidelizacao, nullable: true);
            Field(x => x.Designcao, nullable: true);
            Field(x => x.CodFidelizacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Nivel, nullable: true, type: typeof(IntGraphType));
            Field(x => x.PessoaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<ListGraphType<ClienteType>>("cliente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cliente>(x => x.Where(e => e.HasValue(c.Source.IdFidelizacao)))));
            FieldAsync<ListGraphType<FidelizacaoComissionamentoType>>("fidelizacaoComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FidelizacaoComissionamento>(x => x.Where(e => e.HasValue(c.Source.IdFidelizacao)))));
            FieldAsync<ListGraphType<FidelizacaoContratoType>>("fidelizacaoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FidelizacaoContrato>(x => x.Where(e => e.HasValue(c.Source.IdFidelizacao)))));
            FieldAsync<ListGraphType<FidelizacaoPlanoType>>("fidelizacaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FidelizacaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdFidelizacao)))));
            FieldAsync<ListGraphType<SegmentoProdutoType>>("segmentoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoProduto>(x => x.Where(e => e.HasValue(c.Source.IdFidelizacao)))));
            FieldAsync<ListGraphType<SegmentoTipoCoberturaType>>("segmentoTipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoTipoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdFidelizacao)))));
            
        }
    }

    public class FidelizacaoInputType : InputObjectGraphType
	{
		public FidelizacaoInputType()
		{
			// Defining the name of the object
			Name = "fidelizacaoInput";
			
            //Field<StringGraphType>("idFidelizacao");
			Field<StringGraphType>("designcao");
			Field<StringGraphType>("codFidelizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<IntGraphType>("nivel");
			Field<StringGraphType>("pessoaId");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<ListGraphType<ClienteInputType>>("cliente");
			Field<ListGraphType<FidelizacaoComissionamentoInputType>>("fidelizacaoComissionamento");
			Field<ListGraphType<FidelizacaoContratoInputType>>("fidelizacaoContrato");
			Field<ListGraphType<FidelizacaoPlanoInputType>>("fidelizacaoPlano");
			Field<ListGraphType<SegmentoProdutoInputType>>("segmentoProduto");
			Field<ListGraphType<SegmentoTipoCoberturaInputType>>("segmentoTipoCobertura");
			
		}
	}
}