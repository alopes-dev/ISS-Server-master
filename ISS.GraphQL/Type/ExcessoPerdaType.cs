using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExcessoPerdaType : ObjectGraphType<ExcessoPerda>
    {
        public ExcessoPerdaType()
        {
            // Defining the name of the object
            Name = "excessoPerda";

            Field(x => x.IdExcessoPerda, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ResseguroId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PontoExcesso, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoExcessoPerdaId, nullable: true);
            Field(x => x.CodExcessoPerda, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ResseguroType>("resseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Resseguro>(c.Source.ResseguroId)));
            FieldAsync<TipoSubTratadoType>("tipoExcessoPerda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSubTratado>(c.Source.TipoExcessoPerdaId)));
            FieldAsync<ListGraphType<LimiteResponsabilidadeType>>("limiteResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimiteResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdExcessoPerda)))));
            
        }
    }

    public class ExcessoPerdaInputType : InputObjectGraphType
	{
		public ExcessoPerdaInputType()
		{
			// Defining the name of the object
			Name = "excessoPerdaInput";
			
            //Field<StringGraphType>("idExcessoPerda");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("resseguroId");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("pontoExcesso");
			Field<StringGraphType>("tipoExcessoPerdaId");
			Field<StringGraphType>("codExcessoPerda");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<EstadoInputType>("estado");
			Field<ResseguroInputType>("resseguro");
			Field<TipoSubTratadoInputType>("tipoExcessoPerda");
			Field<ListGraphType<LimiteResponsabilidadeInputType>>("limiteResponsabilidade");
			
		}
	}
}