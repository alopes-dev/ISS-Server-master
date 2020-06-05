using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DimensaoConstrucaoType : ObjectGraphType<DimensaoConstrucao>
    {
        public DimensaoConstrucaoType()
        {
            // Defining the name of the object
            Name = "dimensaoConstrucao";

            Field(x => x.IdDimensaoConstrucao, nullable: true);
            Field(x => x.Dimensao, nullable: true);
            Field(x => x.Comprimento, nullable: true);
            Field(x => x.Largura, nullable: true);
            Field(x => x.Altura, nullable: true);
            Field(x => x.Profundidade, nullable: true);
            Field(x => x.ConstrucaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ConstrucaoType>("construcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Construcao>(c.Source.ConstrucaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class DimensaoConstrucaoInputType : InputObjectGraphType
	{
		public DimensaoConstrucaoInputType()
		{
			// Defining the name of the object
			Name = "dimensaoConstrucaoInput";
			
            //Field<StringGraphType>("idDimensaoConstrucao");
			Field<StringGraphType>("dimensao");
			Field<StringGraphType>("comprimento");
			Field<StringGraphType>("largura");
			Field<StringGraphType>("altura");
			Field<StringGraphType>("profundidade");
			Field<StringGraphType>("construcaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<ConstrucaoInputType>("construcao");
			Field<EstadoInputType>("estado");
			
		}
	}
}