using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SegmentoTipoCoberturaType : ObjectGraphType<SegmentoTipoCobertura>
    {
        public SegmentoTipoCoberturaType()
        {
            // Defining the name of the object
            Name = "segmentoTipoCobertura";

            Field(x => x.IdSegmentoTipoCobertura, nullable: true);
            Field(x => x.IdadeMin, nullable: true, type: typeof(IntGraphType));
            Field(x => x.IdadeMax, nullable: true, type: typeof(IntGraphType));
            Field(x => x.SexoId, nullable: true);
            Field(x => x.FidelizacaoId, nullable: true);
            Field(x => x.Caeid, nullable: true);
            Field(x => x.TipoSegmentoId, nullable: true);
            Field(x => x.TipoCoberturaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.Caeid)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FidelizacaoType>("fidelizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Fidelizacao>(c.Source.FidelizacaoId)));
            FieldAsync<SexoType>("sexo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sexo>(c.Source.SexoId)));
            FieldAsync<TipoCoberturaType>("tipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoCobertura>(c.Source.TipoCoberturaId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            
        }
    }

    public class SegmentoTipoCoberturaInputType : InputObjectGraphType
	{
		public SegmentoTipoCoberturaInputType()
		{
			// Defining the name of the object
			Name = "segmentoTipoCoberturaInput";
			
            //Field<StringGraphType>("idSegmentoTipoCobertura");
			Field<IntGraphType>("idadeMin");
			Field<IntGraphType>("idadeMax");
			Field<StringGraphType>("sexoId");
			Field<StringGraphType>("fidelizacaoId");
			Field<StringGraphType>("caeid");
			Field<StringGraphType>("tipoSegmentoId");
			Field<StringGraphType>("tipoCoberturaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CaeInputType>("cae");
			Field<EstadoInputType>("estado");
			Field<FidelizacaoInputType>("fidelizacao");
			Field<SexoInputType>("sexo");
			Field<TipoCoberturaInputType>("tipoCobertura");
			Field<TipoSegmentoInputType>("tipoSegmento");
			
		}
	}
}