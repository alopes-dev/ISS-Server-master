using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TiposType : ObjectGraphType<Tipos>
    {
        public TiposType()
        {
            // Defining the name of the object
            Name = "tipos";

            Field(x => x.IdTipos, nullable: true);
            Field(x => x.CodTipos, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ContaCredito, nullable: true);
            Field(x => x.SubContaCredito, nullable: true);
            Field(x => x.ContaDebito, nullable: true);
            Field(x => x.SubContaDebito, nullable: true);
            Field(x => x.HistoricoPadraoParaLancamentoContabil, nullable: true);
            Field(x => x.TipoSubDesembolsoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<TipoSubDesembolsoType>("tipoSubDesembolso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSubDesembolso>(c.Source.TipoSubDesembolsoId)));
            
        }
    }

    public class TiposInputType : InputObjectGraphType
	{
		public TiposInputType()
		{
			// Defining the name of the object
			Name = "tiposInput";
			
            //Field<StringGraphType>("idTipos");
			Field<StringGraphType>("codTipos");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("contaCredito");
			Field<StringGraphType>("subContaCredito");
			Field<StringGraphType>("contaDebito");
			Field<StringGraphType>("subContaDebito");
			Field<StringGraphType>("historicoPadraoParaLancamentoContabil");
			Field<StringGraphType>("tipoSubDesembolsoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<TipoSubDesembolsoInputType>("tipoSubDesembolso");
			
		}
	}
}