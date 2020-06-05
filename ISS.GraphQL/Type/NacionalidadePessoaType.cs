using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NacionalidadePessoaType : ObjectGraphType<NacionalidadePessoa>
    {
        public NacionalidadePessoaType()
        {
            // Defining the name of the object
            Name = "nacionalidadePessoa";

            Field(x => x.IdNacionalidadePessoa, nullable: true);
            Field(x => x.Principal, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.NacionalidadeId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodNacionalidadePessoa, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PaisType>("nacionalidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.NacionalidadeId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<ListGraphType<NacionalidadePessoaPlanoType>>("nacionalidadePessoaPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NacionalidadePessoaPlano>(x => x.Where(e => e.HasValue(c.Source.IdNacionalidadePessoa)))));
            
        }
    }

    public class NacionalidadePessoaInputType : InputObjectGraphType
	{
		public NacionalidadePessoaInputType()
		{
			// Defining the name of the object
			Name = "nacionalidadePessoaInput";
			
            //Field<StringGraphType>("idNacionalidadePessoa");
			Field<BooleanGraphType>("principal");
			Field<StringGraphType>("nacionalidadeId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codNacionalidadePessoa");
			Field<EstadoInputType>("estado");
			Field<PaisInputType>("nacionalidade");
			Field<PessoaInputType>("pessoa");
			Field<ListGraphType<NacionalidadePessoaPlanoInputType>>("nacionalidadePessoaPlano");
			
		}
	}
}