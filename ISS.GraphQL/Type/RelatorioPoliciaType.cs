using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RelatorioPoliciaType : ObjectGraphType<RelatorioPolicia>
    {
        public RelatorioPoliciaType()
        {
            // Defining the name of the object
            Name = "relatorioPolicia";

            Field(x => x.IdRelatorioPolicia, nullable: true);
            Field(x => x.DataHora, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.TipoAutoridadeId, nullable: true);
            Field(x => x.NomeAgente, nullable: true);
            Field(x => x.NumIdentAgente, nullable: true);
            Field(x => x.TelemovelAgente, nullable: true);
            Field(x => x.DescricaoPormenorizadaAgente, nullable: true);
            Field(x => x.NumProcessoPolicia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            FieldAsync<TipoAutoridadeType>("tipoAutoridade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoAutoridade>(c.Source.TipoAutoridadeId)));
            
        }
    }

    public class RelatorioPoliciaInputType : InputObjectGraphType
	{
		public RelatorioPoliciaInputType()
		{
			// Defining the name of the object
			Name = "relatorioPoliciaInput";
			
            //Field<StringGraphType>("idRelatorioPolicia");
			Field<DateTimeGraphType>("dataHora");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("tipoAutoridadeId");
			Field<StringGraphType>("nomeAgente");
			Field<StringGraphType>("numIdentAgente");
			Field<StringGraphType>("telemovelAgente");
			Field<StringGraphType>("descricaoPormenorizadaAgente");
			Field<StringGraphType>("numProcessoPolicia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<SinistroInputType>("sinistro");
			Field<TipoAutoridadeInputType>("tipoAutoridade");
			
		}
	}
}