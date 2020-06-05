using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LimiteResponsabilidadeType : ObjectGraphType<LimiteResponsabilidade>
    {
        public LimiteResponsabilidadeType()
        {
            // Defining the name of the object
            Name = "limiteResponsabilidade";

            Field(x => x.IdLimiteResponsabilidade, nullable: true);
            Field(x => x.ExcessoPerdaId, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoLimiteResponsabilidadeId, nullable: true);
            Field(x => x.CodLimiteResponsabilidade, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ExcessoPerdaType>("excessoPerda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExcessoPerda>(c.Source.ExcessoPerdaId)));
            FieldAsync<TipoLimiteResponsabilidadeType>("tipoLimiteResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoLimiteResponsabilidade>(c.Source.TipoLimiteResponsabilidadeId)));
            
        }
    }

    public class LimiteResponsabilidadeInputType : InputObjectGraphType
	{
		public LimiteResponsabilidadeInputType()
		{
			// Defining the name of the object
			Name = "limiteResponsabilidadeInput";
			
            //Field<StringGraphType>("idLimiteResponsabilidade");
			Field<StringGraphType>("excessoPerdaId");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("tipoLimiteResponsabilidadeId");
			Field<StringGraphType>("codLimiteResponsabilidade");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<EstadoInputType>("estado");
			Field<ExcessoPerdaInputType>("excessoPerda");
			Field<TipoLimiteResponsabilidadeInputType>("tipoLimiteResponsabilidade");
			
		}
	}
}