using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ListaNegraType : ObjectGraphType<ListaNegra>
    {
        public ListaNegraType()
        {
            // Defining the name of the object
            Name = "listaNegra";

            Field(x => x.IdListaNegra, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodListaNegra, nullable: true);
            Field(x => x.OrgaoRegularizadorId, nullable: true);
            Field(x => x.Obs, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<OrgaoRegularizadorType>("orgaoRegularizador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OrgaoRegularizador>(c.Source.OrgaoRegularizadorId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class ListaNegraInputType : InputObjectGraphType
	{
		public ListaNegraInputType()
		{
			// Defining the name of the object
			Name = "listaNegraInput";
			
            //Field<StringGraphType>("idListaNegra");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codListaNegra");
			Field<StringGraphType>("orgaoRegularizadorId");
			Field<StringGraphType>("obs");
			Field<EstadoInputType>("estado");
			Field<OrgaoRegularizadorInputType>("orgaoRegularizador");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}