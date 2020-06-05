using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CondicoesType : ObjectGraphType<Condicoes>
    {
        public CondicoesType()
        {
            // Defining the name of the object
            Name = "condicoes";

            Field(x => x.IdCondicao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CaminhoFicheiro, nullable: true);
            Field(x => x.TipoCondicoesId, nullable: true);
            Field(x => x.CodCondicoes, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCondicoesType>("tipoCondicoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCondicoes>(c.Source.TipoCondicoesId)));
            FieldAsync<ListGraphType<CapituloType>>("capitulo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Capitulo>(x => x.Where(e => e.HasValue(c.Source.IdCondicao)))));
            FieldAsync<ListGraphType<CondicoesApoliceType>>("condicoesApolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicoesApolice>(x => x.Where(e => e.HasValue(c.Source.IdCondicao)))));
            FieldAsync<ListGraphType<CondicoesCoSeguroType>>("condicoesCoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicoesCoSeguro>(x => x.Where(e => e.HasValue(c.Source.IdCondicao)))));
            FieldAsync<ListGraphType<CondicoesReSeguroType>>("condicoesReSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicoesReSeguro>(x => x.Where(e => e.HasValue(c.Source.IdCondicao)))));
            
        }
    }

    public class CondicoesInputType : InputObjectGraphType
	{
		public CondicoesInputType()
		{
			// Defining the name of the object
			Name = "condicoesInput";
			
            //Field<StringGraphType>("idCondicao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("caminhoFicheiro");
			Field<StringGraphType>("tipoCondicoesId");
			Field<StringGraphType>("codCondicoes");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<TipoCondicoesInputType>("tipoCondicoes");
			Field<ListGraphType<CapituloInputType>>("capitulo");
			Field<ListGraphType<CondicoesApoliceInputType>>("condicoesApolice");
			Field<ListGraphType<CondicoesCoSeguroInputType>>("condicoesCoSeguro");
			Field<ListGraphType<CondicoesReSeguroInputType>>("condicoesReSeguro");
			
		}
	}
}