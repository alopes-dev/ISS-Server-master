using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoAgravamentoType : ObjectGraphType<TipoAgravamento>
    {
        public TipoAgravamentoType()
        {
            // Defining the name of the object
            Name = "tipoAgravamento";

            Field(x => x.IdTipoAgravamento, nullable: true);
            Field(x => x.CodTipoAgravamento, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.TipoOperacaoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoOperacaoType>("tipoOperacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacao>(c.Source.TipoOperacaoId)));
            FieldAsync<ListGraphType<AgravamentoType>>("agravamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Agravamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoAgravamento)))));
            FieldAsync<ListGraphType<ItensPerguntaType>>("itensPergunta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ItensPergunta>(x => x.Where(e => e.HasValue(c.Source.IdTipoAgravamento)))));
            
        }
    }

    public class TipoAgravamentoInputType : InputObjectGraphType
	{
		public TipoAgravamentoInputType()
		{
			// Defining the name of the object
			Name = "tipoAgravamentoInput";
			
            //Field<StringGraphType>("idTipoAgravamento");
			Field<StringGraphType>("codTipoAgravamento");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("tipoOperacaoId");
			Field<EstadoInputType>("estado");
			Field<TipoOperacaoInputType>("tipoOperacao");
			Field<ListGraphType<AgravamentoInputType>>("agravamento");
			Field<ListGraphType<ItensPerguntaInputType>>("itensPergunta");
			
		}
	}
}