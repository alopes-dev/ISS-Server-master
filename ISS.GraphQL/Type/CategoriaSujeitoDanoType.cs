using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriaSujeitoDanoType : ObjectGraphType<CategoriaSujeitoDano>
    {
        public CategoriaSujeitoDanoType()
        {
            // Defining the name of the object
            Name = "categoriaSujeitoDano";

            Field(x => x.IdCategoriaSujeitoDano, nullable: true);
            Field(x => x.CodCategoriaSujeitoDano, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<ListGraphType<LimiteGarantiaResponsabilidadeCivilType>>("limiteGarantiaResponsabilidadeCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteGarantiaResponsabilidadeCivil>(x => x.Where(e => e.HasValue(c.Source.IdCategoriaSujeitoDano)))));
            
        }
    }

    public class CategoriaSujeitoDanoInputType : InputObjectGraphType
	{
		public CategoriaSujeitoDanoInputType()
		{
			// Defining the name of the object
			Name = "categoriaSujeitoDanoInput";
			
            //Field<StringGraphType>("idCategoriaSujeitoDano");
			Field<StringGraphType>("codCategoriaSujeitoDano");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("produtoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ProdutoInputType>("produto");
			Field<ListGraphType<LimiteGarantiaResponsabilidadeCivilInputType>>("limiteGarantiaResponsabilidadeCivil");
			
		}
	}
}