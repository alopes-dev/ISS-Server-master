using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;

namespace ISS.GraphQL.Type
{
    public class PessoaSingularType : PessoaType
    {
        public PessoaSingularType()
        {
            // Defining the name of the object
            Name = "pessoaSingular";

            Field(x => x.PrimeiroNome, nullable: true);
            Field(x => x.NomeDoMeio, nullable: true);
            Field(x => x.UltimoNome, nullable: true);
            Field(x => x.NomeCurto, nullable: true);
            Field(x => x.Pseudonimo, nullable: true);
            Field(x => x.EstadoCivilId, nullable: true);
            Field(x => x.SexoId, nullable: true);
            Field(x => x.TituloId, nullable: true);
            Field(x => x.SituacaoEmpregoId, nullable: true);
            Field(x => x.RazoesDesemprego, nullable: true);
            Field(x => x.FaixaEtariaId, nullable: true);
            Field(x => x.Alias, nullable: true);
            Field(x => x.DeficienciaId, nullable: true);
            Field(x => x.TipoSanguineoId, nullable: true);
            FieldAsync<DeficienciaType>("deficiencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Deficiencia>(c.Source.DeficienciaId)));
            FieldAsync<EstadoCivilType>("estadoCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EstadoCivil>(c.Source.EstadoCivilId)));
            FieldAsync<FaixaEtariaType>("faixaEtaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FaixaEtaria>(c.Source.FaixaEtariaId)));
            FieldAsync<SexoType>("sexo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sexo>(c.Source.SexoId)));
            FieldAsync<SituacaoEmpregoType>("situacaoEmprego", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SituacaoEmprego>(c.Source.SituacaoEmpregoId)));
            FieldAsync<TipoSanguineoType>("tipoSanguineo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSanguineo>(c.Source.TipoSanguineoId)));
            FieldAsync<TituloType>("titulo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Titulo>(c.Source.TituloId)));
            FieldAsync<FiliacaoType>("filiacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Filiacao>(c.Source.IdPessoa)));
            FieldAsync<ListGraphType<CartaConducaoType>>("cartaConducao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CartaConducao>(x => x.Where(e => e.HasValue(c.Source.IdPessoa)))));
            FieldAsync<ListGraphType<CausadorSinistroType>>("causadorSinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CausadorSinistro>(x => x.Where(e => e.HasValue(c.Source.IdPessoa)))));
            FieldAsync<ListGraphType<ConjuguePessoaType>>("conjuguePessoaConjugue", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ConjuguePessoa>(x => x.Where(e => e.HasValue(c.Source.IdPessoa)))));
            FieldAsync<ListGraphType<ConjuguePessoaType>>("conjuguePessoaPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ConjuguePessoa>(x => x.Where(e => e.HasValue(c.Source.IdPessoa)))));
            FieldAsync<ListGraphType<HabilitacoesLiterariasPessoaType>>("habilitacoesLiterariasPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HabilitacoesLiterariasPessoa>(x => x.Where(e => e.HasValue(c.Source.IdPessoa)))));
            FieldAsync<ListGraphType<IdiomaPessoaType>>("idiomaPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<IdiomaPessoa>(x => x.Where(e => e.HasValue(c.Source.IdPessoa)))));
            FieldAsync<ListGraphType<PessoaProfissaoType>>("pessoaProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(x => x.Where(e => e.HasValue(c.Source.IdPessoa)))));
            FieldAsync<ListGraphType<RendimentoPessoaType>>("rendimentoPessoaPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RendimentoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdPessoa)))));
            FieldAsync<ListGraphType<AnimaisType>>("animais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Animais>(x => x.Where(e => e.HasValue(c.Source.IdPessoa)))));
        }
    }

    public class PessoaSingularInputType : PessoaInputType
	{
		public PessoaSingularInputType()
		{
			// Defining the name of the object
			Name = "pessoaSingularInput";
			
            Field(x => x.PrimeiroNome,nullable:true);
            Field(x => x.NomeDoMeio,nullable:true);
            Field(x => x.UltimoNome,nullable:true);
            Field(x => x.NomeCurto,nullable:true);
            Field(x => x.Pseudonimo,nullable:true);
            Field(x => x.EstadoCivilId,nullable:true);
            Field(x => x.SexoId,nullable:true);
            Field(x => x.TituloId,nullable:true);
            Field(x => x.SituacaoEmpregoId,nullable:true);
            Field(x => x.RazoesDesemprego,nullable:true);
            Field(x => x.FaixaEtariaId,nullable:true);
            Field(x => x.Alias,nullable:true);
            Field(x => x.DeficienciaId,nullable:true);
            Field(x => x.TipoSanguineoId,nullable:true);
            Field(x => x.Deficiencia,nullable:true,type:typeof(DeficienciaInputType));
            Field(x => x.FaixaEtaria,nullable:true,type:typeof(FaixaEtariaInputType));
            Field(x => x.Filiacao,nullable:true,type:typeof(FiliacaoInputType));
            Field(x => x.CartaConducao,nullable:true,type:typeof(ListGraphType<CartaConducaoInputType>));
            Field(x => x.CausadorSinistro,nullable:true,type:typeof(ListGraphType<CausadorSinistroInputType>));
            Field(x => x.ConjuguePessoaConjugue,nullable:true,type:typeof(ListGraphType<ConjuguePessoaInputType>));
            Field(x => x.ConjuguePessoaPessoa,nullable:true,type:typeof(ListGraphType<ConjuguePessoaInputType>));
            Field(x => x.HabilitacoesLiterariasPessoa,nullable:true,type:typeof(ListGraphType<HabilitacoesLiterariasPessoaInputType>));
            Field(x => x.IdiomaPessoa,nullable:true,type:typeof(ListGraphType<IdiomaPessoaInputType>));
            Field(x => x.PessoaProfissao,nullable:true,type:typeof(ListGraphType<PessoaProfissaoInputType>));
            Field(x => x.RendimentoPessoaPessoa,nullable:true,type:typeof(ListGraphType<RendimentoPessoaInputType>));
            Field(x => x.Animais,nullable:true,type:typeof(ListGraphType<AnimaisInputType>));
		}
	}
}