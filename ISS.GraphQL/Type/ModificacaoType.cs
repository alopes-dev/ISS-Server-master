using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModificacaoType : ObjectGraphType<Modificacao>
    {
        public ModificacaoType()
        {
            // Defining the name of the object
            Name = "modificacao";

            Field(x => x.IdModificacao, nullable: true);
            Field(x => x.ValorModificacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.AnoModificacao, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DescricaoModificacao, nullable: true);
            Field(x => x.DataOcorrenciaModificacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DescricaoRemodelacao, nullable: true);
            Field(x => x.RazaoModificacao, nullable: true);
            Field(x => x.AutomovelId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ModificacaoInputType : InputObjectGraphType
	{
		public ModificacaoInputType()
		{
			// Defining the name of the object
			Name = "modificacaoInput";
			
            //Field<StringGraphType>("idModificacao");
			Field<FloatGraphType>("valorModificacao");
			Field<IntGraphType>("anoModificacao");
			Field<StringGraphType>("descricaoModificacao");
			Field<DateTimeGraphType>("dataOcorrenciaModificacao");
			Field<StringGraphType>("descricaoRemodelacao");
			Field<StringGraphType>("razaoModificacao");
			Field<StringGraphType>("automovelId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<AutomovelInputType>("automovel");
			Field<EstadoInputType>("estado");
			
		}
	}
}