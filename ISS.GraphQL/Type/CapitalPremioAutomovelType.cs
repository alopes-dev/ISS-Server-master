using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CapitalPremioAutomovelType : ObjectGraphType<CapitalPremioAutomovel>
    {
        public CapitalPremioAutomovelType()
        {
            // Defining the name of the object
            Name = "capitalPremioAutomovel";

            Field(x => x.IdCapitalPremioAutomovel, nullable: true);
            Field(x => x.ClassificacaoAutomovelId, nullable: true);
            Field(x => x.Premio, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ClassificacaoAutomovelType>("classificacaoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAutomovel>(c.Source.ClassificacaoAutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CapitalPremioAutomovelInputType : InputObjectGraphType
	{
		public CapitalPremioAutomovelInputType()
		{
			// Defining the name of the object
			Name = "capitalPremioAutomovelInput";
			
            //Field<StringGraphType>("idCapitalPremioAutomovel");
			Field<StringGraphType>("classificacaoAutomovelId");
			Field<IntGraphType>("premio");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<ClassificacaoAutomovelInputType>("classificacaoAutomovel");
			Field<EstadoInputType>("estado");
			
		}
	}
}