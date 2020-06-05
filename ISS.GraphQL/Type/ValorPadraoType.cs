using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ValorPadraoType : ObjectGraphType<ValorPadrao>
    {
        public ValorPadraoType()
        {
            // Defining the name of the object
            Name = "valorPadrao";

            Field(x => x.IdValorCaracteristica, nullable: true);
            Field(x => x.CaracteristicaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.UnidadeId, nullable: true);
            Field(x => x.Valor, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CaracteristicaClassificacaoType>("caracteristica", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicaClassificacao>(c.Source.CaracteristicaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ValorPadraoInputType : InputObjectGraphType
	{
		public ValorPadraoInputType()
		{
			// Defining the name of the object
			Name = "valorPadraoInput";
			
            //Field<StringGraphType>("idValorCaracteristica");
			Field<StringGraphType>("caracteristicaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("unidadeId");
			Field<StringGraphType>("valor");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CaracteristicaClassificacaoInputType>("caracteristica");
			Field<EstadoInputType>("estado");
			
		}
	}
}