using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DespesasTipoContaType : ObjectGraphType<DespesasTipoConta>
    {
        public DespesasTipoContaType()
        {
            // Defining the name of the object
            Name = "despesasTipoConta";

            Field(x => x.IdDespesaTipoConta, nullable: true);
            Field(x => x.DespesaId, nullable: true);
            Field(x => x.CodDespesasTipoConta, nullable: true);
            Field(x => x.TipoContaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<DespesaType>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(c.Source.DespesaId)));
            FieldAsync<TipoContaType>("tipoConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConta>(c.Source.TipoContaId)));
            
        }
    }

    public class DespesasTipoContaInputType : InputObjectGraphType
	{
		public DespesasTipoContaInputType()
		{
			// Defining the name of the object
			Name = "despesasTipoContaInput";
			
            //Field<StringGraphType>("idDespesaTipoConta");
			Field<StringGraphType>("despesaId");
			Field<StringGraphType>("codDespesasTipoConta");
			Field<StringGraphType>("tipoContaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DespesaInputType>("despesa");
			Field<TipoContaInputType>("tipoConta");
			
		}
	}
}