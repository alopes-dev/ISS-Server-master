using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PerfilDesenvolvimentoType : ObjectGraphType<PerfilDesenvolvimento>
    {
        public PerfilDesenvolvimentoType()
        {
            // Defining the name of the object
            Name = "perfilDesenvolvimento";

            Field(x => x.IdPerfilDesenvolvimento, nullable: true);
            Field(x => x.CodPerfilDesenvolvimento, nullable: true);
            Field(x => x.NomeBaseDados, nullable: true);
            Field(x => x.NomePastaProgroma, nullable: true);
            Field(x => x.Ipv4BaseDados, nullable: true);
            Field(x => x.Ipv4Iss, nullable: true);
            Field(x => x.Ipv6BaseDados, nullable: true);
            Field(x => x.Ipv6Iss, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PerfilDesenvolvimentoPessoaType>>("perfilDesenvolvimentoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PerfilDesenvolvimentoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdPerfilDesenvolvimento)))));
            
        }
    }

    public class PerfilDesenvolvimentoInputType : InputObjectGraphType
	{
		public PerfilDesenvolvimentoInputType()
		{
			// Defining the name of the object
			Name = "perfilDesenvolvimentoInput";
			
            //Field<StringGraphType>("idPerfilDesenvolvimento");
			Field<StringGraphType>("codPerfilDesenvolvimento");
			Field<StringGraphType>("nomeBaseDados");
			Field<StringGraphType>("nomePastaProgroma");
			Field<StringGraphType>("ipv4BaseDados");
			Field<StringGraphType>("ipv4Iss");
			Field<StringGraphType>("ipv6BaseDados");
			Field<StringGraphType>("ipv6Iss");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("designacao");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PerfilDesenvolvimentoPessoaInputType>>("perfilDesenvolvimentoPessoa");
			
		}
	}
}