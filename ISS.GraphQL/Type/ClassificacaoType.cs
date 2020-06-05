using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoType : ObjectGraphType<Classificacao>
    {
        public ClassificacaoType()
        {
            // Defining the name of the object
            Name = "classificacao";

            Field(x => x.IdClassificacao, nullable: true);
            Field(x => x.Classificacao1, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodClassificacao, nullable: true);
            Field(x => x.TipoClassificaocao, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ClassificacaoType>("tipoClassificaocaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Classificacao>(c.Source.TipoClassificaocao)));
            FieldAsync<ListGraphType<CaracteristicaClassificacaoType>>("caracteristicaClassificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicaClassificacao>(x => x.Where(e => e.HasValue(c.Source.IdClassificacao)))));
            FieldAsync<ListGraphType<ComponenteClassificacaoType>>("componenteClassificacaoClassificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComponenteClassificacao>(x => x.Where(e => e.HasValue(c.Source.IdClassificacao)))));
            FieldAsync<ListGraphType<ComponenteClassificacaoType>>("componenteClassificacaoComponente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComponenteClassificacao>(x => x.Where(e => e.HasValue(c.Source.IdClassificacao)))));
            FieldAsync<ListGraphType<ClassificacaoType>>("inverseTipoClassificaocaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Classificacao>(x => x.Where(e => e.HasValue(c.Source.IdClassificacao)))));
            FieldAsync<ListGraphType<ObjectoSeguradoType>>("objectoSegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoSegurado>(x => x.Where(e => e.HasValue(c.Source.IdClassificacao)))));
            
        }
    }

    public class ClassificacaoInputType : InputObjectGraphType
	{
		public ClassificacaoInputType()
		{
			// Defining the name of the object
			Name = "classificacaoInput";
			
            //Field<StringGraphType>("idClassificacao");
			Field<StringGraphType>("classificacao1");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codClassificacao");
			Field<StringGraphType>("tipoClassificaocao");
			Field<EstadoInputType>("estado");
			Field<ClassificacaoInputType>("tipoClassificaocaoNavigation");
			Field<ListGraphType<CaracteristicaClassificacaoInputType>>("caracteristicaClassificacao");
			Field<ListGraphType<ComponenteClassificacaoInputType>>("componenteClassificacaoClassificacao");
			Field<ListGraphType<ComponenteClassificacaoInputType>>("componenteClassificacaoComponente");
			Field<ListGraphType<ClassificacaoInputType>>("inverseTipoClassificaocaoNavigation");
			Field<ListGraphType<ObjectoSeguradoInputType>>("objectoSegurado");
			
		}
	}
}