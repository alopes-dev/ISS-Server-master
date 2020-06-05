using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoModalidadeCaeType : ObjectGraphType<ClassificacaoModalidadeCae>
    {
        public ClassificacaoModalidadeCaeType()
        {
            // Defining the name of the object
            Name = "classificacaoModalidadeCae";

            Field(x => x.IdClassificacaoModalidadeCae, nullable: true);
            Field(x => x.SessaoId, nullable: true);
            Field(x => x.SubsessaoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodClassificacaoModalidadeCae, nullable: true);
            Field(x => x.Numero, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ClassificacaoIndustriaType>("sessao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoIndustria>(c.Source.SessaoId)));
            FieldAsync<ClassificacaoIndustriaType>("subsessao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoIndustria>(c.Source.SubsessaoId)));
            FieldAsync<ListGraphType<CaeType>>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoModalidadeCae)))));
            FieldAsync<ListGraphType<TipoClassificacaoModalidadeCaeType>>("tipoClassificacaoModalidadeCae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoClassificacaoModalidadeCae>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoModalidadeCae)))));
            
        }
    }

    public class ClassificacaoModalidadeCaeInputType : InputObjectGraphType
	{
		public ClassificacaoModalidadeCaeInputType()
		{
			// Defining the name of the object
			Name = "classificacaoModalidadeCaeInput";
			
            //Field<StringGraphType>("idClassificacaoModalidadeCae");
			Field<StringGraphType>("sessaoId");
			Field<StringGraphType>("subsessaoId");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codClassificacaoModalidadeCae");
			Field<StringGraphType>("numero");
			Field<EstadoInputType>("estado");
			Field<ClassificacaoIndustriaInputType>("sessao");
			Field<ClassificacaoIndustriaInputType>("subsessao");
			Field<ListGraphType<CaeInputType>>("cae");
			Field<ListGraphType<TipoClassificacaoModalidadeCaeInputType>>("tipoClassificacaoModalidadeCae");
			
		}
	}
}