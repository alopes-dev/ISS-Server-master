using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoAscensoresMontaCargaType : ObjectGraphType<ClassificacaoAscensoresMontaCarga>
    {
        public ClassificacaoAscensoresMontaCargaType()
        {
            // Defining the name of the object
            Name = "classificacaoAscensoresMontaCarga";

            Field(x => x.IdClassificacaoAscensorMontaCarga, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.AscensorMontaCargaId, nullable: true);
            Field(x => x.CodClassificacaoAscensoresMontaCarga, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<AscensoresMontaCargaType>("ascensorMontaCarga", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AscensoresMontaCarga>(c.Source.AscensorMontaCargaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ModalidadesRcselecionadasType>>("modalidadesRcselecionadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesRcselecionadas>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoAscensorMontaCarga)))));
            
        }
    }

    public class ClassificacaoAscensoresMontaCargaInputType : InputObjectGraphType
	{
		public ClassificacaoAscensoresMontaCargaInputType()
		{
			// Defining the name of the object
			Name = "classificacaoAscensoresMontaCargaInput";
			
            //Field<StringGraphType>("idClassificacaoAscensorMontaCarga");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("ascensorMontaCargaId");
			Field<StringGraphType>("codClassificacaoAscensoresMontaCarga");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<AscensoresMontaCargaInputType>("ascensorMontaCarga");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ModalidadesRcselecionadasInputType>>("modalidadesRcselecionadas");
			
		}
	}
}