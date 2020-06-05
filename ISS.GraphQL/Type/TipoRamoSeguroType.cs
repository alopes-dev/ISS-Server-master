using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoRamoSeguroType : ObjectGraphType<TipoRamoSeguro>
    {
        public TipoRamoSeguroType()
        {
            // Defining the name of the object
            Name = "tipoRamoSeguro";

            Field(x => x.IdTipo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoRamoSeguro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ImpostoType>>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<OutraSeguradoraContratoType>>("outraSeguradoraContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OutraSeguradoraContrato>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<PortfolioProdutoType>>("portfolioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PortfolioProduto>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<RamoQualidadeSeguraType>>("ramoQualidadeSegura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RamoQualidadeSegura>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<RapelProdutorType>>("rapelProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RapelProdutor>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<ReservasTecnicasType>>("reservasTecnicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReservasTecnicas>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<TipoDesvalorizacaoType>>("tipoDesvalorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDesvalorizacao>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<TipoImpostoType>>("tipoImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoImposto>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            
        }
    }

    public class TipoRamoSeguroInputType : InputObjectGraphType
	{
		public TipoRamoSeguroInputType()
		{
			// Defining the name of the object
			Name = "tipoRamoSeguroInput";
			
            //Field<StringGraphType>("idTipo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoRamoSeguro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<FloatGraphType>("taxa");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ImpostoInputType>>("imposto");
			Field<ListGraphType<OutraSeguradoraContratoInputType>>("outraSeguradoraContrato");
			Field<ListGraphType<PortfolioProdutoInputType>>("portfolioProduto");
			Field<ListGraphType<RamoQualidadeSeguraInputType>>("ramoQualidadeSegura");
			Field<ListGraphType<RapelProdutorInputType>>("rapelProdutor");
			Field<ListGraphType<ReservasTecnicasInputType>>("reservasTecnicas");
			Field<ListGraphType<TipoDesvalorizacaoInputType>>("tipoDesvalorizacao");
			Field<ListGraphType<TipoImpostoInputType>>("tipoImposto");
			
		}
	}
}