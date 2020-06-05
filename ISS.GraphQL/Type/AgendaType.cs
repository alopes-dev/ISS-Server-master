using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AgendaType : ObjectGraphType<Agenda>
    {
        public AgendaType()
        {
            // Defining the name of the object
            Name = "agenda";

            Field(x => x.IdAgenda, nullable: true);
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PessoaResponsavelId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodAgenda, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoaResponsavel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaResponsavelId)));
            FieldAsync<ListGraphType<ActividadesAgendaType>>("actividadesAgenda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ActividadesAgenda>(x => x.Where(e => e.HasValue(c.Source.IdAgenda)))));
            FieldAsync<ListGraphType<AgendaPlanoType>>("agendaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AgendaPlano>(x => x.Where(e => e.HasValue(c.Source.IdAgenda)))));
            
        }
    }

    public class AgendaInputType : InputObjectGraphType
	{
		public AgendaInputType()
		{
			// Defining the name of the object
			Name = "agendaInput";
			
            //Field<StringGraphType>("idAgenda");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFim");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("pessoaResponsavelId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codAgenda");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoaResponsavel");
			Field<ListGraphType<ActividadesAgendaInputType>>("actividadesAgenda");
			Field<ListGraphType<AgendaPlanoInputType>>("agendaPlano");
			
		}
	}
}