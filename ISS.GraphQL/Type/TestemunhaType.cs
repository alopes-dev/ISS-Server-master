using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TestemunhaType : ObjectGraphType<Testemunha>
    {
        public TestemunhaType()
        {
            // Defining the name of the object
            Name = "testemunha";

            Field(x => x.IdTestemunha, nullable: true);
            Field(x => x.TipoRelacaoSeguradoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.Declaracao, nullable: true);
            Field(x => x.DataDeclaracao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodTestemunha, nullable: true);
            Field(x => x.ProfissaoId, nullable: true);
            Field(x => x.OndeSeEncontrava, nullable: true);
            Field(x => x.LocalTrabalho, nullable: true);
            Field(x => x.DeclaracaoTestemunhaId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<DeclaracaoTestemunhaType>("declaracaoTestemunha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DeclaracaoTestemunha>(c.Source.DeclaracaoTestemunhaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<TestemunhaType>("profissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Testemunha>(c.Source.ProfissaoId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            FieldAsync<TipoRelacaoSeguradoType>("tipoRelacaoSegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRelacaoSegurado>(c.Source.TipoRelacaoSeguradoId)));
            FieldAsync<ListGraphType<DocumentosTestemunhaType>>("documentosTestemunha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosTestemunha>(x => x.Where(e => e.HasValue(c.Source.IdTestemunha)))));
            FieldAsync<ListGraphType<TestemunhaType>>("inverseProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Testemunha>(x => x.Where(e => e.HasValue(c.Source.IdTestemunha)))));
            
        }
    }

    public class TestemunhaInputType : InputObjectGraphType
	{
		public TestemunhaInputType()
		{
			// Defining the name of the object
			Name = "testemunhaInput";
			
            //Field<StringGraphType>("idTestemunha");
			Field<StringGraphType>("tipoRelacaoSeguradoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("declaracao");
			Field<DateTimeGraphType>("dataDeclaracao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codTestemunha");
			Field<StringGraphType>("profissaoId");
			Field<StringGraphType>("ondeSeEncontrava");
			Field<StringGraphType>("localTrabalho");
			Field<StringGraphType>("declaracaoTestemunhaId");
			Field<StringGraphType>("apoliceId");
			Field<ApoliceInputType>("apolice");
			Field<DeclaracaoTestemunhaInputType>("declaracaoTestemunha");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<TestemunhaInputType>("profissao");
			Field<SinistroInputType>("sinistro");
			Field<TipoRelacaoSeguradoInputType>("tipoRelacaoSegurado");
			Field<ListGraphType<DocumentosTestemunhaInputType>>("documentosTestemunha");
			Field<ListGraphType<TestemunhaInputType>>("inverseProfissao");
			
		}
	}
}