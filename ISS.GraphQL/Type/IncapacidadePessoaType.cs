using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class IncapacidadePessoaType : ObjectGraphType<IncapacidadePessoa>
    {
        public IncapacidadePessoaType()
        {
            // Defining the name of the object
            Name = "incapacidadePessoa";

            Field(x => x.IdIncapacidadeTrabalhador, nullable: true);
            Field(x => x.CodIncapacidadeTrabalhador, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.TipoIncapacidade, nullable: true);
            Field(x => x.Grau, nullable: true, type: typeof(IntGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoIncapacidadeType>("tipoIncapacidadeNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoIncapacidade>(c.Source.TipoIncapacidade)));
            
        }
    }

    public class IncapacidadePessoaInputType : InputObjectGraphType
	{
		public IncapacidadePessoaInputType()
		{
			// Defining the name of the object
			Name = "incapacidadePessoaInput";
			
            //Field<StringGraphType>("idIncapacidadeTrabalhador");
			Field<StringGraphType>("codIncapacidadeTrabalhador");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("tipoIncapacidade");
			Field<IntGraphType>("grau");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TipoIncapacidadeInputType>("tipoIncapacidadeNavigation");
			
		}
	}
}