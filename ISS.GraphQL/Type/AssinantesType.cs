using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AssinantesType : ObjectGraphType<Assinantes>
    {
        public AssinantesType()
        {
            // Defining the name of the object
            Name = "assinantes";

            Field(x => x.IdAssinante, nullable: true);
            Field(x => x.CodAssinante, nullable: true);
            Field(x => x.AssinanteId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<PessoaType>("assinante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.AssinanteId)));
            FieldAsync<ListGraphType<ContratadosAssinantesType>>("contratadosAssinantes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratadosAssinantes>(x => x.Where(e => e.HasValue(c.Source.IdAssinante)))));
            FieldAsync<ListGraphType<ContratantesAssinantesType>>("contratantesAssinantes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratantesAssinantes>(x => x.Where(e => e.HasValue(c.Source.IdAssinante)))));
            
        }
    }

    public class AssinantesInputType : InputObjectGraphType
	{
		public AssinantesInputType()
		{
			// Defining the name of the object
			Name = "assinantesInput";
			
            //Field<StringGraphType>("idAssinante");
			Field<StringGraphType>("codAssinante");
			Field<StringGraphType>("assinanteId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<PessoaInputType>("assinante");
			Field<ListGraphType<ContratadosAssinantesInputType>>("contratadosAssinantes");
			Field<ListGraphType<ContratantesAssinantesInputType>>("contratantesAssinantes");
			
		}
	}
}