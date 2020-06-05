using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratadosType : ObjectGraphType<Contratados>
    {
        public ContratadosType()
        {
            // Defining the name of the object
            Name = "contratados";

            Field(x => x.IdContratado, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodContratado, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<ListGraphType<ContratadosAssinantesType>>("contratadosAssinantes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratadosAssinantes>(x => x.Where(e => e.HasValue(c.Source.IdContratado)))));
            
        }
    }

    public class ContratadosInputType : InputObjectGraphType
	{
		public ContratadosInputType()
		{
			// Defining the name of the object
			Name = "contratadosInput";
			
            //Field<StringGraphType>("idContratado");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codContratado");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("pessoaId");
			Field<ContratoInputType>("contrato");
			Field<PessoaInputType>("pessoa");
			Field<ListGraphType<ContratadosAssinantesInputType>>("contratadosAssinantes");
			
		}
	}
}