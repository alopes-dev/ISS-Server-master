using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoConstrucaoPneusType : ObjectGraphType<TipoConstrucaoPneus>
    {
        public TipoConstrucaoPneusType()
        {
            // Defining the name of the object
            Name = "tipoConstrucaoPneus";

            Field(x => x.IdTipoConstrucaoPneus, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoConstrucaoPneus, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PneuType>>("pneu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pneu>(x => x.Where(e => e.HasValue(c.Source.IdTipoConstrucaoPneus)))));
            
        }
    }

    public class TipoConstrucaoPneusInputType : InputObjectGraphType
	{
		public TipoConstrucaoPneusInputType()
		{
			// Defining the name of the object
			Name = "tipoConstrucaoPneusInput";
			
            //Field<StringGraphType>("idTipoConstrucaoPneus");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoConstrucaoPneus");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PneuInputType>>("pneu");
			
		}
	}
}