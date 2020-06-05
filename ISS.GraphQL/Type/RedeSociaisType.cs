using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RedeSociaisType : ObjectGraphType<RedeSociais>
    {
        public RedeSociaisType()
        {
            // Defining the name of the object
            Name = "redeSociais";

            Field(x => x.IdRedeSociais, nullable: true);
            Field(x => x.LinkRedeSocial, nullable: true);
            Field(x => x.ContactoId, nullable: true);
            Field(x => x.TipoRedeSociaisId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<ContactoType>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(c.Source.ContactoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoRedeSociaisType>("tipoRedeSociais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRedeSociais>(c.Source.TipoRedeSociaisId)));
            FieldAsync<ListGraphType<RedeSocialPessoaType>>("redeSocialPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RedeSocialPessoa>(x => x.Where(e => e.HasValue(c.Source.IdRedeSociais)))));
            
        }
    }

    public class RedeSociaisInputType : InputObjectGraphType
	{
		public RedeSociaisInputType()
		{
			// Defining the name of the object
			Name = "redeSociaisInput";
			
            //Field<StringGraphType>("idRedeSociais");
			Field<StringGraphType>("linkRedeSocial");
			Field<StringGraphType>("contactoId");
			Field<StringGraphType>("tipoRedeSociaisId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<ContactoInputType>("contacto");
			Field<EstadoInputType>("estado");
			Field<TipoRedeSociaisInputType>("tipoRedeSociais");
			Field<ListGraphType<RedeSocialPessoaInputType>>("redeSocialPessoa");
			
		}
	}
}