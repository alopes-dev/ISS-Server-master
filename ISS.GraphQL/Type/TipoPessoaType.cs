using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoPessoaType : ObjectGraphType<TipoPessoa>
    {
        public TipoPessoaType()
        {
            // Defining the name of the object
            Name = "tipoPessoa";

            Field(x => x.IdTipoPessoa, nullable: true);
            Field(x => x.Pessoa, nullable: true);
            Field(x => x.CodTipoPessoa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<FormaContratacaoType>>("formaContratacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaContratacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoPessoa)))));
            FieldAsync<ListGraphType<PessoaType>>("pessoaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdTipoPessoa)))));
            FieldAsync<ListGraphType<PessoasPosType>>("pessoasPos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoasPos>(x => x.Where(e => e.HasValue(c.Source.IdTipoPessoa)))));
            FieldAsync<ListGraphType<TipoContratacaoType>>("tipoContratacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContratacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoPessoa)))));
            FieldAsync<ListGraphType<TipoGrupoType>>("tipoGrupo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoGrupo>(x => x.Where(e => e.HasValue(c.Source.IdTipoPessoa)))));
            FieldAsync<ListGraphType<TipoPessoaPlanoType>>("tipoPessoaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPessoaPlano>(x => x.Where(e => e.HasValue(c.Source.IdTipoPessoa)))));
            FieldAsync<ListGraphType<TipoRegimeType>>("tipoRegime", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRegime>(x => x.Where(e => e.HasValue(c.Source.IdTipoPessoa)))));
            FieldAsync<ListGraphType<TipoSegmentoType>>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(x => x.Where(e => e.HasValue(c.Source.IdTipoPessoa)))));
            
        }
    }

    public class TipoPessoaInputType : InputObjectGraphType
	{
		public TipoPessoaInputType()
		{
			// Defining the name of the object
			Name = "tipoPessoaInput";
			
            //Field<StringGraphType>("idTipoPessoa");
			Field<StringGraphType>("pessoa");
			Field<StringGraphType>("codTipoPessoa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<FormaContratacaoInputType>>("formaContratacao");
			Field<ListGraphType<PessoaInputType>>("pessoaNavigation");
			Field<ListGraphType<PessoasPosInputType>>("pessoasPos");
			Field<ListGraphType<TipoContratacaoInputType>>("tipoContratacao");
			Field<ListGraphType<TipoGrupoInputType>>("tipoGrupo");
			Field<ListGraphType<TipoPessoaPlanoInputType>>("tipoPessoaPlano");
			Field<ListGraphType<TipoRegimeInputType>>("tipoRegime");
			Field<ListGraphType<TipoSegmentoInputType>>("tipoSegmento");
			
		}
	}
}