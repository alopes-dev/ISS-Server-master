using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SugestaoType : ObjectGraphType<Sugestao>
    {
        public SugestaoType()
        {
            // Defining the name of the object
            Name = "sugestao";

            Field(x => x.IdSugestao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.TipoSugestaoId, nullable: true);
            Field(x => x.DataHora, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodSugestao, nullable: true);
            Field(x => x.Assunto, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<TipoSugestaoType>("tipoSugestao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSugestao>(c.Source.TipoSugestaoId)));
            
        }
    }

    public class SugestaoInputType : InputObjectGraphType
	{
		public SugestaoInputType()
		{
			// Defining the name of the object
			Name = "sugestaoInput";
			
            //Field<StringGraphType>("idSugestao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("tipoSugestaoId");
			Field<DateTimeGraphType>("dataHora");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codSugestao");
			Field<StringGraphType>("assunto");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<TipoSugestaoInputType>("tipoSugestao");
			
		}
	}
}