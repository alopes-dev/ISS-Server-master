using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PremiosMercadoriasNaoOrdinariasType : ObjectGraphType<PremiosMercadoriasNaoOrdinarias>
    {
        public PremiosMercadoriasNaoOrdinariasType()
        {
            // Defining the name of the object
            Name = "premiosMercadoriasNaoOrdinarias";

            Field(x => x.IdPremiosMercadoriasNaoOrdinarias, nullable: true);
            Field(x => x.Categoria, nullable: true);
            Field(x => x.Localidade, nullable: true);
            Field(x => x.Risco1, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco2, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco3, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ClassificacaoObjecto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodPremiosMercadoriasNaoOrdinarias, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class PremiosMercadoriasNaoOrdinariasInputType : InputObjectGraphType
	{
		public PremiosMercadoriasNaoOrdinariasInputType()
		{
			// Defining the name of the object
			Name = "premiosMercadoriasNaoOrdinariasInput";
			
            //Field<StringGraphType>("idPremiosMercadoriasNaoOrdinarias");
			Field<StringGraphType>("categoria");
			Field<StringGraphType>("localidade");
			Field<FloatGraphType>("risco1");
			Field<FloatGraphType>("risco2");
			Field<FloatGraphType>("risco3");
			Field<StringGraphType>("classificacaoObjecto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codPremiosMercadoriasNaoOrdinarias");
			Field<EstadoInputType>("estado");
			
		}
	}
}