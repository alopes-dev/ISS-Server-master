using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCaixaType : ObjectGraphType<TipoCaixa>
    {
        public TipoCaixaType()
        {
            // Defining the name of the object
            Name = "tipoCaixa";

            Field(x => x.IdTipoCaixa, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoCaixa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdTipoCaixa)))));
            
        }
    }

    public class TipoCaixaInputType : InputObjectGraphType
	{
		public TipoCaixaInputType()
		{
			// Defining the name of the object
			Name = "tipoCaixaInput";
			
            //Field<StringGraphType>("idTipoCaixa");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoCaixa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			
		}
	}
}