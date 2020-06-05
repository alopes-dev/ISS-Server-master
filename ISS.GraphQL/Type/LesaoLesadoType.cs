using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LesaoLesadoType : ObjectGraphType<LesaoLesado>
    {
        public LesaoLesadoType()
        {
            // Defining the name of the object
            Name = "lesaoLesado";

            Field(x => x.IdLesaoLesado, nullable: true);
            Field(x => x.DescricaoLesao, nullable: true);
            Field(x => x.IncapacidadetemporariaId, nullable: true);
            Field(x => x.LesadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<IncapacidadeTemporariaType>("incapacidadetemporaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<IncapacidadeTemporaria>(c.Source.IncapacidadetemporariaId)));
            FieldAsync<LesadoType>("lesado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Lesado>(c.Source.LesadoId)));
            
        }
    }

    public class LesaoLesadoInputType : InputObjectGraphType
	{
		public LesaoLesadoInputType()
		{
			// Defining the name of the object
			Name = "lesaoLesadoInput";
			
            //Field<StringGraphType>("idLesaoLesado");
			Field<StringGraphType>("descricaoLesao");
			Field<StringGraphType>("incapacidadetemporariaId");
			Field<StringGraphType>("lesadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<IncapacidadeTemporariaInputType>("incapacidadetemporaria");
			Field<LesadoInputType>("lesado");
			
		}
	}
}