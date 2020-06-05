using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrestadorServicoType : ObjectGraphType<PrestadorServico>
    {
        public PrestadorServicoType()
        {
            // Defining the name of the object
            Name = "prestadorServico";

            Field(x => x.IdPrestadorServico, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodPrestadorServico, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<ListGraphType<ServicoType>>("servico", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Servico>(x => x.Where(e => e.HasValue(c.Source.IdPrestadorServico)))));
            
        }
    }

    public class PrestadorServicoInputType : InputObjectGraphType
	{
		public PrestadorServicoInputType()
		{
			// Defining the name of the object
			Name = "prestadorServicoInput";
			
            //Field<StringGraphType>("idPrestadorServico");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codPrestadorServico");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<ListGraphType<ServicoInputType>>("servico");
			
		}
	}
}