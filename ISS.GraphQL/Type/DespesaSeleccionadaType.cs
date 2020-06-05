using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DespesaSeleccionadaType : ObjectGraphType<DespesaSeleccionada>
    {
        public DespesaSeleccionadaType()
        {
            // Defining the name of the object
            Name = "despesaSeleccionada";

            Field(x => x.IdDespesaSeleccionada, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DespesaId, nullable: true);
            Field(x => x.CodDespesaSeleccionada, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<DespesaType>("despesa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Despesa>(c.Source.DespesaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class DespesaSeleccionadaInputType : InputObjectGraphType
	{
		public DespesaSeleccionadaInputType()
		{
			// Defining the name of the object
			Name = "despesaSeleccionadaInput";
			
            //Field<StringGraphType>("idDespesaSeleccionada");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("despesaId");
			Field<StringGraphType>("codDespesaSeleccionada");
			Field<ApoliceInputType>("apolice");
			Field<CotacaoInputType>("cotacao");
			Field<DespesaInputType>("despesa");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}