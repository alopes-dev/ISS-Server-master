using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MotivoViagemType : ObjectGraphType<MotivoViagem>
    {
        public MotivoViagemType()
        {
            // Defining the name of the object
            Name = "motivoViagem";

            Field(x => x.IdMotivoViagem, nullable: true);
            Field(x => x.Motivo, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodMotivoViagem, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            
        }
    }

    public class MotivoViagemInputType : InputObjectGraphType
	{
		public MotivoViagemInputType()
		{
			// Defining the name of the object
			Name = "motivoViagemInput";
			
            //Field<StringGraphType>("idMotivoViagem");
			Field<StringGraphType>("motivo");
			Field<StringGraphType>("linhaProdutoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codMotivoViagem");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			
		}
	}
}