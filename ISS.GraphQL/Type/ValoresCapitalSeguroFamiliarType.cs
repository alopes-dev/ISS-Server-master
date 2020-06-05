using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ValoresCapitalSeguroFamiliarType : ObjectGraphType<ValoresCapitalSeguroFamiliar>
    {
        public ValoresCapitalSeguroFamiliarType()
        {
            // Defining the name of the object
            Name = "valoresCapitalSeguroFamiliar";

            Field(x => x.IdValorCapitalSeguroFamiliar, nullable: true);
            Field(x => x.ValorMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ModalidadeResponsabilidadeCivilId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ModalidadesResponsabilidadeCivilType>("modalidadeResponsabilidadeCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesResponsabilidadeCivil>(c.Source.ModalidadeResponsabilidadeCivilId)));
            
        }
    }

    public class ValoresCapitalSeguroFamiliarInputType : InputObjectGraphType
	{
		public ValoresCapitalSeguroFamiliarInputType()
		{
			// Defining the name of the object
			Name = "valoresCapitalSeguroFamiliarInput";
			
            //Field<StringGraphType>("idValorCapitalSeguroFamiliar");
			Field<IntGraphType>("valorMax");
			Field<StringGraphType>("modalidadeResponsabilidadeCivilId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ModalidadesResponsabilidadeCivilInputType>("modalidadeResponsabilidadeCivil");
			
		}
	}
}