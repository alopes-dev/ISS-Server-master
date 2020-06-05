using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SituacaoEmpregoType : ObjectGraphType<SituacaoEmprego>
    {
        public SituacaoEmpregoType()
        {
            // Defining the name of the object
            Name = "situacaoEmprego";

            Field(x => x.IdSituacaoEmprego, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodSituacaoEmprego, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdSituacaoEmprego)))));
            
        }
    }

    public class SituacaoEmpregoInputType : InputObjectGraphType
	{
		public SituacaoEmpregoInputType()
		{
			// Defining the name of the object
			Name = "situacaoEmpregoInput";
			
            //Field<StringGraphType>("idSituacaoEmprego");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codSituacaoEmprego");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PessoaInputType>>("pessoa");
			
		}
	}
}