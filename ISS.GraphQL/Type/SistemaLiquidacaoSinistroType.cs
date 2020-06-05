using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SistemaLiquidacaoSinistroType : ObjectGraphType<SistemaLiquidacaoSinistro>
    {
        public SistemaLiquidacaoSinistroType()
        {
            // Defining the name of the object
            Name = "sistemaLiquidacaoSinistro";

            Field(x => x.IdSistemaLiquidacaoSinistro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodSistemaLiquidacaoSinistro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CoSeguroType>>("coSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoSeguro>(x => x.Where(e => e.HasValue(c.Source.IdSistemaLiquidacaoSinistro)))));
            
        }
    }

    public class SistemaLiquidacaoSinistroInputType : InputObjectGraphType
	{
		public SistemaLiquidacaoSinistroInputType()
		{
			// Defining the name of the object
			Name = "sistemaLiquidacaoSinistroInput";
			
            //Field<StringGraphType>("idSistemaLiquidacaoSinistro");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codSistemaLiquidacaoSinistro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CoSeguroInputType>>("coSeguro");
			
		}
	}
}