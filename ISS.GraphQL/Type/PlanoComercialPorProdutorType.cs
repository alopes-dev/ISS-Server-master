using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PlanoComercialPorProdutorType : ObjectGraphType<PlanoComercialPorProdutor>
    {
        public PlanoComercialPorProdutorType()
        {
            // Defining the name of the object
            Name = "planoComercialPorProdutor";

            Field(x => x.IdPlanoComercialPorProdutor, nullable: true);
            Field(x => x.ValorBalcao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.QtdPropostaVenda, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodPlanoComercialPorProdutor, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            Field(x => x.BalcaoPlanoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<BalcaoPlanoType>("balcaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BalcaoPlano>(c.Source.BalcaoPlanoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            
        }
    }

    public class PlanoComercialPorProdutorInputType : InputObjectGraphType
	{
		public PlanoComercialPorProdutorInputType()
		{
			// Defining the name of the object
			Name = "planoComercialPorProdutorInput";
			
            //Field<StringGraphType>("idPlanoComercialPorProdutor");
			Field<FloatGraphType>("valorBalcao");
			Field<IntGraphType>("qtdPropostaVenda");
			Field<StringGraphType>("codPlanoComercialPorProdutor");
			Field<StringGraphType>("produtorId");
			Field<StringGraphType>("balcaoPlanoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<BalcaoPlanoInputType>("balcaoPlano");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("produtor");
			
		}
	}
}