using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LimiteGarantiaResponsabilidadeCivilType : ObjectGraphType<LimiteGarantiaResponsabilidadeCivil>
    {
        public LimiteGarantiaResponsabilidadeCivilType()
        {
            // Defining the name of the object
            Name = "limiteGarantiaResponsabilidadeCivil";

            Field(x => x.IdTerceiroSujeitoDano, nullable: true);
            Field(x => x.CodTerceiroSujeitoDano, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CategoriaSujeitoDanoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PesoMaximo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PesoMinimo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Unidade, nullable: true);
            Field(x => x.LimiteGarantiaResponsabilidadeCivil1, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<CategoriaSujeitoDanoType>("categoriaSujeitoDano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaSujeitoDano>(c.Source.CategoriaSujeitoDanoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class LimiteGarantiaResponsabilidadeCivilInputType : InputObjectGraphType
	{
		public LimiteGarantiaResponsabilidadeCivilInputType()
		{
			// Defining the name of the object
			Name = "limiteGarantiaResponsabilidadeCivilInput";
			
            //Field<StringGraphType>("idTerceiroSujeitoDano");
			Field<StringGraphType>("codTerceiroSujeitoDano");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("categoriaSujeitoDanoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("pesoMaximo");
			Field<FloatGraphType>("pesoMinimo");
			Field<StringGraphType>("unidade");
			Field<FloatGraphType>("limiteGarantiaResponsabilidadeCivil1");
			Field<CategoriaSujeitoDanoInputType>("categoriaSujeitoDano");
			Field<EstadoInputType>("estado");
			
		}
	}
}