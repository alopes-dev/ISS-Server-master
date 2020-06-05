using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoComissaoType : ObjectGraphType<TipoComissao>
    {
        public TipoComissaoType()
        {
            // Defining the name of the object
            Name = "tipoComissao";

            Field(x => x.IdTipoComissao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.CodTipoComissao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.MoedaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<NaturezaMovimentoType>("naturezaMovimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NaturezaMovimento>(c.Source.NaturezaMovimentoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<ComissaoType>>("comissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissao>(x => x.Where(e => e.HasValue(c.Source.IdTipoComissao)))));
            FieldAsync<ListGraphType<ComissaoPlanoType>>("comissaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdTipoComissao)))));
            
        }
    }

    public class TipoComissaoInputType : InputObjectGraphType
	{
		public TipoComissaoInputType()
		{
			// Defining the name of the object
			Name = "tipoComissaoInput";
			
            //Field<StringGraphType>("idTipoComissao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<StringGraphType>("codTipoComissao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("moedaId");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<NaturezaMovimentoInputType>("naturezaMovimento");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<ComissaoInputType>>("comissao");
			Field<ListGraphType<ComissaoPlanoInputType>>("comissaoPlano");
			
		}
	}
}