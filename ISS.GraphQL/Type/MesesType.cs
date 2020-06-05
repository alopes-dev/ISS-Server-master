using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MesesType : ObjectGraphType<Meses>
    {
        public MesesType()
        {
            // Defining the name of the object
            Name = "meses";

            Field(x => x.IdMes, nullable: true);
            Field(x => x.Mes, nullable: true);
            Field(x => x.CodMeses, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PeriodoAnualImpostoType>>("periodoAnualImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PeriodoAnualImposto>(x => x.Where(e => e.HasValue(c.Source.IdMes)))));
            FieldAsync<ListGraphType<PeriodoCalculoType>>("periodoCalculo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PeriodoCalculo>(x => x.Where(e => e.HasValue(c.Source.IdMes)))));
            FieldAsync<ListGraphType<TarifasAutomovelType>>("tarifasAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdMes)))));
            
        }
    }

    public class MesesInputType : InputObjectGraphType
	{
		public MesesInputType()
		{
			// Defining the name of the object
			Name = "mesesInput";
			
            //Field<StringGraphType>("idMes");
			Field<StringGraphType>("mes");
			Field<StringGraphType>("codMeses");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PeriodoAnualImpostoInputType>>("periodoAnualImposto");
			Field<ListGraphType<PeriodoCalculoInputType>>("periodoCalculo");
			Field<ListGraphType<TarifasAutomovelInputType>>("tarifasAutomovel");
			
		}
	}
}