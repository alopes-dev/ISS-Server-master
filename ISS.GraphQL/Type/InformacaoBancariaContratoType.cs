using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class InformacaoBancariaContratoType : ObjectGraphType<InformacaoBancariaContrato>
    {
        public InformacaoBancariaContratoType()
        {
            // Defining the name of the object
            Name = "informacaoBancariaContrato";

            Field(x => x.IdInformacaoBancariaContrato, nullable: true);
            Field(x => x.InformacaoBancariaId, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.CodInformacaoBancariaContrato, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<InformacaoBancariaType>("informacaoBancaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(c.Source.InformacaoBancariaId)));
            
        }
    }

    public class InformacaoBancariaContratoInputType : InputObjectGraphType
	{
		public InformacaoBancariaContratoInputType()
		{
			// Defining the name of the object
			Name = "informacaoBancariaContratoInput";
			
            //Field<StringGraphType>("idInformacaoBancariaContrato");
			Field<StringGraphType>("informacaoBancariaId");
			Field<StringGraphType>("contratoId");
			Field<StringGraphType>("codInformacaoBancariaContrato");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ContratoInputType>("contrato");
			Field<InformacaoBancariaInputType>("informacaoBancaria");
			
		}
	}
}