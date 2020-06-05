using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ComissaoSelecionadaType : ObjectGraphType<ComissaoSelecionada>
    {
        public ComissaoSelecionadaType()
        {
            // Defining the name of the object
            Name = "comissaoSelecionada";

            Field(x => x.IdComissaoSelecionada, nullable: true);
            Field(x => x.ValorComissao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ComissaoId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.CodComissionamento, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            
        }
    }

    public class ComissaoSelecionadaInputType : InputObjectGraphType
	{
		public ComissaoSelecionadaInputType()
		{
			// Defining the name of the object
			Name = "comissaoSelecionadaInput";
			
            //Field<StringGraphType>("idComissaoSelecionada");
			Field<FloatGraphType>("valorComissao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("comissaoId");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("codComissionamento");
			Field<StringGraphType>("produtorId");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("produtor");
			
		}
	}
}