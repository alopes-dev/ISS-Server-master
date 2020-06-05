using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoIndustriaType : ObjectGraphType<ClassificacaoIndustria>
    {
        public ClassificacaoIndustriaType()
        {
            // Defining the name of the object
            Name = "classificacaoIndustria";

            Field(x => x.IdClassificacaoIndustria, nullable: true);
            Field(x => x.Seccao, nullable: true);
            Field(x => x.DescricaoIndustria, nullable: true);
            Field(x => x.SeccaoPai, nullable: true);
            Field(x => x.CodClassificacaoIndustria, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ClassificacaoIndustriaType>("seccaoPaiNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoIndustria>(c.Source.SeccaoPai)));
            FieldAsync<ListGraphType<ClassificacaoModalidadeCaeType>>("classificacaoModalidadeCaeSessao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoModalidadeCae>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoIndustria)))));
            FieldAsync<ListGraphType<ClassificacaoModalidadeCaeType>>("classificacaoModalidadeCaeSubsessao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoModalidadeCae>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoIndustria)))));
            FieldAsync<ListGraphType<ClassificacaoIndustriaType>>("inverseSeccaoPaiNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoIndustria>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoIndustria)))));
            
        }
    }

    public class ClassificacaoIndustriaInputType : InputObjectGraphType
	{
		public ClassificacaoIndustriaInputType()
		{
			// Defining the name of the object
			Name = "classificacaoIndustriaInput";
			
            //Field<StringGraphType>("idClassificacaoIndustria");
			Field<StringGraphType>("seccao");
			Field<StringGraphType>("descricaoIndustria");
			Field<StringGraphType>("seccaoPai");
			Field<StringGraphType>("codClassificacaoIndustria");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ClassificacaoIndustriaInputType>("seccaoPaiNavigation");
			Field<ListGraphType<ClassificacaoModalidadeCaeInputType>>("classificacaoModalidadeCaeSessao");
			Field<ListGraphType<ClassificacaoModalidadeCaeInputType>>("classificacaoModalidadeCaeSubsessao");
			Field<ListGraphType<ClassificacaoIndustriaInputType>>("inverseSeccaoPaiNavigation");
			
		}
	}
}