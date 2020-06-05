using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PerguntasFrequentesEmpresaType : ObjectGraphType<PerguntasFrequentesEmpresa>
    {
        public PerguntasFrequentesEmpresaType()
        {
            // Defining the name of the object
            Name = "perguntasFrequentesEmpresa";

            Field(x => x.IdPerguntasFrequentesEmpresa, nullable: true);
            Field(x => x.Pergunta, nullable: true);
            Field(x => x.Resposta, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.EmpresaId, nullable: true);
            Field(x => x.NumPergunta, nullable: true, type: typeof(IntGraphType));
            FieldAsync<EmpresaType>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Empresa>(c.Source.EmpresaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class PerguntasFrequentesEmpresaInputType : InputObjectGraphType
	{
		public PerguntasFrequentesEmpresaInputType()
		{
			// Defining the name of the object
			Name = "perguntasFrequentesEmpresaInput";
			
            //Field<StringGraphType>("idPerguntasFrequentesEmpresa");
			Field<StringGraphType>("pergunta");
			Field<StringGraphType>("resposta");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("empresaId");
			Field<IntGraphType>("numPergunta");
			Field<EmpresaInputType>("empresa");
			Field<EstadoInputType>("estado");
			
		}
	}
}