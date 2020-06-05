using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoGaragemType : ObjectGraphType<TipoGaragem>
    {
        public TipoGaragemType()
        {
            // Defining the name of the object
            Name = "tipoGaragem";

            Field(x => x.IdTipoGaragem, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TaxaAgravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodTipoGaragem, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CaracteristicaAtutomovelType>>("caracteristicaAtutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicaAtutomovel>(x => x.Where(e => e.HasValue(c.Source.IdTipoGaragem)))));
            
        }
    }

    public class TipoGaragemInputType : InputObjectGraphType
	{
		public TipoGaragemInputType()
		{
			// Defining the name of the object
			Name = "tipoGaragemInput";
			
            //Field<StringGraphType>("idTipoGaragem");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("taxaAgravamento");
			Field<StringGraphType>("codTipoGaragem");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CaracteristicaAtutomovelInputType>>("caracteristicaAtutomovel");
			
		}
	}
}