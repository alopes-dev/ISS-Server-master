using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModalidadesResponsabilidadeCivilType : ObjectGraphType<ModalidadesResponsabilidadeCivil>
    {
        public ModalidadesResponsabilidadeCivilType()
        {
            // Defining the name of the object
            Name = "modalidadesResponsabilidadeCivil";

            Field(x => x.IdModalidadeResponsabilidadeCivil, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodModalidadesResponsabilidadeCivil, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AscensoresMontaCargaType>>("ascensoresMontaCarga", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AscensoresMontaCarga>(x => x.Where(e => e.HasValue(c.Source.IdModalidadeResponsabilidadeCivil)))));
            FieldAsync<ListGraphType<LocalidadeAntenaType>>("localidadeAntena", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalidadeAntena>(x => x.Where(e => e.HasValue(c.Source.IdModalidadeResponsabilidadeCivil)))));
            FieldAsync<ListGraphType<ModalidadesRcselecionadasType>>("modalidadesRcselecionadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesRcselecionadas>(x => x.Where(e => e.HasValue(c.Source.IdModalidadeResponsabilidadeCivil)))));
            FieldAsync<ListGraphType<TipoEstabelecimentoComercioType>>("tipoEstabelecimentoComercio", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEstabelecimentoComercio>(x => x.Where(e => e.HasValue(c.Source.IdModalidadeResponsabilidadeCivil)))));
            FieldAsync<ListGraphType<TipoSalaEspetaculoType>>("tipoSalaEspetaculo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSalaEspetaculo>(x => x.Where(e => e.HasValue(c.Source.IdModalidadeResponsabilidadeCivil)))));
            FieldAsync<ListGraphType<ValoresCapitalSeguroFamiliarType>>("valoresCapitalSeguroFamiliar", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValoresCapitalSeguroFamiliar>(x => x.Where(e => e.HasValue(c.Source.IdModalidadeResponsabilidadeCivil)))));
            
        }
    }

    public class ModalidadesResponsabilidadeCivilInputType : InputObjectGraphType
	{
		public ModalidadesResponsabilidadeCivilInputType()
		{
			// Defining the name of the object
			Name = "modalidadesResponsabilidadeCivilInput";
			
            //Field<StringGraphType>("idModalidadeResponsabilidadeCivil");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codModalidadesResponsabilidadeCivil");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AscensoresMontaCargaInputType>>("ascensoresMontaCarga");
			Field<ListGraphType<LocalidadeAntenaInputType>>("localidadeAntena");
			Field<ListGraphType<ModalidadesRcselecionadasInputType>>("modalidadesRcselecionadas");
			Field<ListGraphType<TipoEstabelecimentoComercioInputType>>("tipoEstabelecimentoComercio");
			Field<ListGraphType<TipoSalaEspetaculoInputType>>("tipoSalaEspetaculo");
			Field<ListGraphType<ValoresCapitalSeguroFamiliarInputType>>("valoresCapitalSeguroFamiliar");
			
		}
	}
}