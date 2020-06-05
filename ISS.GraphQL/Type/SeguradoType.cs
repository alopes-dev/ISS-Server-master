using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SeguradoType : ObjectGraphType<Segurado>
    {
        public SeguradoType()
        {
            // Defining the name of the object
            Name = "segurado";

            Field(x => x.IdSegurado, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodSegurado, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class SeguradoInputType : InputObjectGraphType
	{
		public SeguradoInputType()
		{
			// Defining the name of the object
			Name = "seguradoInput";
			
            //Field<StringGraphType>("idSegurado");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codSegurado");
			Field<StringGraphType>("apoliceId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}