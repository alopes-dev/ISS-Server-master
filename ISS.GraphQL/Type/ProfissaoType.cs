using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProfissaoType : ObjectGraphType<Profissao>
    {
        public ProfissaoType()
        {
            // Defining the name of the object
            Name = "profissao";

            Field(x => x.IdProfissao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.NivelRiscoId, nullable: true);
            Field(x => x.CodProfissao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<NivelRiscoType>("nivelRisco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelRisco>(c.Source.NivelRiscoId)));
            FieldAsync<ListGraphType<PessoaProfissaoType>>("pessoaProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(x => x.Where(e => e.HasValue(c.Source.IdProfissao)))));
            FieldAsync<ListGraphType<ProfissaoPlanoType>>("profissaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProfissaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdProfissao)))));
            
        }
    }

    public class ProfissaoInputType : InputObjectGraphType
	{
		public ProfissaoInputType()
		{
			// Defining the name of the object
			Name = "profissaoInput";
			
            //Field<StringGraphType>("idProfissao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("nivelRiscoId");
			Field<StringGraphType>("codProfissao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<NivelRiscoInputType>("nivelRisco");
			Field<ListGraphType<PessoaProfissaoInputType>>("pessoaProfissao");
			Field<ListGraphType<ProfissaoPlanoInputType>>("profissaoPlano");
			
		}
	}
}