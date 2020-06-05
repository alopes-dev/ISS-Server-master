using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EstadoCivilType : ObjectGraphType<EstadoCivil>
    {
        public EstadoCivilType()
        {
            // Defining the name of the object
            Name = "estadoCivil";

            Field(x => x.IdEstadoCivil, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodEstadoCivil, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<EstadoCivilPlanoType>>("estadoCivilPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EstadoCivilPlano>(x => x.Where(e => e.HasValue(c.Source.IdEstadoCivil)))));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdEstadoCivil)))));
            
        }
    }

    public class EstadoCivilInputType : InputObjectGraphType
	{
		public EstadoCivilInputType()
		{
			// Defining the name of the object
			Name = "estadoCivilInput";
			
            //Field<StringGraphType>("idEstadoCivil");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codEstadoCivil");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<EstadoCivilPlanoInputType>>("estadoCivilPlano");
			Field<ListGraphType<PessoaInputType>>("pessoa");
			
		}
	}
}