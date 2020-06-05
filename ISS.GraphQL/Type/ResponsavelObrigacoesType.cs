using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ResponsavelObrigacoesType : ObjectGraphType<ResponsavelObrigacoes>
    {
        public ResponsavelObrigacoesType()
        {
            // Defining the name of the object
            Name = "responsavelObrigacoes";

            Field(x => x.IdResponsavelObrigacoes, nullable: true);
            Field(x => x.CodResponsavelObrigacoes, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ObrigacoesProdutoType>>("obrigacoesProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObrigacoesProduto>(x => x.Where(e => e.HasValue(c.Source.IdResponsavelObrigacoes)))));
            
        }
    }

    public class ResponsavelObrigacoesInputType : InputObjectGraphType
	{
		public ResponsavelObrigacoesInputType()
		{
			// Defining the name of the object
			Name = "responsavelObrigacoesInput";
			
            //Field<StringGraphType>("idResponsavelObrigacoes");
			Field<StringGraphType>("codResponsavelObrigacoes");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ObrigacoesProdutoInputType>>("obrigacoesProduto");
			
		}
	}
}