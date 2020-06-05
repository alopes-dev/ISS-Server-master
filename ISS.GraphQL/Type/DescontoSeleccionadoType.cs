using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescontoSeleccionadoType : ObjectGraphType<DescontoSeleccionado>
    {
        public DescontoSeleccionadoType()
        {
            // Defining the name of the object
            Name = "descontoSeleccionado";

            Field(x => x.IdDescontoSeleccionado, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodDescontoSeleccionado, nullable: true);
            Field(x => x.DescontoId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<DescontoType>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(c.Source.DescontoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class DescontoSeleccionadoInputType : InputObjectGraphType
	{
		public DescontoSeleccionadoInputType()
		{
			// Defining the name of the object
			Name = "descontoSeleccionadoInput";
			
            //Field<StringGraphType>("idDescontoSeleccionado");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codDescontoSeleccionado");
			Field<StringGraphType>("descontoId");
			Field<ApoliceInputType>("apolice");
			Field<CotacaoInputType>("cotacao");
			Field<DescontoInputType>("desconto");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}