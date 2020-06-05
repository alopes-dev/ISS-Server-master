using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RelatorioContaType : ObjectGraphType<RelatorioConta>
    {
        public RelatorioContaType()
        {
            // Defining the name of the object
            Name = "relatorioConta";

            Field(x => x.IdRelatorioConta, nullable: true);
            Field(x => x.Codigo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.RelatorioId, nullable: true);
            FieldAsync<RelatorioType>("relatorio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Relatorio>(c.Source.RelatorioId)));
            
        }
    }

    public class RelatorioContaInputType : InputObjectGraphType
	{
		public RelatorioContaInputType()
		{
			// Defining the name of the object
			Name = "relatorioContaInput";
			
            //Field<StringGraphType>("idRelatorioConta");
			Field<StringGraphType>("codigo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("relatorioId");
			Field<RelatorioInputType>("relatorio");
			
		}
	}
}