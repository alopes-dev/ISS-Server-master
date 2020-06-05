using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ImagensConstrucaoType : ObjectGraphType<ImagensConstrucao>
    {
        public ImagensConstrucaoType()
        {
            // Defining the name of the object
            Name = "imagensConstrucao";

            Field(x => x.IdImagensPredio, nullable: true);
            Field(x => x.CaminhoImagemConstrucao, nullable: true);
            Field(x => x.ConstrucaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ConstrucaoType>("construcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Construcao>(c.Source.ConstrucaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ImagensConstrucaoInputType : InputObjectGraphType
	{
		public ImagensConstrucaoInputType()
		{
			// Defining the name of the object
			Name = "imagensConstrucaoInput";
			
            //Field<StringGraphType>("idImagensPredio");
			Field<StringGraphType>("caminhoImagemConstrucao");
			Field<StringGraphType>("construcaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<ConstrucaoInputType>("construcao");
			Field<EstadoInputType>("estado");
			
		}
	}
}