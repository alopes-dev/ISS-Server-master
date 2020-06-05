using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoLevantamentoMedicamentoType : ObjectGraphType<TipoLevantamentoMedicamento>
    {
        public TipoLevantamentoMedicamentoType()
        {
            // Defining the name of the object
            Name = "tipoLevantamentoMedicamento";

            Field(x => x.IdTipoLevantamentoMedicamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoLevantamentoMedicamento, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<DescontoFranquiaMedicamentoType>>("descontoFranquiaMedicamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoFranquiaMedicamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoLevantamentoMedicamento)))));
            
        }
    }

    public class TipoLevantamentoMedicamentoInputType : InputObjectGraphType
	{
		public TipoLevantamentoMedicamentoInputType()
		{
			// Defining the name of the object
			Name = "tipoLevantamentoMedicamentoInput";
			
            //Field<StringGraphType>("idTipoLevantamentoMedicamento");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoLevantamentoMedicamento");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<DescontoFranquiaMedicamentoInputType>>("descontoFranquiaMedicamento");
			
		}
	}
}