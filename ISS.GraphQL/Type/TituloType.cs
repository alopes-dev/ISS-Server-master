using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TituloType : ObjectGraphType<Titulo>
    {
        public TituloType()
        {
            // Defining the name of the object
            Name = "titulo";

            Field(x => x.IdTitulo, nullable: true);
            Field(x => x.Abreviacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTitulo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.ContaFinanceiraId, nullable: true);
            FieldAsync<ContaFinanceiraType>("contaFinanceiraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceiraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdTitulo)))));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdTitulo)))));
            
        }
    }

    public class TituloInputType : InputObjectGraphType
	{
		public TituloInputType()
		{
			// Defining the name of the object
			Name = "tituloInput";
			
            //Field<StringGraphType>("idTitulo");
			Field<StringGraphType>("abreviacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTitulo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("contaFinanceiraId");
			Field<ContaFinanceiraInputType>("contaFinanceiraNavigation");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceira");
			Field<ListGraphType<PessoaInputType>>("pessoa");
			
		}
	}
}