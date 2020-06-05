using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratantesAssinantesType : ObjectGraphType<ContratantesAssinantes>
    {
        public ContratantesAssinantesType()
        {
            // Defining the name of the object
            Name = "contratantesAssinantes";

            Field(x => x.IdContratanteAssinante, nullable: true);
            Field(x => x.AssinanteId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodContratanteAssinante, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ContratanteId, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            FieldAsync<AssinantesType>("assinante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Assinantes>(c.Source.AssinanteId)));
            FieldAsync<PessoaType>("contratante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ContratanteId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            
        }
    }

    public class ContratantesAssinantesInputType : InputObjectGraphType
	{
		public ContratantesAssinantesInputType()
		{
			// Defining the name of the object
			Name = "contratantesAssinantesInput";
			
            //Field<StringGraphType>("idContratanteAssinante");
			Field<StringGraphType>("assinanteId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("codContratanteAssinante");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("contratanteId");
			Field<StringGraphType>("contratoId");
			Field<AssinantesInputType>("assinante");
			Field<PessoaInputType>("contratante");
			Field<ContratoInputType>("contrato");
			
		}
	}
}