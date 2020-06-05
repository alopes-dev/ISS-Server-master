using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NivelAcessoType : ObjectGraphType<NivelAcesso>
    {
        public NivelAcessoType()
        {
            // Defining the name of the object
            Name = "nivelAcesso";

            Field(x => x.IdNivelAcesso, nullable: true);
            Field(x => x.CodNivel, nullable: true);
            Field(x => x.Nivel, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DescricaoNivel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<FuncaoType>>("funcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcao>(x => x.Where(e => e.HasValue(c.Source.IdNivelAcesso)))));
            FieldAsync<ListGraphType<LimiteCompetenciaType>>("limiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdNivelAcesso)))));
            
        }
    }

    public class NivelAcessoInputType : InputObjectGraphType
	{
		public NivelAcessoInputType()
		{
			// Defining the name of the object
			Name = "nivelAcessoInput";
			
            //Field<StringGraphType>("idNivelAcesso");
			Field<StringGraphType>("codNivel");
			Field<IntGraphType>("nivel");
			Field<StringGraphType>("descricaoNivel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<FuncaoInputType>>("funcao");
			Field<ListGraphType<LimiteCompetenciaInputType>>("limiteCompetencia");
			
		}
	}
}