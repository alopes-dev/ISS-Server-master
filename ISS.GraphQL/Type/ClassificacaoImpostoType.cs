using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoImpostoType : ObjectGraphType<ClassificacaoImposto>
    {
        public ClassificacaoImpostoType()
        {
            // Defining the name of the object
            Name = "classificacaoImposto";

            Field(x => x.IdClassificacaoImposto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodClassificacaoImposto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<TipoImpostoType>>("tipoImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoImposto>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoImposto)))));
            
        }
    }

    public class ClassificacaoImpostoInputType : InputObjectGraphType
	{
		public ClassificacaoImpostoInputType()
		{
			// Defining the name of the object
			Name = "classificacaoImpostoInput";
			
            //Field<StringGraphType>("idClassificacaoImposto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codClassificacaoImposto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<TipoImpostoInputType>>("tipoImposto");
			
		}
	}
}