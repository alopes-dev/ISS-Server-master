using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ObjectivosComerciaisType : ObjectGraphType<ObjectivosComerciais>
    {
        public ObjectivosComerciaisType()
        {
            // Defining the name of the object
            Name = "objectivosComerciais";

            Field(x => x.IdobjectivosComerciais, nullable: true);
            Field(x => x.NumObjectivo, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorProgamado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorRealizado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ProdutoId, nullable: true);
            Field(x => x.CodObjectivosComerciais, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LinhaProdutoType>("linhaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LinhaProduto>(c.Source.LinhaProdutoId)));
            FieldAsync<ProdutoType>("produto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Produto>(c.Source.ProdutoId)));
            FieldAsync<ListGraphType<LocaisObjectivosComerciaisType>>("locaisObjectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdobjectivosComerciais)))));
            FieldAsync<ListGraphType<SegmentoObjectivosComerciaisType>>("segmentoObjectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdobjectivosComerciais)))));
            
        }
    }

    public class ObjectivosComerciaisInputType : InputObjectGraphType
	{
		public ObjectivosComerciaisInputType()
		{
			// Defining the name of the object
			Name = "objectivosComerciaisInput";
			
            //Field<StringGraphType>("idobjectivosComerciais");
			Field<IntGraphType>("numObjectivo");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFim");
			Field<FloatGraphType>("valorProgamado");
			Field<FloatGraphType>("valorRealizado");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("produtoId");
			Field<StringGraphType>("codObjectivosComerciais");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LinhaProdutoInputType>("linhaProduto");
			Field<ProdutoInputType>("produto");
			Field<ListGraphType<LocaisObjectivosComerciaisInputType>>("locaisObjectivosComerciais");
			Field<ListGraphType<SegmentoObjectivosComerciaisInputType>>("segmentoObjectivosComerciais");
			
		}
	}
}