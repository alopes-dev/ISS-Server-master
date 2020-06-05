using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AnosType : ObjectGraphType<Anos>
    {
        public AnosType()
        {
            // Defining the name of the object
            Name = "anos";

            Field(x => x.IdAno, nullable: true);
            Field(x => x.Ano, nullable: true);
            Field(x => x.CodAnos, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<TarifasAutomovelType>>("tarifasAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdAno)))));
            
        }
    }

    public class AnosInputType : InputObjectGraphType
	{
		public AnosInputType()
		{
			// Defining the name of the object
			Name = "anosInput";
			
            //Field<StringGraphType>("idAno");
			Field<StringGraphType>("ano");
			Field<StringGraphType>("codAnos");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<TarifasAutomovelInputType>>("tarifasAutomovel");
			
		}
	}
}