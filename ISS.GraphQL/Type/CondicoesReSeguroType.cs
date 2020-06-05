using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CondicoesReSeguroType : ObjectGraphType<CondicoesReSeguro>
    {
        public CondicoesReSeguroType()
        {
            // Defining the name of the object
            Name = "condicoesReSeguro";

            Field(x => x.IdCondicoesReSeguro, nullable: true);
            Field(x => x.CaminhoDocumento, nullable: true);
            Field(x => x.CondicoesId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ResseguroId, nullable: true);
            FieldAsync<CondicoesType>("condicoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Condicoes>(c.Source.CondicoesId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ResseguroType>("resseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Resseguro>(c.Source.ResseguroId)));
            
        }
    }

    public class CondicoesReSeguroInputType : InputObjectGraphType
	{
		public CondicoesReSeguroInputType()
		{
			// Defining the name of the object
			Name = "condicoesReSeguroInput";
			
            //Field<StringGraphType>("idCondicoesReSeguro");
			Field<StringGraphType>("caminhoDocumento");
			Field<StringGraphType>("condicoesId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("resseguroId");
			Field<CondicoesInputType>("condicoes");
			Field<EstadoInputType>("estado");
			Field<ResseguroInputType>("resseguro");
			
		}
	}
}