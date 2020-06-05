using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FormasCobrancaType : ObjectGraphType<FormasCobranca>
    {
        public FormasCobrancaType()
        {
            // Defining the name of the object
            Name = "formasCobranca";

            Field(x => x.IdFormasCobranca, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFormasCobranca, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdFormasCobranca)))));
            
        }
    }

    public class FormasCobrancaInputType : InputObjectGraphType
	{
		public FormasCobrancaInputType()
		{
			// Defining the name of the object
			Name = "formasCobrancaInput";
			
            //Field<StringGraphType>("idFormasCobranca");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFormasCobranca");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			
		}
	}
}