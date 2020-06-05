using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContratadosAssinantesType : ObjectGraphType<ContratadosAssinantes>
    {
        public ContratadosAssinantesType()
        {
            // Defining the name of the object
            Name = "contratadosAssinantes";

            Field(x => x.IdContratadosAssinante, nullable: true);
            Field(x => x.AssinanteId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodContratadosAssinantes, nullable: true);
            Field(x => x.ContratadoId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ContratoId, nullable: true);
            FieldAsync<AssinantesType>("assinante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Assinantes>(c.Source.AssinanteId)));
            FieldAsync<ContratadosType>("contratado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contratados>(c.Source.ContratadoId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            
        }
    }

    public class ContratadosAssinantesInputType : InputObjectGraphType
	{
		public ContratadosAssinantesInputType()
		{
			// Defining the name of the object
			Name = "contratadosAssinantesInput";
			
            //Field<StringGraphType>("idContratadosAssinante");
			Field<StringGraphType>("assinanteId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("codContratadosAssinantes");
			Field<StringGraphType>("contratadoId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("contratoId");
			Field<AssinantesInputType>("assinante");
			Field<ContratadosInputType>("contratado");
			Field<ContratoInputType>("contrato");
			
		}
	}
}