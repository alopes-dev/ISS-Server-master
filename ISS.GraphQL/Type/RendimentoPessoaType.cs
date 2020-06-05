using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RendimentoPessoaType : ObjectGraphType<RendimentoPessoa>
    {
        public RendimentoPessoaType()
        {
            // Defining the name of the object
            Name = "rendimentoPessoa";

            Field(x => x.IdRendimentoPessoa, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            //FieldAsync<DecimalType>("valor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Decimal>(c.Source.IdRendimentoPessoa)));
            Field(x => x.TipoRendimentoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodRendimentoPessoa, nullable: true);
            Field(x => x.EntidadeEmpregadoraId, nullable: true);
            FieldAsync<PessoaType>("entidadeEmpregadora", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.EntidadeEmpregadoraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<TipoRendimentoType>("tipoRendimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRendimento>(c.Source.TipoRendimentoId)));
            FieldAsync<ListGraphType<ComponenteSalarialPessoaType>>("componenteSalarialPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComponenteSalarialPessoa>(x => x.Where(e => e.HasValue(c.Source.IdRendimentoPessoa)))));
            FieldAsync<ListGraphType<PessoaProfissaoType>>("pessoaProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(x => x.Where(e => e.HasValue(c.Source.IdRendimentoPessoa)))));
            
        }
    }

    public class RendimentoPessoaInputType : InputObjectGraphType
	{
		public RendimentoPessoaInputType()
		{
			// Defining the name of the object
			Name = "rendimentoPessoaInput";
			
            //Field<StringGraphType>("idRendimentoPessoa");
			Field<StringGraphType>("pessoaId");
			//Field<DecimalInputType>("valor");
			Field<StringGraphType>("tipoRendimentoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codRendimentoPessoa");
			Field<StringGraphType>("entidadeEmpregadoraId");
			Field<PessoaInputType>("entidadeEmpregadora");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<TipoRendimentoInputType>("tipoRendimento");
			Field<ListGraphType<ComponenteSalarialPessoaInputType>>("componenteSalarialPessoa");
			Field<ListGraphType<PessoaProfissaoInputType>>("pessoaProfissao");
			
		}
	}
}