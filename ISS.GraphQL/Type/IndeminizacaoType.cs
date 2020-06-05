using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class IndeminizacaoType : ObjectGraphType<Indeminizacao>
    {
        public IndeminizacaoType()
        {
            // Defining the name of the object
            Name = "indeminizacao";

            Field(x => x.IdIndeminizacao, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodIndeminizacao, nullable: true);
            Field(x => x.ValorIndeminizacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class IndeminizacaoInputType : InputObjectGraphType
	{
		public IndeminizacaoInputType()
		{
			// Defining the name of the object
			Name = "indeminizacaoInput";
			
            //Field<StringGraphType>("idIndeminizacao");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codIndeminizacao");
			Field<FloatGraphType>("valorIndeminizacao");
			Field<StringGraphType>("sinistroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}