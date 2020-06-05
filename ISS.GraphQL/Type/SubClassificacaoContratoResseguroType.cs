using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubClassificacaoContratoResseguroType : ObjectGraphType<SubClassificacaoContratoResseguro>
    {
        public SubClassificacaoContratoResseguroType()
        {
            // Defining the name of the object
            Name = "subClassificacaoContratoResseguro";

            Field(x => x.IdSubClassificacaoContratoResseguro, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodSubClassificacaoContratoResseguro, nullable: true);
            Field(x => x.ClassificacaoContratoResseguroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<ClassificacaoContratoResseguroType>("classificacaoContratoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoContratoResseguro>(c.Source.ClassificacaoContratoResseguroId)));
            
        }
    }

    public class SubClassificacaoContratoResseguroInputType : InputObjectGraphType
	{
		public SubClassificacaoContratoResseguroInputType()
		{
			// Defining the name of the object
			Name = "subClassificacaoContratoResseguroInput";
			
            //Field<StringGraphType>("idSubClassificacaoContratoResseguro");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codSubClassificacaoContratoResseguro");
			Field<StringGraphType>("classificacaoContratoResseguroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<ClassificacaoContratoResseguroInputType>("classificacaoContratoResseguro");
			
		}
	}
}