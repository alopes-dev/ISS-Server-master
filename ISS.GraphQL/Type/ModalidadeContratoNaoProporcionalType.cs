using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModalidadeContratoNaoProporcionalType : ObjectGraphType<ModalidadeContratoNaoProporcional>
    {
        public ModalidadeContratoNaoProporcionalType()
        {
            // Defining the name of the object
            Name = "modalidadeContratoNaoProporcional";

            Field(x => x.IdModalidadeContratoNaoProporcional, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodModalidadeContratoNaoProporcional, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.FormaResseguroId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaResseguroType>("formaResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaResseguro>(c.Source.FormaResseguroId)));
            
        }
    }

    public class ModalidadeContratoNaoProporcionalInputType : InputObjectGraphType
	{
		public ModalidadeContratoNaoProporcionalInputType()
		{
			// Defining the name of the object
			Name = "modalidadeContratoNaoProporcionalInput";
			
            //Field<StringGraphType>("idModalidadeContratoNaoProporcional");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codModalidadeContratoNaoProporcional");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("formaResseguroId");
			Field<EstadoInputType>("estado");
			Field<FormaResseguroInputType>("formaResseguro");
			
		}
	}
}