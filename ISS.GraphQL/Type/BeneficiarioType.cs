using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BeneficiarioType : ObjectGraphType<Beneficiario>
    {
        public BeneficiarioType()
        {
            // Defining the name of the object
            Name = "beneficiario";

            Field(x => x.IdBeneficiario, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.GrauParentescoId, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.Obs, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<GrauParentescoType>("grauParentesco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GrauParentesco>(c.Source.GrauParentescoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class BeneficiarioInputType : InputObjectGraphType
	{
		public BeneficiarioInputType()
		{
			// Defining the name of the object
			Name = "beneficiarioInput";
			
            //Field<StringGraphType>("idBeneficiario");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("grauParentescoId");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("obs");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("apoliceId");
			Field<ApoliceInputType>("apolice");
			Field<CotacaoInputType>("cotacao");
			Field<GrauParentescoInputType>("grauParentesco");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}