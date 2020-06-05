using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModalidadesRcselecionadasType : ObjectGraphType<ModalidadesRcselecionadas>
    {
        public ModalidadesRcselecionadasType()
        {
            // Defining the name of the object
            Name = "modalidadesRcselecionadas";

            Field(x => x.IdModalidadesRcselecionada, nullable: true);
            Field(x => x.NumEstabelecimento, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumHabilitacoes, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumEscritorios, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumPessoas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumLugares, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumPisos, nullable: true, type: typeof(IntGraphType));
            Field(x => x.AnoConstrucao, nullable: true, type: typeof(IntGraphType));
            Field(x => x.FrequenciaUtilizacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumEmpregados, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ValorMonetarioMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoSalaEspetaculoId, nullable: true);
            Field(x => x.TipoEstabelecimentoId, nullable: true);
            Field(x => x.ClassificacaoAscensorId, nullable: true);
            Field(x => x.ModalidadeResponsabilidadeCivilId, nullable: true);
            Field(x => x.InstalacaoId, nullable: true);
            Field(x => x.TipoAntenaId, nullable: true);
            Field(x => x.ValorTipoAntenaId, nullable: true);
            Field(x => x.CodModalidadesRcselecionadas, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ClassificacaoAscensoresMontaCargaType>("classificacaoAscensor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAscensoresMontaCarga>(c.Source.ClassificacaoAscensorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<InstalacoesType>("instalacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Instalacoes>(c.Source.InstalacaoId)));
            FieldAsync<ModalidadesResponsabilidadeCivilType>("modalidadeResponsabilidadeCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesResponsabilidadeCivil>(c.Source.ModalidadeResponsabilidadeCivilId)));
            FieldAsync<LocalidadeAntenaType>("tipoAntena", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalidadeAntena>(c.Source.TipoAntenaId)));
            FieldAsync<TipoEstabelecimentoComercioType>("tipoEstabelecimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEstabelecimentoComercio>(c.Source.TipoEstabelecimentoId)));
            FieldAsync<TipoSalaEspetaculoType>("tipoSalaEspetaculo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSalaEspetaculo>(c.Source.TipoSalaEspetaculoId)));
            FieldAsync<ValoresTipoAntenaType>("valorTipoAntena", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValoresTipoAntena>(c.Source.ValorTipoAntenaId)));
            FieldAsync<ListGraphType<AnimaisType>>("animais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Animais>(x => x.Where(e => e.HasValue(c.Source.IdModalidadesRcselecionada)))));
            
        }
    }

    public class ModalidadesRcselecionadasInputType : InputObjectGraphType
	{
		public ModalidadesRcselecionadasInputType()
		{
			// Defining the name of the object
			Name = "modalidadesRcselecionadasInput";
			
            //Field<StringGraphType>("idModalidadesRcselecionada");
			Field<IntGraphType>("numEstabelecimento");
			Field<IntGraphType>("numHabilitacoes");
			Field<IntGraphType>("numEscritorios");
			Field<IntGraphType>("numPessoas");
			Field<IntGraphType>("numLugares");
			Field<IntGraphType>("numPisos");
			Field<IntGraphType>("anoConstrucao");
			Field<FloatGraphType>("frequenciaUtilizacao");
			Field<IntGraphType>("numEmpregados");
			Field<FloatGraphType>("valorMonetarioMax");
			Field<StringGraphType>("tipoSalaEspetaculoId");
			Field<StringGraphType>("tipoEstabelecimentoId");
			Field<StringGraphType>("classificacaoAscensorId");
			Field<StringGraphType>("modalidadeResponsabilidadeCivilId");
			Field<StringGraphType>("instalacaoId");
			Field<StringGraphType>("tipoAntenaId");
			Field<StringGraphType>("valorTipoAntenaId");
			Field<StringGraphType>("codModalidadesRcselecionadas");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<ClassificacaoAscensoresMontaCargaInputType>("classificacaoAscensor");
			Field<EstadoInputType>("estado");
			Field<InstalacoesInputType>("instalacao");
			Field<ModalidadesResponsabilidadeCivilInputType>("modalidadeResponsabilidadeCivil");
			Field<LocalidadeAntenaInputType>("tipoAntena");
			Field<TipoEstabelecimentoComercioInputType>("tipoEstabelecimento");
			Field<TipoSalaEspetaculoInputType>("tipoSalaEspetaculo");
			Field<ValoresTipoAntenaInputType>("valorTipoAntena");
			Field<ListGraphType<AnimaisInputType>>("animais");
			
		}
	}
}