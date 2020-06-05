using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DocumentosObrigatorioPlanoType : ObjectGraphType<DocumentosObrigatorioPlano>
    {
        public DocumentosObrigatorioPlanoType()
        {
            // Defining the name of the object
            Name = "documentosObrigatorioPlano";

            Field(x => x.IdDocumentosObrigatorioPlano, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodDocumentosObrigatorioPlano, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Eobrigatorio, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            
        }
    }

    public class DocumentosObrigatorioPlanoInputType : InputObjectGraphType
	{
		public DocumentosObrigatorioPlanoInputType()
		{
			// Defining the name of the object
			Name = "documentosObrigatorioPlanoInput";
			
            //Field<StringGraphType>("idDocumentosObrigatorioPlano");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("planoProdutoId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codDocumentosObrigatorioPlano");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<BooleanGraphType>("eobrigatorio");
			Field<EstadoInputType>("estado");
			Field<PlanoProdutoInputType>("planoProduto");
			
		}
	}
}