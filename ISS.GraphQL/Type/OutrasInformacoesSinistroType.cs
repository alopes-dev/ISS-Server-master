using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OutrasInformacoesSinistroType : ObjectGraphType<OutrasInformacoesSinistro>
    {
        public OutrasInformacoesSinistroType()
        {
            // Defining the name of the object
            Name = "outrasInformacoesSinistro";

            Field(x => x.IdOutrasInformacoesSinistro, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.CodOutrasInformacoesSinistro, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class OutrasInformacoesSinistroInputType : InputObjectGraphType
	{
		public OutrasInformacoesSinistroInputType()
		{
			// Defining the name of the object
			Name = "outrasInformacoesSinistroInput";
			
            //Field<StringGraphType>("idOutrasInformacoesSinistro");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("codOutrasInformacoesSinistro");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}