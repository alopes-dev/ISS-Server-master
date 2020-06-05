using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PaisType : ObjectGraphType<Pais>
    {
        public PaisType()
        {
            // Defining the name of the object
            Name = "pais";

            Field(x => x.IdPais, nullable: true);
            Field(x => x.CodPais, nullable: true);
            Field(x => x.NomePais, nullable: true);
            Field(x => x.RegiaoId, nullable: true);
            Field(x => x.ContinenteId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Ddi, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodeIso, nullable: true);
            Field(x => x.CaminhoImagem, nullable: true);
            FieldAsync<ContinenteType>("continente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Continente>(c.Source.ContinenteId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<RegiaoType>("regiao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Regiao>(c.Source.RegiaoId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<ContactoType>>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<ExportacoesProdutosInstalacoesType>>("exportacoesProdutosInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExportacoesProdutosInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<GpsautomovelType>>("gpsautomovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Gpsautomovel>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<IdiomasType>>("idiomas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Idiomas>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<LocaisCoberturaType>>("locaisCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisCobertura>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<LocaisDescontoType>>("locaisDesconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisDesconto>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<LocaisEncargoType>>("locaisEncargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisEncargo>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<LocaisFranquiaType>>("locaisFranquia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisFranquia>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<LocaisImpostoType>>("locaisImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisImposto>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<LocaisLimiteCompetenciaType>>("locaisLimiteCompetencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisLimiteCompetencia>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<LocaisObjectivosComerciaisType>>("locaisObjectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisObjectivosComerciais>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<LocaisOfertaType>>("locaisOferta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocaisOferta>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<NacionalidadePessoaType>>("nacionalidadePessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NacionalidadePessoa>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<PaisesPlanoProdutoType>>("paisesPlanoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PaisesPlanoProduto>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<ProdutosInstalacoesType>>("produtosInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProdutosInstalacoes>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<ProvinciaType>>("provincia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Provincia>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<ViagemType>>("viagemPaisDestino", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Viagem>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            FieldAsync<ListGraphType<ViagemType>>("viagemPaisOrigem", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Viagem>(x => x.Where(e => e.HasValue(c.Source.IdPais)))));
            
        }
    }

    public class PaisInputType : InputObjectGraphType
	{
		public PaisInputType()
		{
			// Defining the name of the object
			Name = "paisInput";
			
            //Field<StringGraphType>("idPais");
			Field<StringGraphType>("codPais");
			Field<StringGraphType>("nomePais");
			Field<StringGraphType>("regiaoId");
			Field<StringGraphType>("continenteId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("ddi");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codeIso");
			Field<StringGraphType>("caminhoImagem");
			Field<ContinenteInputType>("continente");
			Field<EstadoInputType>("estado");
			Field<RegiaoInputType>("regiao");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			Field<ListGraphType<ContactoInputType>>("contacto");
			Field<ListGraphType<ExportacoesProdutosInstalacoesInputType>>("exportacoesProdutosInstalacoes");
			Field<ListGraphType<GpsautomovelInputType>>("gpsautomovel");
			Field<ListGraphType<IdiomasInputType>>("idiomas");
			Field<ListGraphType<LocaisCoberturaInputType>>("locaisCobertura");
			Field<ListGraphType<LocaisDescontoInputType>>("locaisDesconto");
			Field<ListGraphType<LocaisEncargoInputType>>("locaisEncargo");
			Field<ListGraphType<LocaisFranquiaInputType>>("locaisFranquia");
			Field<ListGraphType<LocaisImpostoInputType>>("locaisImposto");
			Field<ListGraphType<LocaisLimiteCompetenciaInputType>>("locaisLimiteCompetencia");
			Field<ListGraphType<LocaisObjectivosComerciaisInputType>>("locaisObjectivosComerciais");
			Field<ListGraphType<LocaisOfertaInputType>>("locaisOferta");
			Field<ListGraphType<NacionalidadePessoaInputType>>("nacionalidadePessoa");
			Field<ListGraphType<PaisesPlanoProdutoInputType>>("paisesPlanoProduto");
			Field<ListGraphType<ProdutosInstalacoesInputType>>("produtosInstalacoes");
			Field<ListGraphType<ProvinciaInputType>>("provincia");
			Field<ListGraphType<ViagemInputType>>("viagemPaisDestino");
			Field<ListGraphType<ViagemInputType>>("viagemPaisOrigem");
			
		}
	}
}