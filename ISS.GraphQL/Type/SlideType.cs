using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SlideType : ObjectGraphType<Slide>
    {
        public SlideType()
        {
            // Defining the name of the object
            Name = "slide";

            Field(x => x.IdSlide, nullable: true);
            Field(x => x.Titulo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CaminhoFoto, nullable: true);
            Field(x => x.LinkProduto, nullable: true);
            Field(x => x.CodSlide, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class SlideInputType : InputObjectGraphType
	{
		public SlideInputType()
		{
			// Defining the name of the object
			Name = "slideInput";
			
            //Field<StringGraphType>("idSlide");
			Field<StringGraphType>("titulo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("caminhoFoto");
			Field<StringGraphType>("linkProduto");
			Field<StringGraphType>("codSlide");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			
		}
	}
}