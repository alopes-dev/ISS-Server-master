using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SinistradoType : ObjectGraphType<Sinistrado>
    {
        public SinistradoType()
        {
            // Defining the name of the object
            Name = "sinistrado";

            Field(x => x.IdSinistrado, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodSinistrado, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class SinistradoInputType : InputObjectGraphType
	{
		public SinistradoInputType()
		{
			// Defining the name of the object
			Name = "sinistradoInput";
			
            //Field<StringGraphType>("idSinistrado");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codSinistrado");
			Field<StringGraphType>("sinistroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}