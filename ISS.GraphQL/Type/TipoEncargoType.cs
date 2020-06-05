using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoEncargoType : ObjectGraphType<TipoEncargo>
    {
        public TipoEncargoType()
        {
            // Defining the name of the object
            Name = "tipoEncargo";

            Field(x => x.IdTipoEncargo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.NaturezaMovimentoId, nullable: true);
            Field(x => x.CodTipoEncargo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<EncargosType>>("encargos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Encargos>(x => x.Where(e => e.HasValue(c.Source.IdTipoEncargo)))));
            
        }
    }

    public class TipoEncargoInputType : InputObjectGraphType
	{
		public TipoEncargoInputType()
		{
			// Defining the name of the object
			Name = "tipoEncargoInput";
			
            //Field<StringGraphType>("idTipoEncargo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("naturezaMovimentoId");
			Field<StringGraphType>("codTipoEncargo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<EncargosInputType>>("encargos");
			
		}
	}
}