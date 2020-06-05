using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SexoType : ObjectGraphType<Sexo>
    {
        public SexoType()
        {
            // Defining the name of the object
            Name = "sexo";

            Field(x => x.IdSexo, nullable: true);
            Field(x => x.Genero, nullable: true);
            Field(x => x.CodSexo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<GeneroPlanoType>>("generoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GeneroPlano>(x => x.Where(e => e.HasValue(c.Source.IdSexo)))));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdSexo)))));
            FieldAsync<ListGraphType<SegmentoProdutoType>>("segmentoProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoProduto>(x => x.Where(e => e.HasValue(c.Source.IdSexo)))));
            FieldAsync<ListGraphType<SegmentoTipoCoberturaType>>("segmentoTipoCobertura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SegmentoTipoCobertura>(x => x.Where(e => e.HasValue(c.Source.IdSexo)))));
            FieldAsync<ListGraphType<SexoPlanoType>>("sexoPlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SexoPlano>(x => x.Where(e => e.HasValue(c.Source.IdSexo)))));
            
        }
    }

    public class SexoInputType : InputObjectGraphType
	{
		public SexoInputType()
		{
			// Defining the name of the object
			Name = "sexoInput";
			
            //Field<StringGraphType>("idSexo");
			Field<StringGraphType>("genero");
			Field<StringGraphType>("codSexo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<GeneroPlanoInputType>>("generoPlano");
			Field<ListGraphType<PessoaInputType>>("pessoa");
			Field<ListGraphType<SegmentoProdutoInputType>>("segmentoProduto");
			Field<ListGraphType<SegmentoTipoCoberturaInputType>>("segmentoTipoCobertura");
			Field<ListGraphType<SexoPlanoInputType>>("sexoPlano");
			
		}
	}
}