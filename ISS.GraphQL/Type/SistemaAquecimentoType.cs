using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SistemaAquecimentoType : ObjectGraphType<SistemaAquecimento>
    {
        public SistemaAquecimentoType()
        {
            // Defining the name of the object
            Name = "sistemaAquecimento";

            Field(x => x.IdSistemaAquecimento, nullable: true);
            Field(x => x.TermostaticamenteControlado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.AreaAquecida, nullable: true);
            Field(x => x.DataHoraInstalacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Certificado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.MetodoSistemaAquecimentoId, nullable: true);
            Field(x => x.CombustivelId, nullable: true);
            Field(x => x.ConstrucaoId, nullable: true);
            Field(x => x.CodSistemaAquecimento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CombustivelType>("combustivel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Combustivel>(c.Source.CombustivelId)));
            FieldAsync<ConstrucaoType>("construcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Construcao>(c.Source.ConstrucaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MetodoSistemaAquecimentoType>("metodoSistemaAquecimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MetodoSistemaAquecimento>(c.Source.MetodoSistemaAquecimentoId)));
            
        }
    }

    public class SistemaAquecimentoInputType : InputObjectGraphType
	{
		public SistemaAquecimentoInputType()
		{
			// Defining the name of the object
			Name = "sistemaAquecimentoInput";
			
            //Field<StringGraphType>("idSistemaAquecimento");
			Field<BooleanGraphType>("termostaticamenteControlado");
			Field<StringGraphType>("areaAquecida");
			Field<DateTimeGraphType>("dataHoraInstalacao");
			Field<BooleanGraphType>("certificado");
			Field<StringGraphType>("metodoSistemaAquecimentoId");
			Field<StringGraphType>("combustivelId");
			Field<StringGraphType>("construcaoId");
			Field<StringGraphType>("codSistemaAquecimento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CombustivelInputType>("combustivel");
			Field<ConstrucaoInputType>("construcao");
			Field<EstadoInputType>("estado");
			Field<MetodoSistemaAquecimentoInputType>("metodoSistemaAquecimento");
			
		}
	}
}