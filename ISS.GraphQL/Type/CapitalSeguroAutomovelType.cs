using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CapitalSeguroAutomovelType : ObjectGraphType<CapitalSeguroAutomovel>
    {
        public CapitalSeguroAutomovelType()
        {
            // Defining the name of the object
            Name = "capitalSeguroAutomovel";

            Field(x => x.IdcapitalAutomovel, nullable: true);
            Field(x => x.ClassificacaoAutomovelId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.Capital, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodCapitalAutomovel, nullable: true);
            FieldAsync<ClassificacaoAutomovelType>("classificacaoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAutomovel>(c.Source.ClassificacaoAutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            
        }
    }

    public class CapitalSeguroAutomovelInputType : InputObjectGraphType
	{
		public CapitalSeguroAutomovelInputType()
		{
			// Defining the name of the object
			Name = "capitalSeguroAutomovelInput";
			
            //Field<StringGraphType>("idcapitalAutomovel");
			Field<StringGraphType>("classificacaoAutomovelId");
			Field<StringGraphType>("moedaId");
			Field<FloatGraphType>("capital");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("codCapitalAutomovel");
			Field<ClassificacaoAutomovelInputType>("classificacaoAutomovel");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			
		}
	}
}