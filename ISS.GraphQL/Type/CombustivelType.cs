using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CombustivelType : ObjectGraphType<Combustivel>
    {
        public CombustivelType()
        {
            // Defining the name of the object
            Name = "combustivel";

            Field(x => x.IdCombustivel, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCombustivel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ExemplarModeloAutomovelType>>("exemplarModeloAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExemplarModeloAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdCombustivel)))));
            FieldAsync<ListGraphType<SistemaAquecimentoType>>("sistemaAquecimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SistemaAquecimento>(x => x.Where(e => e.HasValue(c.Source.IdCombustivel)))));
            
        }
    }

    public class CombustivelInputType : InputObjectGraphType
	{
		public CombustivelInputType()
		{
			// Defining the name of the object
			Name = "combustivelInput";
			
            //Field<StringGraphType>("idCombustivel");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCombustivel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ExemplarModeloAutomovelInputType>>("exemplarModeloAutomovel");
			Field<ListGraphType<SistemaAquecimentoInputType>>("sistemaAquecimento");
			
		}
	}
}