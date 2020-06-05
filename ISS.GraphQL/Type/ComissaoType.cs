using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ComissaoType : ObjectGraphType<Comissao>
    {
        public ComissaoType()
        {
            // Defining the name of the object
            Name = "comissao";

            Field(x => x.IdComissao, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ComissionamentoId, nullable: true);
            Field(x => x.TipoComissaoId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.TipoDocumentoId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<ComissionamentoType>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(c.Source.ComissionamentoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<TipoComissaoType>("tipoComissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoComissao>(c.Source.TipoComissaoId)));
            FieldAsync<TipoDocumentosType>("tipoDocumento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoDocumentos>(c.Source.TipoDocumentoId)));
            FieldAsync<ListGraphType<ExcedenteType>>("excedente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Excedente>(x => x.Where(e => e.HasValue(c.Source.IdComissao)))));
            FieldAsync<ListGraphType<FacultativoResseguroType>>("facultativoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FacultativoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdComissao)))));
            FieldAsync<ListGraphType<SubFormaResseguroInformacaoType>>("subFormaResseguroInformacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubFormaResseguroInformacao>(x => x.Where(e => e.HasValue(c.Source.IdComissao)))));
            
        }
    }

    public class ComissaoInputType : InputObjectGraphType
	{
		public ComissaoInputType()
		{
			// Defining the name of the object
			Name = "comissaoInput";
			
            //Field<StringGraphType>("idComissao");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("comissionamentoId");
			Field<StringGraphType>("tipoComissaoId");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("tipoDocumentoId");
			Field<ApoliceInputType>("apolice");
			Field<ComissionamentoInputType>("comissionamento");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<PessoaInputType>("pessoa");
			Field<TipoComissaoInputType>("tipoComissao");
			Field<TipoDocumentosInputType>("tipoDocumento");
			Field<ListGraphType<ExcedenteInputType>>("excedente");
			Field<ListGraphType<FacultativoResseguroInputType>>("facultativoResseguro");
			Field<ListGraphType<SubFormaResseguroInformacaoInputType>>("subFormaResseguroInformacao");
			
		}
	}
}