using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClasseModalidadeSeguroType : ObjectGraphType<ClasseModalidadeSeguro>
    {
        public ClasseModalidadeSeguroType()
        {
            // Defining the name of the object
            Name = "classeModalidadeSeguro";

            Field(x => x.IdClasseModalidadeSeguro, nullable: true);
            Field(x => x.CodClasseModalidadeSeguro, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<ListGraphType<SubClasseModalidadeSeguroType>>("subClasseModalidadeSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubClasseModalidadeSeguro>(x => x.Where(e => e.HasValue(c.Source.IdClasseModalidadeSeguro)))));
            
        }
    }

    public class ClasseModalidadeSeguroInputType : InputObjectGraphType
	{
		public ClasseModalidadeSeguroInputType()
		{
			// Defining the name of the object
			Name = "classeModalidadeSeguroInput";
			
            //Field<StringGraphType>("idClasseModalidadeSeguro");
			Field<StringGraphType>("codClasseModalidadeSeguro");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("produtoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ProdutoInputType>("produto");
			Field<ListGraphType<SubClasseModalidadeSeguroInputType>>("subClasseModalidadeSeguro");
			
		}
	}
}