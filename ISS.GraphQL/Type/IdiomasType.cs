using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class IdiomasType : ObjectGraphType<Idiomas>
    {
        public IdiomasType()
        {
            // Defining the name of the object
            Name = "idiomas";

            Field(x => x.IdIdioma, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodIdiomas, nullable: true);
            Field(x => x.PaisId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PaisType>("pais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisId)));
            FieldAsync<ListGraphType<IdiomaPessoaType>>("idiomaPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<IdiomaPessoa>(x => x.Where(e => e.HasValue(c.Source.IdIdioma)))));
            
        }
    }

    public class IdiomasInputType : InputObjectGraphType
	{
		public IdiomasInputType()
		{
			// Defining the name of the object
			Name = "idiomasInput";
			
            //Field<StringGraphType>("idIdioma");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codIdiomas");
			Field<StringGraphType>("paisId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<PaisInputType>("pais");
			Field<ListGraphType<IdiomaPessoaInputType>>("idiomaPessoa");
			
		}
	}
}