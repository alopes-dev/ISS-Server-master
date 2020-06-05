using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CausadorSinistroType : ObjectGraphType<CausadorSinistro>
    {
        public CausadorSinistroType()
        {
            // Defining the name of the object
            Name = "causadorSinistro";

            Field(x => x.IdCausadorSinistro, nullable: true);
            Field(x => x.CausadorId, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodCausadorSinistro, nullable: true);
            FieldAsync<PessoaType>("causador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.CausadorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class CausadorSinistroInputType : InputObjectGraphType
	{
		public CausadorSinistroInputType()
		{
			// Defining the name of the object
			Name = "causadorSinistroInput";
			
            //Field<StringGraphType>("idCausadorSinistro");
			Field<StringGraphType>("causadorId");
			Field<StringGraphType>("sinistroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codCausadorSinistro");
			Field<PessoaInputType>("causador");
			Field<EstadoInputType>("estado");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}