using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TermoResponsabilidadeType : ObjectGraphType<TermoResponsabilidade>
    {
        public TermoResponsabilidadeType()
        {
            // Defining the name of the object
            Name = "termoResponsabilidade";

            Field(x => x.IdTermoResponsabilidade, nullable: true);
            Field(x => x.NumeroDoc, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.DataEmissao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PessoaSegura, nullable: true);
            Field(x => x.Empregado, nullable: true);
            Field(x => x.PrestadorServico, nullable: true);
            Field(x => x.MedicoPrescritor, nullable: true);
            Field(x => x.ServicoPrestadoId, nullable: true);
            Field(x => x.TaxaComparticipacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Observacoes, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.LimiteMaximoIndemnizacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodTermoResponsabilidade, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<FuncionarioType>("empregadoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.Empregado)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FuncionarioType>("medicoPrescritorNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.MedicoPrescritor)));
            FieldAsync<PessoaType>("pessoaSeguraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaSegura)));
            FieldAsync<PessoaType>("prestadorServicoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PrestadorServico)));
            FieldAsync<AtosMedicosType>("servicoPrestado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AtosMedicos>(c.Source.ServicoPrestadoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            
        }
    }

    public class TermoResponsabilidadeInputType : InputObjectGraphType
	{
		public TermoResponsabilidadeInputType()
		{
			// Defining the name of the object
			Name = "termoResponsabilidadeInput";
			
            //Field<StringGraphType>("idTermoResponsabilidade");
			Field<IntGraphType>("numeroDoc");
			Field<StringGraphType>("apoliceId");
			Field<DateTimeGraphType>("dataEmissao");
			Field<StringGraphType>("pessoaSegura");
			Field<StringGraphType>("empregado");
			Field<StringGraphType>("prestadorServico");
			Field<StringGraphType>("medicoPrescritor");
			Field<StringGraphType>("servicoPrestadoId");
			Field<FloatGraphType>("taxaComparticipacao");
			Field<StringGraphType>("observacoes");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("limiteMaximoIndemnizacao");
			Field<StringGraphType>("codTermoResponsabilidade");
			Field<StringGraphType>("tipoCoberturaId");
			Field<ApoliceInputType>("apolice");
			Field<FuncionarioInputType>("empregadoNavigation");
			Field<EstadoInputType>("estado");
			Field<FuncionarioInputType>("medicoPrescritorNavigation");
			Field<PessoaInputType>("pessoaSeguraNavigation");
			Field<PessoaInputType>("prestadorServicoNavigation");
			Field<AtosMedicosInputType>("servicoPrestado");
			Field<TipoCoberturaInputType>("tipoCobertura");
			
		}
	}
}