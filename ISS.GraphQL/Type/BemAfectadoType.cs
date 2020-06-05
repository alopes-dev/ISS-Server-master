using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BemAfectadoType : ObjectGraphType<BemAfectado>
    {
        public BemAfectadoType()
        {
            // Defining the name of the object
            Name = "bemAfectado";

            Field(x => x.IdBemAfectado, nullable: true);
            Field(x => x.Quantidade, nullable: true, type: typeof(IntGraphType));
            Field(x => x.ValorUnitario, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ValorExtensao, nullable: true);
            Field(x => x.ValorCompreensao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class BemAfectadoInputType : InputObjectGraphType
	{
		public BemAfectadoInputType()
		{
			// Defining the name of the object
			Name = "bemAfectadoInput";
			
            //Field<StringGraphType>("idBemAfectado");
			Field<IntGraphType>("quantidade");
			Field<FloatGraphType>("valorUnitario");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("valorExtensao");
			Field<FloatGraphType>("valorCompreensao");
			Field<StringGraphType>("caminhoFicheiro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}