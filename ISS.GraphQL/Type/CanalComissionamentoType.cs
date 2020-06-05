using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CanalComissionamentoType : ObjectGraphType<CanalComissionamento>
    {
        public CanalComissionamentoType()
        {
            // Defining the name of the object
            Name = "canalComissionamento";

            Field(x => x.IdCriterioComissionamento, nullable: true);
            Field(x => x.ComissionamentoId, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CriterioComissionamentoId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodCriterioComissionamento, nullable: true);
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<ComissionamentoType>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(c.Source.ComissionamentoId)));
            FieldAsync<CriterioComissionamentoType>("criterioComissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CriterioComissionamento>(c.Source.CriterioComissionamentoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CanalComissionamentoInputType : InputObjectGraphType
	{
		public CanalComissionamentoInputType()
		{
			// Defining the name of the object
			Name = "canalComissionamentoInput";
			
            //Field<StringGraphType>("idCriterioComissionamento");
			Field<StringGraphType>("comissionamentoId");
			Field<StringGraphType>("canalId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("criterioComissionamentoId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codCriterioComissionamento");
			Field<CanalInputType>("canal");
			Field<ComissionamentoInputType>("comissionamento");
			Field<CriterioComissionamentoInputType>("criterioComissionamento");
			Field<EstadoInputType>("estado");
			
		}
	}
}