using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoTipoContaType : ObjectGraphType<DescontoTipoConta>
    {
        public DescontoTipoContaType()
        {
            // Defining the name of the object
            Name = "descontoTipoConta";

            Field(x => x.IdDescontoTipoConta, nullable: true);
            Field(x => x.DescontoId, nullable: true);
            Field(x => x.CodDescontoTipoConta, nullable: true);
            Field(x => x.TipoContaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<DescontoType>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(c.Source.DescontoId)));
            FieldAsync<TipoContaType>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(c.Source.TipoContaId)));
            
        }
    }

    public class DescontoTipoContaInputType : InputObjectGraphType
	{
		public DescontoTipoContaInputType()
		{
			// Defining the name of the object
			Name = "descontoTipoContaInput";
			
            //Field<StringGraphType>("idDescontoTipoConta");
			Field<StringGraphType>("descontoId");
			Field<StringGraphType>("codDescontoTipoConta");
			Field<StringGraphType>("tipoContaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DescontoInputType>("desconto");
			Field<TipoContaInputType>("tipoConta");
			
		}
	}
}