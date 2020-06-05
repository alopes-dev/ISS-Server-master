using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModeloAutomovelType : ObjectGraphType<ModeloAutomovel>
    {
        public ModeloAutomovelType()
        {
            // Defining the name of the object
            Name = "modeloAutomovel";

            Field(x => x.IdModeloAutomovel, nullable: true);
            Field(x => x.Modelo, nullable: true);
            Field(x => x.MarcaAutomovelId, nullable: true);
            Field(x => x.CodModeloAutomovel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MarcaAutomovelType>("marcaAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MarcaAutomovel>(c.Source.MarcaAutomovelId)));
            FieldAsync<ListGraphType<ExemplarModeloAutomovelType>>("exemplarModeloAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExemplarModeloAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdModeloAutomovel)))));
            
        }
    }

    public class ModeloAutomovelInputType : InputObjectGraphType
	{
		public ModeloAutomovelInputType()
		{
			// Defining the name of the object
			Name = "modeloAutomovelInput";
			
            //Field<StringGraphType>("idModeloAutomovel");
			Field<StringGraphType>("modelo");
			Field<StringGraphType>("marcaAutomovelId");
			Field<StringGraphType>("codModeloAutomovel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<MarcaAutomovelInputType>("marcaAutomovel");
			Field<ListGraphType<ExemplarModeloAutomovelInputType>>("exemplarModeloAutomovel");
			
		}
	}
}