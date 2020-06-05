using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModalidadeSeguroType : ObjectGraphType<ModalidadeSeguro>
    {
        public ModalidadeSeguroType()
        {
            // Defining the name of the object
            Name = "modalidadeSeguro";

            Field(x => x.IdModalidadeSeguro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodModalidadeSeguro, nullable: true);
            Field(x => x.TipoSeguroId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoSeguroType>("tipoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSeguro>(c.Source.TipoSeguroId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdModalidadeSeguro)))));
            FieldAsync<ListGraphType<GrupoEtarioType>>("grupoEtario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GrupoEtario>(x => x.Where(e => e.HasValue(c.Source.IdModalidadeSeguro)))));
            FieldAsync<ListGraphType<PerguntasType>>("perguntas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perguntas>(x => x.Where(e => e.HasValue(c.Source.IdModalidadeSeguro)))));
            
        }
    }

    public class ModalidadeSeguroInputType : InputObjectGraphType
	{
		public ModalidadeSeguroInputType()
		{
			// Defining the name of the object
			Name = "modalidadeSeguroInput";
			
            //Field<StringGraphType>("idModalidadeSeguro");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codModalidadeSeguro");
			Field<StringGraphType>("tipoSeguroId");
			Field<EstadoInputType>("estado");
			Field<TipoSeguroInputType>("tipoSeguro");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			Field<ListGraphType<GrupoEtarioInputType>>("grupoEtario");
			Field<ListGraphType<PerguntasInputType>>("perguntas");
			
		}
	}
}