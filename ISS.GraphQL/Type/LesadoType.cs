using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LesadoType : ObjectGraphType<Lesado>
    {
        public LesadoType()
        {
            // Defining the name of the object
            Name = "lesado";

            Field(x => x.IdLesado, nullable: true);
            Field(x => x.RelacaoComResponsavelAcidente, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EspecificacaoRelacao, nullable: true);
            Field(x => x.EspecificacaoDanos, nullable: true);
            Field(x => x.TipoIntervencaoId, nullable: true);
            Field(x => x.TipoDanosId, nullable: true);
            Field(x => x.TipoRelacaoSeguradoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.FornecedorId, nullable: true);
            Field(x => x.DataInicioPeriodoIncapacidadeTemporario, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CaminhoBoletimExame, nullable: true);
            Field(x => x.CaminhoBoletimObito, nullable: true);
            Field(x => x.CaminhoRelatorioAutopsia, nullable: true);
            Field(x => x.DataPrimeiroSocorro, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodLesado, nullable: true);
            Field(x => x.IsFerido, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("fornecedor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.FornecedorId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            FieldAsync<TipoDanosType>("tipoDanos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDanos>(c.Source.TipoDanosId)));
            FieldAsync<TipoIntervencaoType>("tipoIntervencao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoIntervencao>(c.Source.TipoIntervencaoId)));
            FieldAsync<TipoRelacaoSeguradoType>("tipoRelacaoSegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRelacaoSegurado>(c.Source.TipoRelacaoSeguradoId)));
            FieldAsync<ListGraphType<DocumentosLesadoType>>("documentosLesado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosLesado>(x => x.Where(e => e.HasValue(c.Source.IdLesado)))));
            FieldAsync<ListGraphType<LesaoLesadoType>>("lesaoLesado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LesaoLesado>(x => x.Where(e => e.HasValue(c.Source.IdLesado)))));
            
        }
    }

    public class LesadoInputType : InputObjectGraphType
	{
		public LesadoInputType()
		{
			// Defining the name of the object
			Name = "lesadoInput";
			
            //Field<StringGraphType>("idLesado");
			Field<BooleanGraphType>("relacaoComResponsavelAcidente");
			Field<StringGraphType>("especificacaoRelacao");
			Field<StringGraphType>("especificacaoDanos");
			Field<StringGraphType>("tipoIntervencaoId");
			Field<StringGraphType>("tipoDanosId");
			Field<StringGraphType>("tipoRelacaoSeguradoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("fornecedorId");
			Field<DateTimeGraphType>("dataInicioPeriodoIncapacidadeTemporario");
			Field<StringGraphType>("caminhoBoletimExame");
			Field<StringGraphType>("caminhoBoletimObito");
			Field<StringGraphType>("caminhoRelatorioAutopsia");
			Field<DateTimeGraphType>("dataPrimeiroSocorro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codLesado");
			Field<BooleanGraphType>("isFerido");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("fornecedor");
			Field<PessoaInputType>("pessoa");
			Field<SinistroInputType>("sinistro");
			Field<TipoDanosInputType>("tipoDanos");
			Field<TipoIntervencaoInputType>("tipoIntervencao");
			Field<TipoRelacaoSeguradoInputType>("tipoRelacaoSegurado");
			Field<ListGraphType<DocumentosLesadoInputType>>("documentosLesado");
			Field<ListGraphType<LesaoLesadoInputType>>("lesaoLesado");
			
		}
	}
}