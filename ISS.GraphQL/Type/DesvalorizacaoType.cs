using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DesvalorizacaoType : ObjectGraphType<Desvalorizacao>
    {
        public DesvalorizacaoType()
        {
            // Defining the name of the object
            Name = "desvalorizacao";

            Field(x => x.IdDesvalorizacao, nullable: true);
            Field(x => x.Ano, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Desvalorizacao1, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CodDesvalorizacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Ordem, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.SubTipoDesvalorizacaoId, nullable: true);
            Field(x => x.Dimensao, nullable: true);
            Field(x => x.TaxaDto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TaxaEsq, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<SubTipoDesvalorizacaoType>("subTipoDesvalorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubTipoDesvalorizacao>(c.Source.SubTipoDesvalorizacaoId)));
            FieldAsync<ListGraphType<DesvalorizacaoPlanoType>>("desvalorizacaoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DesvalorizacaoPlano>(x => x.Where(e => e.HasValue(c.Source.IdDesvalorizacao)))));
            
        }
    }

    public class DesvalorizacaoInputType : InputObjectGraphType
	{
		public DesvalorizacaoInputType()
		{
			// Defining the name of the object
			Name = "desvalorizacaoInput";
			
            //Field<StringGraphType>("idDesvalorizacao");
			Field<IntGraphType>("ano");
			Field<FloatGraphType>("desvalorizacao1");
			Field<StringGraphType>("codDesvalorizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ordem");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("subTipoDesvalorizacaoId");
			Field<StringGraphType>("dimensao");
			Field<FloatGraphType>("taxaDto");
			Field<FloatGraphType>("taxaEsq");
			Field<SubTipoDesvalorizacaoInputType>("subTipoDesvalorizacao");
			Field<ListGraphType<DesvalorizacaoPlanoInputType>>("desvalorizacaoPlano");
			
		}
	}
}