using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AssinantesResseguroType : ObjectGraphType<AssinantesResseguro>
    {
        public AssinantesResseguroType()
        {
            // Defining the name of the object
            Name = "assinantesResseguro";

            Field(x => x.IdAssinantesResseguro, nullable: true);
            Field(x => x.AssinanteId, nullable: true);
            Field(x => x.ContratoResseguroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<PessoaType>("assinante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.AssinanteId)));
            FieldAsync<ContratoResseguroType>("contratoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoResseguro>(c.Source.ContratoResseguroId)));
            
        }
    }

    public class AssinantesResseguroInputType : InputObjectGraphType
	{
		public AssinantesResseguroInputType()
		{
			// Defining the name of the object
			Name = "assinantesResseguroInput";
			
            //Field<StringGraphType>("idAssinantesResseguro");
			Field<StringGraphType>("assinanteId");
			Field<StringGraphType>("contratoResseguroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<PessoaInputType>("assinante");
			Field<ContratoResseguroInputType>("contratoResseguro");
			
		}
	}
}