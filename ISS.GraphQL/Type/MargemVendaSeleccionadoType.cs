using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MargemVendaSeleccionadoType : ObjectGraphType<MargemVendaSeleccionado>
    {
        public MargemVendaSeleccionadoType()
        {
            // Defining the name of the object
            Name = "margemVendaSeleccionado";

            Field(x => x.IdMargemVendaSeleccionado, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MargemVendaProdutoId, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodMargemVendaSeleccionado, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MargemVendaProdutoType>("margemVendaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MargemVendaProduto>(c.Source.MargemVendaProdutoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class MargemVendaSeleccionadoInputType : InputObjectGraphType
	{
		public MargemVendaSeleccionadoInputType()
		{
			// Defining the name of the object
			Name = "margemVendaSeleccionadoInput";
			
            //Field<StringGraphType>("idMargemVendaSeleccionado");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("margemVendaProdutoId");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codMargemVendaSeleccionado");
			Field<ApoliceInputType>("apolice");
			Field<CotacaoInputType>("cotacao");
			Field<EstadoInputType>("estado");
			Field<MargemVendaProdutoInputType>("margemVendaProduto");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}