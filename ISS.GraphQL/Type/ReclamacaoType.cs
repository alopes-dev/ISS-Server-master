using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ReclamacaoType : ObjectGraphType<Reclamacao>
    {
        public ReclamacaoType()
        {
            // Defining the name of the object
            Name = "reclamacao";

            Field(x => x.IdReclamacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataPreenchimentoFormulario, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataHoraEfectividadeEstado, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CompletamenteResolvido, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodigoResponsabilidadeId, nullable: true);
            Field(x => x.RazaoPeloRecuso, nullable: true);
            Field(x => x.CausadorDoIncidenteId, nullable: true);
            Field(x => x.DescricaoCulpadoIncidente, nullable: true);
            Field(x => x.ApoliceCancelada, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ReclamadorAlugouCarro, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.SeguradorAceitaCustoAluguel, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ApoliceEstadoRenovacao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ResponsavelPelaReclamacaoId, nullable: true);
            Field(x => x.ReclamadorId, nullable: true);
            Field(x => x.PessoaRelacionadaId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.ClassificacaoReclamacaoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PerdaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodReclamacao, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<PessoaType>("causadorDoIncidente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.CausadorDoIncidenteId)));
            FieldAsync<ClassificacaoReclamacaoType>("classificacaoReclamacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoReclamacao>(c.Source.ClassificacaoReclamacaoId)));
            FieldAsync<CodigoResponsabilidadeType>("codigoResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CodigoResponsabilidade>(c.Source.CodigoResponsabilidadeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PerdaType>("perda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perda>(c.Source.PerdaId)));
            FieldAsync<PessoaType>("pessoaRelacionada", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaRelacionadaId)));
            FieldAsync<PessoaType>("reclamador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ReclamadorId)));
            FieldAsync<PessoaType>("responsavelPelaReclamacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ResponsavelPelaReclamacaoId)));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdReclamacao)))));
            
        }
    }

    public class ReclamacaoInputType : InputObjectGraphType
	{
		public ReclamacaoInputType()
		{
			// Defining the name of the object
			Name = "reclamacaoInput";
			
            //Field<StringGraphType>("idReclamacao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataPreenchimentoFormulario");
			Field<DateTimeGraphType>("dataHoraEfectividadeEstado");
			Field<BooleanGraphType>("completamenteResolvido");
			Field<StringGraphType>("codigoResponsabilidadeId");
			Field<StringGraphType>("razaoPeloRecuso");
			Field<StringGraphType>("causadorDoIncidenteId");
			Field<StringGraphType>("descricaoCulpadoIncidente");
			Field<BooleanGraphType>("apoliceCancelada");
			Field<BooleanGraphType>("reclamadorAlugouCarro");
			Field<BooleanGraphType>("seguradorAceitaCustoAluguel");
			Field<BooleanGraphType>("apoliceEstadoRenovacao");
			Field<StringGraphType>("responsavelPelaReclamacaoId");
			Field<StringGraphType>("reclamadorId");
			Field<StringGraphType>("pessoaRelacionadaId");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("classificacaoReclamacaoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("perdaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codReclamacao");
			Field<ApoliceInputType>("apolice");
			Field<PessoaInputType>("causadorDoIncidente");
			Field<ClassificacaoReclamacaoInputType>("classificacaoReclamacao");
			Field<CodigoResponsabilidadeInputType>("codigoResponsabilidade");
			Field<EstadoInputType>("estado");
			Field<PerdaInputType>("perda");
			Field<PessoaInputType>("pessoaRelacionada");
			Field<PessoaInputType>("reclamador");
			Field<PessoaInputType>("responsavelPelaReclamacao");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			
		}
	}
}