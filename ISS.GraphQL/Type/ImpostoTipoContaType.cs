using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ImpostoTipoContaType : ObjectGraphType<ImpostoTipoConta>
    {
        public ImpostoTipoContaType()
        {
            // Defining the name of the object
            Name = "impostoTipoConta";

            Field(x => x.IdImpostoTipoConta, nullable: true);
            Field(x => x.ImpostoId, nullable: true);
            Field(x => x.TipoContaId, nullable: true);
            Field(x => x.CodImpostoTipoConta, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ImpostoType>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(c.Source.ImpostoId)));
            FieldAsync<TipoContaType>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(c.Source.TipoContaId)));
            
        }
    }

    public class ImpostoTipoContaInputType : InputObjectGraphType
	{
		public ImpostoTipoContaInputType()
		{
			// Defining the name of the object
			Name = "impostoTipoContaInput";
			
            //Field<StringGraphType>("idImpostoTipoConta");
			Field<StringGraphType>("impostoId");
			Field<StringGraphType>("tipoContaId");
			Field<StringGraphType>("codImpostoTipoConta");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ImpostoInputType>("imposto");
			Field<TipoContaInputType>("tipoConta");
			
		}
	}
}