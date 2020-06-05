using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoFranquiaMedicamentoType : ObjectGraphType<DescontoFranquiaMedicamento>
    {
        public DescontoFranquiaMedicamentoType()
        {
            // Defining the name of the object
            Name = "descontoFranquiaMedicamento";

            Field(x => x.IdDescontoFranquia, nullable: true);
            Field(x => x.ValorFranquia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorDesconto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoFranquiaId, nullable: true);
            Field(x => x.TipoLevantamentoMedicamentoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CategoriaFranquiaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoFranquiaType>("tipoFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoFranquia>(c.Source.TipoFranquiaId)));
            FieldAsync<TipoLevantamentoMedicamentoType>("tipoLevantamentoMedicamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoLevantamentoMedicamento>(c.Source.TipoLevantamentoMedicamentoId)));
            
        }
    }

    public class DescontoFranquiaMedicamentoInputType : InputObjectGraphType
	{
		public DescontoFranquiaMedicamentoInputType()
		{
			// Defining the name of the object
			Name = "descontoFranquiaMedicamentoInput";
			
            //Field<StringGraphType>("idDescontoFranquia");
			Field<FloatGraphType>("valorFranquia");
			Field<FloatGraphType>("valorDesconto");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("tipoFranquiaId");
			Field<StringGraphType>("tipoLevantamentoMedicamentoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("categoriaFranquiaId");
			Field<EstadoInputType>("estado");
			Field<TipoFranquiaInputType>("tipoFranquia");
			Field<TipoLevantamentoMedicamentoInputType>("tipoLevantamentoMedicamento");
			
		}
	}
}