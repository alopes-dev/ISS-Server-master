using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FaseDocumentosObrigatorioType : ObjectGraphType<FaseDocumentosObrigatorio>
    {
        public FaseDocumentosObrigatorioType()
        {
            // Defining the name of the object
            Name = "faseDocumentosObrigatorio";

            Field(x => x.IdFase, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFaseDocumentosObrigatorio, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<DocumentosObrigatorioProdutoType>>("documentosObrigatorioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosObrigatorioProduto>(x => x.Where(e => e.HasValue(c.Source.IdFase)))));
            
        }
    }

    public class FaseDocumentosObrigatorioInputType : InputObjectGraphType
	{
		public FaseDocumentosObrigatorioInputType()
		{
			// Defining the name of the object
			Name = "faseDocumentosObrigatorioInput";
			
            //Field<StringGraphType>("idFase");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFaseDocumentosObrigatorio");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<DocumentosObrigatorioProdutoInputType>>("documentosObrigatorioProduto");
			
		}
	}
}