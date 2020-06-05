using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RenovacaoApoliceType : ObjectGraphType<RenovacaoApolice>
    {
        public RenovacaoApoliceType()
        {
            // Defining the name of the object
            Name = "renovacaoApolice";

            Field(x => x.IdRenovacaoApolice, nullable: true);
            Field(x => x.DataRenovacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.TipoRenovacaoId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EmpregadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodRenovacaoApolice, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<PessoaType>("empregado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.EmpregadoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoRenovacaoType>("tipoRenovacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRenovacao>(c.Source.TipoRenovacaoId)));
            
        }
    }

    public class RenovacaoApoliceInputType : InputObjectGraphType
	{
		public RenovacaoApoliceInputType()
		{
			// Defining the name of the object
			Name = "renovacaoApoliceInput";
			
            //Field<StringGraphType>("idRenovacaoApolice");
			Field<DateTimeGraphType>("dataRenovacao");
			Field<StringGraphType>("tipoRenovacaoId");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("empregadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codRenovacaoApolice");
			Field<ApoliceInputType>("apolice");
			Field<PessoaInputType>("empregado");
			Field<EstadoInputType>("estado");
			Field<TipoRenovacaoInputType>("tipoRenovacao");
			
		}
	}
}