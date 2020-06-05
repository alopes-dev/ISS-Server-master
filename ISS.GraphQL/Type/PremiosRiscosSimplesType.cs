using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PremiosRiscosSimplesType : ObjectGraphType<PremiosRiscosSimples>
    {
        public PremiosRiscosSimplesType()
        {
            // Defining the name of the object
            Name = "premiosRiscosSimples";

            Field(x => x.IdPremiosRiscosSimples, nullable: true);
            Field(x => x.ClassificacaoObjectoSeguro, nullable: true);
            Field(x => x.LocalidadeId, nullable: true);
            Field(x => x.Risco1, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco2, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco3, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodPremiosRiscosSimples, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<EnderecoType>("localidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.LocalidadeId)));
            
        }
    }

    public class PremiosRiscosSimplesInputType : InputObjectGraphType
	{
		public PremiosRiscosSimplesInputType()
		{
			// Defining the name of the object
			Name = "premiosRiscosSimplesInput";
			
            //Field<StringGraphType>("idPremiosRiscosSimples");
			Field<StringGraphType>("classificacaoObjectoSeguro");
			Field<StringGraphType>("localidadeId");
			Field<FloatGraphType>("risco1");
			Field<FloatGraphType>("risco2");
			Field<FloatGraphType>("risco3");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("codPremiosRiscosSimples");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<EnderecoInputType>("localidade");
			
		}
	}
}