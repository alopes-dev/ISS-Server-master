using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AnimaisType : ObjectGraphType<Animais>
    {
        public AnimaisType()
        {
            // Defining the name of the object
            Name = "animais";

            Field(x => x.IdAnimal, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.DataCompra, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Idade, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Observacao, nullable: true);
            Field(x => x.Raca, nullable: true);
            Field(x => x.UnidadeTempoId, nullable: true);
            Field(x => x.ModalidadesRcselecionadaId, nullable: true);
            Field(x => x.EspecieAnimalId, nullable: true);
            Field(x => x.CodAnimais, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            FieldAsync<EspecieAnimaisType>("especieAnimal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EspecieAnimais>(c.Source.EspecieAnimalId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ModalidadesRcselecionadasType>("modalidadesRcselecionada", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesRcselecionadas>(c.Source.ModalidadesRcselecionadaId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<UnidadesTempoType>("unidadeTempo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<UnidadesTempo>(c.Source.UnidadeTempoId)));
            
        }
    }

    public class AnimaisInputType : InputObjectGraphType
	{
		public AnimaisInputType()
		{
			// Defining the name of the object
			Name = "animaisInput";
			
            //Field<StringGraphType>("idAnimal");
			Field<StringGraphType>("nome");
			Field<DateTimeGraphType>("dataCompra");
			Field<IntGraphType>("idade");
			Field<StringGraphType>("observacao");
			Field<StringGraphType>("raca");
			Field<StringGraphType>("unidadeTempoId");
			Field<StringGraphType>("modalidadesRcselecionadaId");
			Field<StringGraphType>("especieAnimalId");
			Field<StringGraphType>("codAnimais");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("pessoaId");
			Field<EspecieAnimaisInputType>("especieAnimal");
			Field<EstadoInputType>("estado");
			Field<ModalidadesRcselecionadasInputType>("modalidadesRcselecionada");
			Field<PessoaInputType>("pessoa");
			Field<UnidadesTempoInputType>("unidadeTempo");
			
		}
	}
}