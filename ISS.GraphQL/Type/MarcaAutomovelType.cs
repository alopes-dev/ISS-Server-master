using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MarcaAutomovelType : ObjectGraphType<MarcaAutomovel>
    {
        public MarcaAutomovelType()
        {
            // Defining the name of the object
            Name = "marcaAutomovel";

            Field(x => x.IdMarcaAutomovel, nullable: true);
            Field(x => x.Marca, nullable: true);
            Field(x => x.CaminhoImagem, nullable: true);
            Field(x => x.CodMarcaAutomovel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ModeloAutomovelType>>("modeloAutomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModeloAutomovel>(x => x.Where(e => e.HasValue(c.Source.IdMarcaAutomovel)))));
            FieldAsync<ListGraphType<SinistroType>>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(x => x.Where(e => e.HasValue(c.Source.IdMarcaAutomovel)))));
            
        }
    }

    public class MarcaAutomovelInputType : InputObjectGraphType
	{
		public MarcaAutomovelInputType()
		{
			// Defining the name of the object
			Name = "marcaAutomovelInput";
			
            //Field<StringGraphType>("idMarcaAutomovel");
			Field<StringGraphType>("marca");
			Field<StringGraphType>("caminhoImagem");
			Field<StringGraphType>("codMarcaAutomovel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ModeloAutomovelInputType>>("modeloAutomovel");
			Field<ListGraphType<SinistroInputType>>("sinistro");
			
		}
	}
}