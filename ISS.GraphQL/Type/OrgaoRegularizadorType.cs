using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OrgaoRegularizadorType : ObjectGraphType<OrgaoRegularizador>
    {
        public OrgaoRegularizadorType()
        {
            // Defining the name of the object
            Name = "orgaoRegularizador";

            Field(x => x.IdOrgaoRegularizador, nullable: true);
            Field(x => x.CodOrgaoRegularizador, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<ListGraphType<ListaNegraType>>("listaNegra", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ListaNegra>(x => x.Where(e => e.HasValue(c.Source.IdOrgaoRegularizador)))));
            FieldAsync<ListGraphType<ModeloMapaType>>("modeloMapa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModeloMapa>(x => x.Where(e => e.HasValue(c.Source.IdOrgaoRegularizador)))));
            
        }
    }

    public class OrgaoRegularizadorInputType : InputObjectGraphType
	{
		public OrgaoRegularizadorInputType()
		{
			// Defining the name of the object
			Name = "orgaoRegularizadorInput";
			
            //Field<StringGraphType>("idOrgaoRegularizador");
			Field<StringGraphType>("codOrgaoRegularizador");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<ListGraphType<ListaNegraInputType>>("listaNegra");
			Field<ListGraphType<ModeloMapaInputType>>("modeloMapa");
			
		}
	}
}