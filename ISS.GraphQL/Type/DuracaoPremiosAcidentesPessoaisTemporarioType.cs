using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DuracaoPremiosAcidentesPessoaisTemporarioType : ObjectGraphType<DuracaoPremiosAcidentesPessoaisTemporario>
    {
        public DuracaoPremiosAcidentesPessoaisTemporarioType()
        {
            // Defining the name of the object
            Name = "duracaoPremiosAcidentesPessoaisTemporario";

            Field(x => x.IdDuracaoPremiosAcidentesPessoaisTemporario, nullable: true);
            Field(x => x.Duracao, nullable: true);
            Field(x => x.PremioAnual, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PlanoProdutoId, nullable: true);
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DuracaoPremiosAcidentesPessoaisTemporarioInputType : InputObjectGraphType
	{
		public DuracaoPremiosAcidentesPessoaisTemporarioInputType()
		{
			// Defining the name of the object
			Name = "duracaoPremiosAcidentesPessoaisTemporarioInput";
			
            //Field<StringGraphType>("idDuracaoPremiosAcidentesPessoaisTemporario");
			Field<StringGraphType>("duracao");
			Field<FloatGraphType>("premioAnual");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("planoProdutoId");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}