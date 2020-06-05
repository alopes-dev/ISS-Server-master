using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoContratoType : ObjectGraphType<TipoContrato>
    {
        public TipoContratoType()
        {
            // Defining the name of the object
            Name = "tipoContrato";

            Field(x => x.IdTipoContrato, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoContrato, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoServicoId, nullable: true);
            Field(x => x.CodDesignacao, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoServicoType>("tipoServico", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoServico>(c.Source.TipoServicoId)));
            FieldAsync<ListGraphType<ClassificacaoContratoResseguroType>>("classificacaoContratoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoContratoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdTipoContrato)))));
            FieldAsync<ListGraphType<ContratoType>>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(x => x.Where(e => e.HasValue(c.Source.IdTipoContrato)))));
            FieldAsync<ListGraphType<MediacaoComissaoType>>("mediacaoComissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MediacaoComissao>(x => x.Where(e => e.HasValue(c.Source.IdTipoContrato)))));
            FieldAsync<ListGraphType<TipoContratoEmpresaType>>("tipoContratoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContratoEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdTipoContrato)))));
            
        }
    }

    public class TipoContratoInputType : InputObjectGraphType
	{
		public TipoContratoInputType()
		{
			// Defining the name of the object
			Name = "tipoContratoInput";
			
            //Field<StringGraphType>("idTipoContrato");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoContrato");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoServicoId");
			Field<StringGraphType>("codDesignacao");
			Field<EstadoInputType>("estado");
			Field<TipoServicoInputType>("tipoServico");
			Field<ListGraphType<ClassificacaoContratoResseguroInputType>>("classificacaoContratoResseguro");
			Field<ListGraphType<ContratoInputType>>("contrato");
			Field<ListGraphType<MediacaoComissaoInputType>>("mediacaoComissao");
			Field<ListGraphType<TipoContratoEmpresaInputType>>("tipoContratoEmpresa");
			
		}
	}
}