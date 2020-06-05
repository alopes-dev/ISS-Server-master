using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ValoresTipoAntenaType : ObjectGraphType<ValoresTipoAntena>
    {
        public ValoresTipoAntenaType()
        {
            // Defining the name of the object
            Name = "valoresTipoAntena";

            Field(x => x.IdValorTipoAntena, nullable: true);
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoAntenaId, nullable: true);
            Field(x => x.CodValoresTipoAntena, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LocalidadeAntenaType>("tipoAntena", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalidadeAntena>(c.Source.TipoAntenaId)));
            FieldAsync<ListGraphType<ModalidadesRcselecionadasType>>("modalidadesRcselecionadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesRcselecionadas>(x => x.Where(e => e.HasValue(c.Source.IdValorTipoAntena)))));
            
        }
    }

    public class ValoresTipoAntenaInputType : InputObjectGraphType
	{
		public ValoresTipoAntenaInputType()
		{
			// Defining the name of the object
			Name = "valoresTipoAntenaInput";
			
            //Field<StringGraphType>("idValorTipoAntena");
			Field<FloatGraphType>("valorMax");
			Field<StringGraphType>("tipoAntenaId");
			Field<StringGraphType>("codValoresTipoAntena");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<LocalidadeAntenaInputType>("tipoAntena");
			Field<ListGraphType<ModalidadesRcselecionadasInputType>>("modalidadesRcselecionadas");
			
		}
	}
}