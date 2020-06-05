using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModalidadeAtrasoViagemType : ObjectGraphType<ModalidadeAtrasoViagem>
    {
        public ModalidadeAtrasoViagemType()
        {
            // Defining the name of the object
            Name = "modalidadeAtrasoViagem";

            Field(x => x.IdModalidade, nullable: true);
            Field(x => x.HorasMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.HorasMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.CodModalidadeAtrasoViagem, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class ModalidadeAtrasoViagemInputType : InputObjectGraphType
	{
		public ModalidadeAtrasoViagemInputType()
		{
			// Defining the name of the object
			Name = "modalidadeAtrasoViagemInput";
			
            //Field<StringGraphType>("idModalidade");
			Field<IntGraphType>("horasMin");
			Field<IntGraphType>("horasMax");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("planoProdutoId");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("codModalidadeAtrasoViagem");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}