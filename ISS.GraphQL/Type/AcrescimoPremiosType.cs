using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AcrescimoPremiosType : ObjectGraphType<AcrescimoPremios>
    {
        public AcrescimoPremiosType()
        {
            // Defining the name of the object
            Name = "acrescimoPremios";

            Field(x => x.IdAcrescimoPremios, nullable: true);
            Field(x => x.CapitalUcf, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PercentagemAcrescimo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodAcrescimoPremios, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class AcrescimoPremiosInputType : InputObjectGraphType
	{
		public AcrescimoPremiosInputType()
		{
			// Defining the name of the object
			Name = "acrescimoPremiosInput";
			
            //Field<StringGraphType>("idAcrescimoPremios");
			Field<FloatGraphType>("capitalUcf");
			Field<FloatGraphType>("percentagemAcrescimo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codAcrescimoPremios");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			
		}
	}
}