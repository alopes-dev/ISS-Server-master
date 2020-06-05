using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TaxasType : ObjectGraphType<Taxas>
    {
        public TaxasType()
        {
            // Defining the name of the object
            Name = "taxas";

            Field(x => x.IdTaxas, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.Percentual, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodTaxas, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoTaxasId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoTaxasType>("tipoTaxas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTaxas>(c.Source.TipoTaxasId)));
            FieldAsync<ListGraphType<PrecarioProdutoType>>("precarioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecarioProduto>(x => x.Where(e => e.HasValue(c.Source.IdTaxas)))));
            
        }
    }

    public class TaxasInputType : InputObjectGraphType
	{
		public TaxasInputType()
		{
			// Defining the name of the object
			Name = "taxasInput";
			
            //Field<StringGraphType>("idTaxas");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("percentual");
			Field<StringGraphType>("codTaxas");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("tipoTaxasId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			Field<TipoTaxasInputType>("tipoTaxas");
			Field<ListGraphType<PrecarioProdutoInputType>>("precarioProduto");
			
		}
	}
}