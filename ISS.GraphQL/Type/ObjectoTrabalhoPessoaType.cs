using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ObjectoTrabalhoPessoaType : ObjectGraphType<ObjectoTrabalhoPessoa>
    {
        public ObjectoTrabalhoPessoaType()
        {
            // Defining the name of the object
            Name = "objectoTrabalhoPessoa";

            Field(x => x.IdObjectoTrabalhoPessoa, nullable: true);
            Field(x => x.ObjectoTrabalhoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodObjectoTrabalhoPessoa, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ObjectoTrabalhoType>("objectoTrabalho", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoTrabalho>(c.Source.ObjectoTrabalhoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class ObjectoTrabalhoPessoaInputType : InputObjectGraphType
	{
		public ObjectoTrabalhoPessoaInputType()
		{
			// Defining the name of the object
			Name = "objectoTrabalhoPessoaInput";
			
            //Field<StringGraphType>("idObjectoTrabalhoPessoa");
			Field<StringGraphType>("objectoTrabalhoId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codObjectoTrabalhoPessoa");
			Field<EstadoInputType>("estado");
			Field<ObjectoTrabalhoInputType>("objectoTrabalho");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}