using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSeguroType : ObjectGraphType<TipoSeguro>
    {
        public TipoSeguroType()
        {
            // Defining the name of the object
            Name = "tipoSeguro";

            Field(x => x.IdTipoSeguro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoSeguro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdTipoSeguro)))));
            FieldAsync<ListGraphType<ModalidadeSeguroType>>("modalidadeSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadeSeguro>(x => x.Where(e => e.HasValue(c.Source.IdTipoSeguro)))));
            FieldAsync<ListGraphType<SinistroType>>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(x => x.Where(e => e.HasValue(c.Source.IdTipoSeguro)))));
            
        }
    }

    public class TipoSeguroInputType : InputObjectGraphType
	{
		public TipoSeguroInputType()
		{
			// Defining the name of the object
			Name = "tipoSeguroInput";
			
            //Field<StringGraphType>("idTipoSeguro");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoSeguro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<ModalidadeSeguroInputType>>("modalidadeSeguro");
			Field<ListGraphType<SinistroInputType>>("sinistro");
			
		}
	}
}