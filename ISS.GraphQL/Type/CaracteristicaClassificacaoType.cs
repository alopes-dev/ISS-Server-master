using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CaracteristicaClassificacaoType : ObjectGraphType<CaracteristicaClassificacao>
    {
        public CaracteristicaClassificacaoType()
        {
            // Defining the name of the object
            Name = "caracteristicaClassificacao";

            Field(x => x.IdCaracteristicaClassificacao, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.ClassificacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.SuperCaracteristicaId, nullable: true);
            FieldAsync<ClassificacaoType>("classificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Classificacao>(c.Source.ClassificacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<CaracteristicaClassificacaoType>("superCaracteristica", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicaClassificacao>(c.Source.SuperCaracteristicaId)));
            FieldAsync<ListGraphType<CaracteristicaObjectoType>>("caracteristicaObjecto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicaObjecto>(x => x.Where(e => e.HasValue(c.Source.IdCaracteristicaClassificacao)))));
            FieldAsync<ListGraphType<CaracteristicaClassificacaoType>>("inverseSuperCaracteristica", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CaracteristicaClassificacao>(x => x.Where(e => e.HasValue(c.Source.IdCaracteristicaClassificacao)))));
            FieldAsync<ListGraphType<ValorPadraoType>>("valorPadrao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValorPadrao>(x => x.Where(e => e.HasValue(c.Source.IdCaracteristicaClassificacao)))));
            
        }
    }

    public class CaracteristicaClassificacaoInputType : InputObjectGraphType
	{
		public CaracteristicaClassificacaoInputType()
		{
			// Defining the name of the object
			Name = "caracteristicaClassificacaoInput";
			
            //Field<StringGraphType>("idCaracteristicaClassificacao");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("classificacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("superCaracteristicaId");
			Field<ClassificacaoInputType>("classificacao");
			Field<EstadoInputType>("estado");
			Field<CaracteristicaClassificacaoInputType>("superCaracteristica");
			Field<ListGraphType<CaracteristicaObjectoInputType>>("caracteristicaObjecto");
			Field<ListGraphType<CaracteristicaClassificacaoInputType>>("inverseSuperCaracteristica");
			Field<ListGraphType<ValorPadraoInputType>>("valorPadrao");
			
		}
	}
}