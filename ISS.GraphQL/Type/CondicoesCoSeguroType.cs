using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CondicoesCoSeguroType : ObjectGraphType<CondicoesCoSeguro>
    {
        public CondicoesCoSeguroType()
        {
            // Defining the name of the object
            Name = "condicoesCoSeguro";

            Field(x => x.IdCondicoesCoSeguro, nullable: true);
            Field(x => x.CaminhoDocumento, nullable: true);
            Field(x => x.CondicoesId, nullable: true);
            Field(x => x.CoSeguroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CoSeguroType>("coSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoSeguro>(c.Source.CoSeguroId)));
            FieldAsync<CondicoesType>("condicoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Condicoes>(c.Source.CondicoesId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class CondicoesCoSeguroInputType : InputObjectGraphType
	{
		public CondicoesCoSeguroInputType()
		{
			// Defining the name of the object
			Name = "condicoesCoSeguroInput";
			
            //Field<StringGraphType>("idCondicoesCoSeguro");
			Field<StringGraphType>("caminhoDocumento");
			Field<StringGraphType>("condicoesId");
			Field<StringGraphType>("coSeguroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CoSeguroInputType>("coSeguro");
			Field<CondicoesInputType>("condicoes");
			Field<EstadoInputType>("estado");
			
		}
	}
}