using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ReivindicacoesFeitasApoliceType : ObjectGraphType<ReivindicacoesFeitasApolice>
    {
        public ReivindicacoesFeitasApoliceType()
        {
            // Defining the name of the object
            Name = "reivindicacoesFeitasApolice";

            Field(x => x.IdReivindicacoesFeitasApolice, nullable: true);
            Field(x => x.DataHoraEmissao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PercentagemDescobertura, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MontanteDescoberta, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ReivindicacoesFeitasApoliceInputType : InputObjectGraphType
	{
		public ReivindicacoesFeitasApoliceInputType()
		{
			// Defining the name of the object
			Name = "reivindicacoesFeitasApoliceInput";
			
            //Field<StringGraphType>("idReivindicacoesFeitasApolice");
			Field<DateTimeGraphType>("dataHoraEmissao");
			Field<FloatGraphType>("percentagemDescobertura");
			Field<FloatGraphType>("montanteDescoberta");
			Field<StringGraphType>("apoliceId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			
		}
	}
}