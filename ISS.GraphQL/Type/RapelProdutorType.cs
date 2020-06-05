using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RapelProdutorType : ObjectGraphType<RapelProdutor>
    {
        public RapelProdutorType()
        {
            // Defining the name of the object
            Name = "rapelProdutor";

            Field(x => x.IdRapelProdutor, nullable: true);
            Field(x => x.CodRapelProdutor, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.PlanoProdutoId, nullable: true);
            Field(x => x.TipoRamoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.LimitesRapelId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LimitesRapelType>("limitesRapel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LimitesRapel>(c.Source.LimitesRapelId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PlanoProdutoType>("planoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoProduto>(c.Source.PlanoProdutoId)));
            FieldAsync<TipoRamoSeguroType>("tipoRamo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRamoSeguro>(c.Source.TipoRamoId)));
            FieldAsync<ListGraphType<PapelProdutorType>>("papelProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelProdutor>(x => x.Where(e => e.HasValue(c.Source.IdRapelProdutor)))));
            
        }
    }

    public class RapelProdutorInputType : InputObjectGraphType
	{
		public RapelProdutorInputType()
		{
			// Defining the name of the object
			Name = "rapelProdutorInput";
			
            //Field<StringGraphType>("idRapelProdutor");
			Field<StringGraphType>("codRapelProdutor");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("planoProdutoId");
			Field<StringGraphType>("tipoRamoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<StringGraphType>("limitesRapelId");
			Field<EstadoInputType>("estado");
			Field<LimitesRapelInputType>("limitesRapel");
			Field<PessoaInputType>("pessoa");
			Field<PlanoProdutoInputType>("planoProduto");
			Field<TipoRamoSeguroInputType>("tipoRamo");
			Field<ListGraphType<PapelProdutorInputType>>("papelProdutor");
			
		}
	}
}