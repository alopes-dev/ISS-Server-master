using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ObjectoSeguradoType : ObjectGraphType<ObjectoSegurado>
    {
        public ObjectoSeguradoType()
        {
            // Defining the name of the object
            Name = "objectoSegurado";

            Field(x => x.IdObjectoSegurado, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.ClassificacaoId, nullable: true);
            Field(x => x.AutomovelId, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            FieldAsync<ClassificacaoType>("classificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Classificacao>(c.Source.ClassificacaoId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CaracteristicaObjectoType>>("caracteristicaObjecto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicaObjecto>(x => x.Where(e => e.HasValue(c.Source.IdObjectoSegurado)))));
            FieldAsync<ListGraphType<CoberturaSelecionadaType>>("coberturaSelecionada", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaSelecionada>(x => x.Where(e => e.HasValue(c.Source.IdObjectoSegurado)))));
            
        }
    }

    public class ObjectoSeguradoInputType : InputObjectGraphType
	{
		public ObjectoSeguradoInputType()
		{
			// Defining the name of the object
			Name = "objectoSeguradoInput";
			
            //Field<StringGraphType>("idObjectoSegurado");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("cotacaoId");
			Field<StringGraphType>("classificacaoId");
			Field<StringGraphType>("automovelId");
			Field<AutomovelInputType>("automovel");
			Field<ClassificacaoInputType>("classificacao");
			Field<CotacaoInputType>("cotacao");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CaracteristicaObjectoInputType>>("caracteristicaObjecto");
			Field<ListGraphType<CoberturaSelecionadaInputType>>("coberturaSelecionada");
			
		}
	}
}