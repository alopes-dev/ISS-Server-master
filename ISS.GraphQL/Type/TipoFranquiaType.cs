using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoFranquiaType : ObjectGraphType<TipoFranquia>
    {
        public TipoFranquiaType()
        {
            // Defining the name of the object
            Name = "tipoFranquia";

            Field(x => x.IdTipoFranquia, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoFranquia, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<DescontoFranquiaMedicamentoType>>("descontoFranquiaMedicamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescontoFranquiaMedicamento>(x => x.Where(e => e.HasValue(c.Source.IdTipoFranquia)))));
            
        }
    }

    public class TipoFranquiaInputType : InputObjectGraphType
	{
		public TipoFranquiaInputType()
		{
			// Defining the name of the object
			Name = "tipoFranquiaInput";
			
            //Field<StringGraphType>("idTipoFranquia");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoFranquia");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<DescontoFranquiaMedicamentoInputType>>("descontoFranquiaMedicamento");
			
		}
	}
}