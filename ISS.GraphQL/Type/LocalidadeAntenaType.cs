using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LocalidadeAntenaType : ObjectGraphType<LocalidadeAntena>
    {
        public LocalidadeAntenaType()
        {
            // Defining the name of the object
            Name = "localidadeAntena";

            Field(x => x.IdLocalidadeAntena, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ModalidadeResponsabilidadeCivilId, nullable: true);
            Field(x => x.CodLocalidadeAntena, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ModalidadesResponsabilidadeCivilType>("modalidadeResponsabilidadeCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesResponsabilidadeCivil>(c.Source.ModalidadeResponsabilidadeCivilId)));
            FieldAsync<ListGraphType<ModalidadesRcselecionadasType>>("modalidadesRcselecionadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesRcselecionadas>(x => x.Where(e => e.HasValue(c.Source.IdLocalidadeAntena)))));
            FieldAsync<ListGraphType<ValoresTipoAntenaType>>("valoresTipoAntena", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValoresTipoAntena>(x => x.Where(e => e.HasValue(c.Source.IdLocalidadeAntena)))));
            
        }
    }

    public class LocalidadeAntenaInputType : InputObjectGraphType
	{
		public LocalidadeAntenaInputType()
		{
			// Defining the name of the object
			Name = "localidadeAntenaInput";
			
            //Field<StringGraphType>("idLocalidadeAntena");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("modalidadeResponsabilidadeCivilId");
			Field<StringGraphType>("codLocalidadeAntena");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ModalidadesResponsabilidadeCivilInputType>("modalidadeResponsabilidadeCivil");
			Field<ListGraphType<ModalidadesRcselecionadasInputType>>("modalidadesRcselecionadas");
			Field<ListGraphType<ValoresTipoAntenaInputType>>("valoresTipoAntena");
			
		}
	}
}