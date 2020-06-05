using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FiliacaoType : ObjectGraphType<Filiacao>
    {
        public FiliacaoType()
        {
            // Defining the name of the object
            Name = "filiacao";

            Field(x => x.IdFiliacao, nullable: true);
            Field(x => x.NomePai, nullable: true);
            Field(x => x.NomeMae, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodFiliacao, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class FiliacaoInputType : InputObjectGraphType
	{
		public FiliacaoInputType()
		{
			// Defining the name of the object
			Name = "filiacaoInput";
			
            //Field<StringGraphType>("idFiliacao");
			Field<StringGraphType>("nomePai");
			Field<StringGraphType>("nomeMae");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codFiliacao");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}