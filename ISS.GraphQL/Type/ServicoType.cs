using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ServicoType : ObjectGraphType<Servico>
    {
        public ServicoType()
        {
            // Defining the name of the object
            Name = "servico";

            Field(x => x.IdServico, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoServicoId, nullable: true);
            Field(x => x.CodServico, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Preco, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.PrestadorServicoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PrestadorServicoType>("prestadorServico", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrestadorServico>(c.Source.PrestadorServicoId)));
            FieldAsync<TipoServicoType>("tipoServico", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoServico>(c.Source.TipoServicoId)));
            FieldAsync<ListGraphType<ServicoPlanoType>>("servicoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ServicoPlano>(x => x.Where(e => e.HasValue(c.Source.IdServico)))));
            FieldAsync<ListGraphType<ServicosAdicionaisType>>("servicosAdicionais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ServicosAdicionais>(x => x.Where(e => e.HasValue(c.Source.IdServico)))));
            FieldAsync<ListGraphType<ServicosBaseType>>("servicosBase", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ServicosBase>(x => x.Where(e => e.HasValue(c.Source.IdServico)))));
            
        }
    }

    public class ServicoInputType : InputObjectGraphType
	{
		public ServicoInputType()
		{
			// Defining the name of the object
			Name = "servicoInput";
			
            //Field<StringGraphType>("idServico");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoServicoId");
			Field<StringGraphType>("codServico");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<FloatGraphType>("preco");
			Field<StringGraphType>("moedaId");
			Field<StringGraphType>("prestadorServicoId");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<PrestadorServicoInputType>("prestadorServico");
			Field<TipoServicoInputType>("tipoServico");
			Field<ListGraphType<ServicoPlanoInputType>>("servicoPlano");
			Field<ListGraphType<ServicosAdicionaisInputType>>("servicosAdicionais");
			Field<ListGraphType<ServicosBaseInputType>>("servicosBase");
			
		}
	}
}