using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PreferenciaUsuarioType : ObjectGraphType<PreferenciaUsuario>
    {
        public PreferenciaUsuarioType()
        {
            // Defining the name of the object
            Name = "preferenciaUsuario";

            Field(x => x.IdPreferenciaUsuario, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodPreferenciaUsuario, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoPreferenciaUsuario, nullable: true);
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PreferenciaUsuarioType>("tipoPreferenciaUsuarioNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PreferenciaUsuario>(c.Source.TipoPreferenciaUsuario)));
            FieldAsync<ListGraphType<PreferenciaUsuarioType>>("inverseTipoPreferenciaUsuarioNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PreferenciaUsuario>(x => x.Where(e => e.HasValue(c.Source.IdPreferenciaUsuario)))));
            
        }
    }

    public class PreferenciaUsuarioInputType : InputObjectGraphType
	{
		public PreferenciaUsuarioInputType()
		{
			// Defining the name of the object
			Name = "preferenciaUsuarioInput";
			
            //Field<StringGraphType>("idPreferenciaUsuario");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codPreferenciaUsuario");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("tipoPreferenciaUsuario");
			Field<PessoaInputType>("pessoa");
			Field<PreferenciaUsuarioInputType>("tipoPreferenciaUsuarioNavigation");
			Field<ListGraphType<PreferenciaUsuarioInputType>>("inverseTipoPreferenciaUsuarioNavigation");
			
		}
	}
}