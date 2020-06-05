using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AjudaCampoTabelaType : ObjectGraphType<AjudaCampoTabela>
    {
        public AjudaCampoTabelaType()
        {
            // Defining the name of the object
            Name = "ajudaCampoTabela";

            Field(x => x.Id, nullable: true);
            Field(x => x.NomeTabela, nullable: true);
            Field(x => x.NomeCampo, nullable: true);
            Field(x => x.Ajuda, nullable: true);
            Field(x => x.CodAjudaCampoTabela, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class AjudaCampoTabelaInputType : InputObjectGraphType
	{
		public AjudaCampoTabelaInputType()
		{
			// Defining the name of the object
			Name = "ajudaCampoTabelaInput";
			
            //Field<StringGraphType>("id");
			Field<StringGraphType>("nomeTabela");
			Field<StringGraphType>("nomeCampo");
			Field<StringGraphType>("ajuda");
			Field<StringGraphType>("codAjudaCampoTabela");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}