using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExemplarModeloAutomovelType : ObjectGraphType<ExemplarModeloAutomovel>
    {
        public ExemplarModeloAutomovelType()
        {
            // Defining the name of the object
            Name = "exemplarModeloAutomovel";

            Field(x => x.IdExemplar, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.Referencia, nullable: true);
            Field(x => x.AnoFabrico, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ModeloAutomovelId, nullable: true);
            Field(x => x.CombustivelId, nullable: true);
            Field(x => x.CodExemplarModeloAutomovel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CombustivelType>("combustivel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Combustivel>(c.Source.CombustivelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ModeloAutomovelType>("modeloAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModeloAutomovel>(c.Source.ModeloAutomovelId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdExemplar)))));
            
        }
    }

    public class ExemplarModeloAutomovelInputType : InputObjectGraphType
	{
		public ExemplarModeloAutomovelInputType()
		{
			// Defining the name of the object
			Name = "exemplarModeloAutomovelInput";
			
            //Field<StringGraphType>("idExemplar");
			Field<StringGraphType>("nome");
			Field<StringGraphType>("referencia");
			Field<IntGraphType>("anoFabrico");
			Field<StringGraphType>("modeloAutomovelId");
			Field<StringGraphType>("combustivelId");
			Field<StringGraphType>("codExemplarModeloAutomovel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CombustivelInputType>("combustivel");
			Field<EstadoInputType>("estado");
			Field<ModeloAutomovelInputType>("modeloAutomovel");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			
		}
	}
}