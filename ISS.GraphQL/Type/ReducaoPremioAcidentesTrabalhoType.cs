using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ReducaoPremioAcidentesTrabalhoType : ObjectGraphType<ReducaoPremioAcidentesTrabalho>
    {
        public ReducaoPremioAcidentesTrabalhoType()
        {
            // Defining the name of the object
            Name = "reducaoPremioAcidentesTrabalho";

            Field(x => x.IdReducaoPremioAcidentesTrabalho, nullable: true);
            Field(x => x.TaxaReducao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaSinistralidadeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TaxaSinistralidadeType>("taxaSinistralidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TaxaSinistralidade>(c.Source.TaxaSinistralidadeId)));
            
        }
    }

    public class ReducaoPremioAcidentesTrabalhoInputType : InputObjectGraphType
	{
		public ReducaoPremioAcidentesTrabalhoInputType()
		{
			// Defining the name of the object
			Name = "reducaoPremioAcidentesTrabalhoInput";
			
            //Field<StringGraphType>("idReducaoPremioAcidentesTrabalho");
			Field<FloatGraphType>("taxaReducao");
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