using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoTarifasResponsabilidadeType : ObjectGraphType<TipoTarifasResponsabilidade>
    {
        public TipoTarifasResponsabilidadeType()
        {
            // Defining the name of the object
            Name = "tipoTarifasResponsabilidade";

            Field(x => x.IdTipoTarifasResponsabilidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoTarifasResponsabilidade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<TarifasResponsabilidadeCivilType>>("tarifasResponsabilidadeCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarifasResponsabilidadeCivil>(x => x.Where(e => e.HasValue(c.Source.IdTipoTarifasResponsabilidade)))));
            
        }
    }

    public class TipoTarifasResponsabilidadeInputType : InputObjectGraphType
	{
		public TipoTarifasResponsabilidadeInputType()
		{
			// Defining the name of the object
			Name = "tipoTarifasResponsabilidadeInput";
			
            //Field<StringGraphType>("idTipoTarifasResponsabilidade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoTarifasResponsabilidade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<TarifasResponsabilidadeCivilInputType>>("tarifasResponsabilidadeCivil");
			
		}
	}
}