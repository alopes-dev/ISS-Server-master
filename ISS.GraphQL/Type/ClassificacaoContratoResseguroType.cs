using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoContratoResseguroType : ObjectGraphType<ClassificacaoContratoResseguro>
    {
        public ClassificacaoContratoResseguroType()
        {
            // Defining the name of the object
            Name = "classificacaoContratoResseguro";

            Field(x => x.IdClassificacaoContratoResseguro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoContratoId, nullable: true);
            Field(x => x.TipoResseguroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoContratoType>("tipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContrato>(c.Source.TipoContratoId)));
            FieldAsync<TipoResseguroType>("tipoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoResseguro>(c.Source.TipoResseguroId)));
            FieldAsync<ListGraphType<SubClassificacaoContratoResseguroType>>("subClassificacaoContratoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubClassificacaoContratoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoContratoResseguro)))));
            
        }
    }

    public class ClassificacaoContratoResseguroInputType : InputObjectGraphType
	{
		public ClassificacaoContratoResseguroInputType()
		{
			// Defining the name of the object
			Name = "classificacaoContratoResseguroInput";
			
            //Field<StringGraphType>("idClassificacaoContratoResseguro");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoContratoId");
			Field<StringGraphType>("tipoResseguroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TipoContratoInputType>("tipoContrato");
			Field<TipoResseguroInputType>("tipoResseguro");
			Field<ListGraphType<SubClassificacaoContratoResseguroInputType>>("subClassificacaoContratoResseguro");
			
		}
	}
}