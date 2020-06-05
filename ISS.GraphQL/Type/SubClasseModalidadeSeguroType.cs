using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubClasseModalidadeSeguroType : ObjectGraphType<SubClasseModalidadeSeguro>
    {
        public SubClasseModalidadeSeguroType()
        {
            // Defining the name of the object
            Name = "subClasseModalidadeSeguro";

            Field(x => x.IdSubClasseModalidadeSeguro, nullable: true);
            Field(x => x.CodSubClasseModalidadeSeguro, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.ClasseModalidadeSeguroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ClasseModalidadeSeguroType>("classeModalidadeSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClasseModalidadeSeguro>(c.Source.ClasseModalidadeSeguroId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class SubClasseModalidadeSeguroInputType : InputObjectGraphType
	{
		public SubClasseModalidadeSeguroInputType()
		{
			// Defining the name of the object
			Name = "subClasseModalidadeSeguroInput";
			
            //Field<StringGraphType>("idSubClasseModalidadeSeguro");
			Field<StringGraphType>("codSubClasseModalidadeSeguro");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("classeModalidadeSeguroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<ClasseModalidadeSeguroInputType>("classeModalidadeSeguro");
			Field<EstadoInputType>("estado");
			
		}
	}
}