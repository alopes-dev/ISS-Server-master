using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FormaEntregaType : ObjectGraphType<FormaEntrega>
    {
        public FormaEntregaType()
        {
            // Defining the name of the object
            Name = "formaEntrega";

            Field(x => x.IdFormaEntrega, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFormaEntrega, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PessoaProfissaoType>>("pessoaProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(x => x.Where(e => e.HasValue(c.Source.IdFormaEntrega)))));
            
        }
    }

    public class FormaEntregaInputType : InputObjectGraphType
	{
		public FormaEntregaInputType()
		{
			// Defining the name of the object
			Name = "formaEntregaInput";
			
            //Field<StringGraphType>("idFormaEntrega");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFormaEntrega");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PessoaProfissaoInputType>>("pessoaProfissao");
			
		}
	}
}