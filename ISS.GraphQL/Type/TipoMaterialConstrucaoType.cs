using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoMaterialConstrucaoType : ObjectGraphType<TipoMaterialConstrucao>
    {
        public TipoMaterialConstrucaoType()
        {
            // Defining the name of the object
            Name = "tipoMaterialConstrucao";

            Field(x => x.IdTipoMaterialConstrucao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoMaterialConstrucao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ConstrucaoType>>("construcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Construcao>(x => x.Where(e => e.HasValue(c.Source.IdTipoMaterialConstrucao)))));
            
        }
    }

    public class TipoMaterialConstrucaoInputType : InputObjectGraphType
	{
		public TipoMaterialConstrucaoInputType()
		{
			// Defining the name of the object
			Name = "tipoMaterialConstrucaoInput";
			
            //Field<StringGraphType>("idTipoMaterialConstrucao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoMaterialConstrucao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ConstrucaoInputType>>("construcao");
			
		}
	}
}