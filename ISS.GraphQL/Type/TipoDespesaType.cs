using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoDespesaType : ObjectGraphType<TipoDespesa>
    {
        public TipoDespesaType()
        {
            // Defining the name of the object
            Name = "tipoDespesa";

            Field(x => x.IdTipoDespesa, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoDespesa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<DespesaType>>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(x => x.Where(e => e.HasValue(c.Source.IdTipoDespesa)))));
            
        }
    }

    public class TipoDespesaInputType : InputObjectGraphType
	{
		public TipoDespesaInputType()
		{
			// Defining the name of the object
			Name = "tipoDespesaInput";
			
            //Field<StringGraphType>("idTipoDespesa");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoDespesa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<DespesaInputType>>("despesa");
			
		}
	}
}