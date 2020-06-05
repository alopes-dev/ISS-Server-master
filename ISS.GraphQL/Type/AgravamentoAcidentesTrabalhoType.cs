using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AgravamentoAcidentesTrabalhoType : ObjectGraphType<AgravamentoAcidentesTrabalho>
    {
        public AgravamentoAcidentesTrabalhoType()
        {
            // Defining the name of the object
            Name = "agravamentoAcidentesTrabalho";

            Field(x => x.IdAgravamentoAcidentesTrabalho, nullable: true);
            Field(x => x.TaxaAgravamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaSinistralidadeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TaxaSinistralidadeType>("taxaSinistralidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TaxaSinistralidade>(c.Source.TaxaSinistralidadeId)));
            
        }
    }

    public class AgravamentoAcidentesTrabalhoInputType : InputObjectGraphType
	{
		public AgravamentoAcidentesTrabalhoInputType()
		{
			// Defining the name of the object
			Name = "agravamentoAcidentesTrabalhoInput";
			
            //Field<StringGraphType>("idAgravamentoAcidentesTrabalho");
			Field<FloatGraphType>("taxaAgravamento");
			Field<StringGraphType>("taxaSinistralidadeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("isTaxa");
			Field<EstadoInputType>("estado");
			Field<TaxaSinistralidadeInputType>("taxaSinistralidade");
			
		}
	}
}