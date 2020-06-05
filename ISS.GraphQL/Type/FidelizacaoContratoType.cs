using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FidelizacaoContratoType : ObjectGraphType<FidelizacaoContrato>
    {
        public FidelizacaoContratoType()
        {
            // Defining the name of the object
            Name = "fidelizacaoContrato";

            Field(x => x.IdFidelizacaoContrato, nullable: true);
            Field(x => x.CodFidelizacaoContrato, nullable: true);
            Field(x => x.FidelizacaoId, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<FidelizacaoType>("fidelizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fidelizacao>(c.Source.FidelizacaoId)));
            
        }
    }

    public class FidelizacaoContratoInputType : InputObjectGraphType
	{
		public FidelizacaoContratoInputType()
		{
			// Defining the name of the object
			Name = "fidelizacaoContratoInput";
			
            //Field<StringGraphType>("idFidelizacaoContrato");
			Field<StringGraphType>("codFidelizacaoContrato");
			Field<StringGraphType>("fidelizacaoId");
			Field<StringGraphType>("contratoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ContratoInputType>("contrato");
			Field<FidelizacaoInputType>("fidelizacao");
			
		}
	}
}