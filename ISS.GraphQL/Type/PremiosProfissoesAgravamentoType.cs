using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PremiosProfissoesAgravamentoType : ObjectGraphType<PremiosProfissoesAgravamento>
    {
        public PremiosProfissoesAgravamentoType()
        {
            // Defining the name of the object
            Name = "premiosProfissoesAgravamento";

            Field(x => x.IdProfissoesAgravamento, nullable: true);
            Field(x => x.Localidade, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.Risco2, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Risco3, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Risco1, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Categoria, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class PremiosProfissoesAgravamentoInputType : InputObjectGraphType
	{
		public PremiosProfissoesAgravamentoInputType()
		{
			// Defining the name of the object
			Name = "premiosProfissoesAgravamentoInput";
			
            //Field<StringGraphType>("idProfissoesAgravamento");
			Field<StringGraphType>("localidade");
			Field<StringGraphType>("descricao");
			Field<FloatGraphType>("risco2");
			Field<FloatGraphType>("risco3");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("risco1");
			Field<StringGraphType>("categoria");
			Field<EstadoInputType>("estado");
			
		}
	}
}