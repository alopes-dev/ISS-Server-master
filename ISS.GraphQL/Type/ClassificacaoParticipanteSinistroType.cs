using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoParticipanteSinistroType : ObjectGraphType<ClassificacaoParticipanteSinistro>
    {
        public ClassificacaoParticipanteSinistroType()
        {
            // Defining the name of the object
            Name = "classificacaoParticipanteSinistro";

            Field(x => x.IdClassificacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodClassificacaoParticipanteSinistro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<SinistroType>>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(x => x.Where(e => e.HasValue(c.Source.IdClassificacao)))));
            
        }
    }

    public class ClassificacaoParticipanteSinistroInputType : InputObjectGraphType
	{
		public ClassificacaoParticipanteSinistroInputType()
		{
			// Defining the name of the object
			Name = "classificacaoParticipanteSinistroInput";
			
            //Field<StringGraphType>("idClassificacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codClassificacaoParticipanteSinistro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<SinistroInputType>>("sinistro");
			
		}
	}
}