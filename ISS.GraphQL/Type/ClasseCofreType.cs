using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClasseCofreType : ObjectGraphType<ClasseCofre>
    {
        public ClasseCofreType()
        {
            // Defining the name of the object
            Name = "classeCofre";

            Field(x => x.IdClasseCofre, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodClasseCofre, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CofreType>>("cofre", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cofre>(x => x.Where(e => e.HasValue(c.Source.IdClasseCofre)))));
            
        }
    }

    public class ClasseCofreInputType : InputObjectGraphType
	{
		public ClasseCofreInputType()
		{
			// Defining the name of the object
			Name = "classeCofreInput";
			
            //Field<StringGraphType>("idClasseCofre");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codClasseCofre");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CofreInputType>>("cofre");
			
		}
	}
}