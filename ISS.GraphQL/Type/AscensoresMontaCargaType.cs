using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AscensoresMontaCargaType : ObjectGraphType<AscensoresMontaCarga>
    {
        public AscensoresMontaCargaType()
        {
            // Defining the name of the object
            Name = "ascensoresMontaCarga";

            Field(x => x.IdAscensorMontaCarga, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ModalidadeResponsabilidadeCivilId, nullable: true);
            Field(x => x.CodAscensoresMontaCarga, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ModalidadesResponsabilidadeCivilType>("modalidadeResponsabilidadeCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesResponsabilidadeCivil>(c.Source.ModalidadeResponsabilidadeCivilId)));
            FieldAsync<ListGraphType<ClassificacaoAscensoresMontaCargaType>>("classificacaoAscensoresMontaCarga", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAscensoresMontaCarga>(x => x.Where(e => e.HasValue(c.Source.IdAscensorMontaCarga)))));
            
        }
    }

    public class AscensoresMontaCargaInputType : InputObjectGraphType
	{
		public AscensoresMontaCargaInputType()
		{
			// Defining the name of the object
			Name = "ascensoresMontaCargaInput";
			
            //Field<StringGraphType>("idAscensorMontaCarga");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("modalidadeResponsabilidadeCivilId");
			Field<StringGraphType>("codAscensoresMontaCarga");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ModalidadesResponsabilidadeCivilInputType>("modalidadeResponsabilidadeCivil");
			Field<ListGraphType<ClassificacaoAscensoresMontaCargaInputType>>("classificacaoAscensoresMontaCarga");
			
		}
	}
}