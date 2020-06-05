using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoTaxasType : ObjectGraphType<TipoTaxas>
    {
        public TipoTaxasType()
        {
            // Defining the name of the object
            Name = "tipoTaxas";

            Field(x => x.IdTipoTaxas, nullable: true);
            Field(x => x.CoTipoTaxas, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<TaxasType>>("taxas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Taxas>(x => x.Where(e => e.HasValue(c.Source.IdTipoTaxas)))));
            
        }
    }

    public class TipoTaxasInputType : InputObjectGraphType
	{
		public TipoTaxasInputType()
		{
			// Defining the name of the object
			Name = "tipoTaxasInput";
			
            //Field<StringGraphType>("idTipoTaxas");
			Field<StringGraphType>("coTipoTaxas");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<TaxasInputType>>("taxas");
			
		}
	}
}