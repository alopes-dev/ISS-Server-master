using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BalcaoType : ObjectGraphType<Balcao>
    {
        public BalcaoType()
        {
            // Defining the name of the object
            Name = "balcao";

            Field(x => x.IdBalcao, nullable: true);
            Field(x => x.NumBalcao, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ContactoId, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.CodBalcao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.DistritoId, nullable: true);
            FieldAsync<ContactoType>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(c.Source.ContactoId)));
            FieldAsync<DistritoType>("distrito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Distrito>(c.Source.DistritoId)));
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ApoliceType>>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(x => x.Where(e => e.HasValue(c.Source.IdBalcao)))));
            FieldAsync<ListGraphType<BalcaoPlanoType>>("balcaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BalcaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdBalcao)))));
            FieldAsync<ListGraphType<ContaFinanceiraType>>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(x => x.Where(e => e.HasValue(c.Source.IdBalcao)))));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdBalcao)))));
            FieldAsync<ListGraphType<ResponsavelBalcaoType>>("responsavelBalcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ResponsavelBalcao>(x => x.Where(e => e.HasValue(c.Source.IdBalcao)))));
            FieldAsync<ListGraphType<SegmentoProdutoType>>("segmentoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoProduto>(x => x.Where(e => e.HasValue(c.Source.IdBalcao)))));
            
        }
    }

    public class BalcaoInputType : InputObjectGraphType
	{
		public BalcaoInputType()
		{
			// Defining the name of the object
			Name = "balcaoInput";
			
            //Field<StringGraphType>("idBalcao");
			Field<IntGraphType>("numBalcao");
			Field<StringGraphType>("contactoId");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("codBalcao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("distritoId");
			Field<ContactoInputType>("contacto");
			Field<DistritoInputType>("distrito");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ApoliceInputType>>("apolice");
			Field<ListGraphType<BalcaoPlanoInputType>>("balcaoPlano");
			Field<ListGraphType<ContaFinanceiraInputType>>("contaFinanceira");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<ResponsavelBalcaoInputType>>("responsavelBalcao");
			Field<ListGraphType<SegmentoProdutoInputType>>("segmentoProduto");
			
		}
	}
}