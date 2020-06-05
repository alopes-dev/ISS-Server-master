using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NewsletterType : ObjectGraphType<Newsletter>
    {
        public NewsletterType()
        {
            // Defining the name of the object
            Name = "newsletter";

            Field(x => x.IdNewsletter, nullable: true);
            Field(x => x.NomeCompleto, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.ContactoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<ContactoType>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(c.Source.ContactoId)));
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class NewsletterInputType : InputObjectGraphType
	{
		public NewsletterInputType()
		{
			// Defining the name of the object
			Name = "newsletterInput";
			
            //Field<StringGraphType>("idNewsletter");
			Field<StringGraphType>("nomeCompleto");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("contactoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<ContactoInputType>("contacto");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			
		}
	}
}