using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoInstalacaoElectricaType : ObjectGraphType<TipoInstalacaoElectrica>
    {
        public TipoInstalacaoElectricaType()
        {
            // Defining the name of the object
            Name = "tipoInstalacaoElectrica";

            Field(x => x.IdTipoInstalacaoElectrica, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoInstalacaoElectrica, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ConstrucaoType>>("construcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Construcao>(x => x.Where(e => e.HasValue(c.Source.IdTipoInstalacaoElectrica)))));
            
        }
    }

    public class TipoInstalacaoElectricaInputType : InputObjectGraphType
	{
		public TipoInstalacaoElectricaInputType()
		{
			// Defining the name of the object
			Name = "tipoInstalacaoElectricaInput";
			
            //Field<StringGraphType>("idTipoInstalacaoElectrica");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoInstalacaoElectrica");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ConstrucaoInputType>>("construcao");
			
		}
	}
}