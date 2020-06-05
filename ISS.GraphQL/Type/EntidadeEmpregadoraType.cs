using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EntidadeEmpregadoraType : ObjectGraphType<EntidadeEmpregadora>
    {
        public EntidadeEmpregadoraType()
        {
            // Defining the name of the object
            Name = "entidadeEmpregadora";

            Field(x => x.IdEntidadeEmpregadora, nullable: true);
            Field(x => x.Nif, nullable: true);
            Field(x => x.Caeid, nullable: true);
            Field(x => x.ClassificacaoEntidadeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Nome, nullable: true);
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.Caeid)));
            FieldAsync<ClassificacaoEntidadeType>("classificacaoEntidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoEntidade>(c.Source.ClassificacaoEntidadeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class EntidadeEmpregadoraInputType : InputObjectGraphType
	{
		public EntidadeEmpregadoraInputType()
		{
			// Defining the name of the object
			Name = "entidadeEmpregadoraInput";
			
            //Field<StringGraphType>("idEntidadeEmpregadora");
			Field<StringGraphType>("nif");
			Field<StringGraphType>("caeid");
			Field<StringGraphType>("classificacaoEntidadeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("nome");
			Field<CaeInputType>("cae");
			Field<ClassificacaoEntidadeInputType>("classificacaoEntidade");
			Field<EstadoInputType>("estado");
			
		}
	}
}