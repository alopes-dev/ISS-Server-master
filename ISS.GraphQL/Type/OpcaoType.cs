using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OpcaoType : ObjectGraphType<Opcao>
    {
        public OpcaoType()
        {
            // Defining the name of the object
            Name = "opcao";

            Field(x => x.IdOpcao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodOpcao, nullable: true);
            Field(x => x.Datacriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PlanoProdutoType>>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(x => x.Where(e => e.HasValue(c.Source.IdOpcao)))));
            
        }
    }

    public class OpcaoInputType : InputObjectGraphType
	{
		public OpcaoInputType()
		{
			// Defining the name of the object
			Name = "opcaoInput";
			
            //Field<StringGraphType>("idOpcao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codOpcao");
			Field<DateTimeGraphType>("datacriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PlanoProdutoInputType>>("planoProduto");
			
		}
	}
}