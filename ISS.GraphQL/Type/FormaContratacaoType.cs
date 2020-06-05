using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FormaContratacaoType : ObjectGraphType<FormaContratacao>
    {
        public FormaContratacaoType()
        {
            // Defining the name of the object
            Name = "formaContratacao";

            Field(x => x.IdFormaContratacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFormaContratacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.DescontoId, nullable: true);
            Field(x => x.TipoPessoaId, nullable: true);
            FieldAsync<DescontoType>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(c.Source.DescontoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoPessoaType>("tipoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPessoa>(c.Source.TipoPessoaId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdFormaContratacao)))));
            FieldAsync<ListGraphType<FormaContratacaoPlanoType>>("formaContratacaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaContratacaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdFormaContratacao)))));
            FieldAsync<ListGraphType<GrupoEtarioType>>("grupoEtario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GrupoEtario>(x => x.Where(e => e.HasValue(c.Source.IdFormaContratacao)))));
            FieldAsync<ListGraphType<NumeroPessoasAbrangivelType>>("numeroPessoasAbrangivel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NumeroPessoasAbrangivel>(x => x.Where(e => e.HasValue(c.Source.IdFormaContratacao)))));
            FieldAsync<ListGraphType<TipoAdesaoType>>("tipoAdesao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoAdesao>(x => x.Where(e => e.HasValue(c.Source.IdFormaContratacao)))));
            FieldAsync<ListGraphType<TipoClassificacaoGrupoType>>("tipoClassificacaoGrupo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoClassificacaoGrupo>(x => x.Where(e => e.HasValue(c.Source.IdFormaContratacao)))));
            
        }
    }

    public class FormaContratacaoInputType : InputObjectGraphType
	{
		public FormaContratacaoInputType()
		{
			// Defining the name of the object
			Name = "formaContratacaoInput";
			
            //Field<StringGraphType>("idFormaContratacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFormaContratacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("descontoId");
			Field<StringGraphType>("tipoPessoaId");
			Field<DescontoInputType>("desconto");
			Field<EstadoInputType>("estado");
			Field<TipoPessoaInputType>("tipoPessoa");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<FormaContratacaoPlanoInputType>>("formaContratacaoPlano");
			Field<ListGraphType<GrupoEtarioInputType>>("grupoEtario");
			Field<ListGraphType<NumeroPessoasAbrangivelInputType>>("numeroPessoasAbrangivel");
			Field<ListGraphType<TipoAdesaoInputType>>("tipoAdesao");
			Field<ListGraphType<TipoClassificacaoGrupoInputType>>("tipoClassificacaoGrupo");
			
		}
	}
}