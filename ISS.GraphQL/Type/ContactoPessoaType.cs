using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContactoPessoaType : ObjectGraphType<ContactoPessoa>
    {
        public ContactoPessoaType()
        {
            // Defining the name of the object
            Name = "contactoPessoa";

            Field(x => x.IdContactoPessoa, nullable: true);
            Field(x => x.Principal, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.ContactoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodContactoPessoa, nullable: true);
            FieldAsync<ContactoType>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(c.Source.ContactoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class ContactoPessoaInputType : InputObjectGraphType
	{
		public ContactoPessoaInputType()
		{
			// Defining the name of the object
			Name = "contactoPessoaInput";
			
            //Field<StringGraphType>("idContactoPessoa");
			Field<BooleanGraphType>("principal");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("contactoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codContactoPessoa");
			Field<ContactoInputType>("contacto");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}