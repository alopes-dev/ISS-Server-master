using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FormaResseguroType : ObjectGraphType<FormaResseguro>
    {
        public FormaResseguroType()
        {
            // Defining the name of the object
            Name = "formaResseguro";

            Field(x => x.IdFormaResseguro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodFormaResseguro, nullable: true);
            Field(x => x.TipoResseguroId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoResseguroType>("tipoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoResseguro>(c.Source.TipoResseguroId)));
            FieldAsync<ListGraphType<ModalidadeContratoNaoProporcionalType>>("modalidadeContratoNaoProporcional", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadeContratoNaoProporcional>(x => x.Where(e => e.HasValue(c.Source.IdFormaResseguro)))));
            FieldAsync<ListGraphType<ModalidadeContratoProporcionalType>>("modalidadeContratoProporcional", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadeContratoProporcional>(x => x.Where(e => e.HasValue(c.Source.IdFormaResseguro)))));
            FieldAsync<ListGraphType<SubFormaResseguroType>>("subFormaResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubFormaResseguro>(x => x.Where(e => e.HasValue(c.Source.IdFormaResseguro)))));
            
        }
    }

    public class FormaResseguroInputType : InputObjectGraphType
	{
		public FormaResseguroInputType()
		{
			// Defining the name of the object
			Name = "formaResseguroInput";
			
            //Field<StringGraphType>("idFormaResseguro");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codFormaResseguro");
			Field<StringGraphType>("tipoResseguroId");
			Field<EstadoInputType>("estado");
			Field<TipoResseguroInputType>("tipoResseguro");
			Field<ListGraphType<ModalidadeContratoNaoProporcionalInputType>>("modalidadeContratoNaoProporcional");
			Field<ListGraphType<ModalidadeContratoProporcionalInputType>>("modalidadeContratoProporcional");
			Field<ListGraphType<SubFormaResseguroInputType>>("subFormaResseguro");
			
		}
	}
}