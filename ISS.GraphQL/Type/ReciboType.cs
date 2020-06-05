using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ReciboType : ObjectGraphType<Recibo>
    {
        public ReciboType()
        {
            // Defining the name of the object
            Name = "recibo";

            Field(x => x.IdRecibo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataEmissao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Referencia, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ReciboInputType : InputObjectGraphType
	{
		public ReciboInputType()
		{
			// Defining the name of the object
			Name = "reciboInput";
			
            //Field<StringGraphType>("idRecibo");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataEmissao");
			Field<FloatGraphType>("valor");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("referencia");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			
		}
	}
}