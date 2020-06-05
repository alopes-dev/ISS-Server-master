using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AutoridadesContactadasType : ObjectGraphType<AutoridadesContactadas>
    {
        public AutoridadesContactadasType()
        {
            // Defining the name of the object
            Name = "autoridadesContactadas";

            Field(x => x.IdAutoridadeContactada, nullable: true);
            Field(x => x.NomeEntidadeId, nullable: true);
            Field(x => x.DataContacto, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CorrespondenciaId, nullable: true);
            Field(x => x.HoraContacto, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodAutoridadesContactadasQuestionario, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.CodAutoridadesContactadas, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("correspondencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.CorrespondenciaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoAutoridadeType>("nomeEntidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoAutoridade>(c.Source.NomeEntidadeId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class AutoridadesContactadasInputType : InputObjectGraphType
	{
		public AutoridadesContactadasInputType()
		{
			// Defining the name of the object
			Name = "autoridadesContactadasInput";
			
            //Field<StringGraphType>("idAutoridadeContactada");
			Field<StringGraphType>("nomeEntidadeId");
			Field<DateTimeGraphType>("dataContacto");
			Field<StringGraphType>("correspondenciaId");
			Field<DateTimeGraphType>("horaContacto");
			Field<StringGraphType>("codAutoridadesContactadasQuestionario");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("codAutoridadesContactadas");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("correspondencia");
			Field<EstadoInputType>("estado");
			Field<TipoAutoridadeInputType>("nomeEntidade");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}