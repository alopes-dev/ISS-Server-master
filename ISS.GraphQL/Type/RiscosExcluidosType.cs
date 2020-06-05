using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RiscosExcluidosType : ObjectGraphType<RiscosExcluidos>
    {
        public RiscosExcluidosType()
        {
            // Defining the name of the object
            Name = "riscosExcluidos";

            Field(x => x.IdRiscosExcluidos, nullable: true);
            Field(x => x.NumPonto, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoExclusaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Obs, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CoberturaProdutoId, nullable: true);
            Field(x => x.CoberturasComplementaresId, nullable: true);
            Field(x => x.ValorSobrePremio, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<CoberturaType>("coberturaProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cobertura>(c.Source.CoberturaProdutoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            FieldAsync<TipoExclusaoType>("tipoExclusao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoExclusao>(c.Source.TipoExclusaoId)));
            
        }
    }

    public class RiscosExcluidosInputType : InputObjectGraphType
	{
		public RiscosExcluidosInputType()
		{
			// Defining the name of the object
			Name = "riscosExcluidosInput";
			
            //Field<StringGraphType>("idRiscosExcluidos");
			Field<IntGraphType>("numPonto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoExclusaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("obs");
			Field<StringGraphType>("tipoCoberturaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("coberturaProdutoId");
			Field<StringGraphType>("coberturasComplementaresId");
			Field<FloatGraphType>("valorSobrePremio");
			Field<CoberturaInputType>("coberturaProduto");
			Field<EstadoInputType>("estado");
			Field<TipoCoberturaInputType>("tipoCobertura");
			Field<TipoExclusaoInputType>("tipoExclusao");
			
		}
	}
}