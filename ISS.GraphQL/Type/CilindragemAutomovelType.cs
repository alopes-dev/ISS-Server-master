using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CilindragemAutomovelType : ObjectGraphType<CilindragemAutomovel>
    {
        public CilindragemAutomovelType()
        {
            // Defining the name of the object
            Name = "cilindragemAutomovel";

            Field(x => x.IdCilindragemAutomovel, nullable: true);
            Field(x => x.Cilindragem, nullable: true);
            Field(x => x.PremioUcf, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ClassificacaoAutomovelId, nullable: true);
            Field(x => x.CodCilindragemAutomovel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.CilindragemMinima, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CilindragemMaxima, nullable: true, type: typeof(IntGraphType));
            FieldAsync<ClassificacaoAutomovelType>("classificacaoAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoAutomovel>(c.Source.ClassificacaoAutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdCilindragemAutomovel)))));
            
        }
    }

    public class CilindragemAutomovelInputType : InputObjectGraphType
	{
		public CilindragemAutomovelInputType()
		{
			// Defining the name of the object
			Name = "cilindragemAutomovelInput";
			
            //Field<StringGraphType>("idCilindragemAutomovel");
			Field<StringGraphType>("cilindragem");
			Field<FloatGraphType>("premioUcf");
			Field<StringGraphType>("classificacaoAutomovelId");
			Field<StringGraphType>("codCilindragemAutomovel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("moedaId");
			Field<IntGraphType>("cilindragemMinima");
			Field<IntGraphType>("cilindragemMaxima");
			Field<ClassificacaoAutomovelInputType>("classificacaoAutomovel");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			
		}
	}
}