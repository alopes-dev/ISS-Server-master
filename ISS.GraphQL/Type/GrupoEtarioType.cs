using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GrupoEtarioType : ObjectGraphType<GrupoEtario>
    {
        public GrupoEtarioType()
        {
            // Defining the name of the object
            Name = "grupoEtario";

            Field(x => x.IdGrupoEtario, nullable: true);
            Field(x => x.IdadeMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.IdadeMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ModalidadeSeguroId, nullable: true);
            Field(x => x.FormaContratacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodGrupoEtario, nullable: true);
            FieldAsync<FormaContratacaoType>("formaContratacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaContratacao>(c.Source.FormaContratacaoId)));
            FieldAsync<ModalidadeSeguroType>("modalidadeSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadeSeguro>(c.Source.ModalidadeSeguroId)));
            
        }
    }

    public class GrupoEtarioInputType : InputObjectGraphType
	{
		public GrupoEtarioInputType()
		{
			// Defining the name of the object
			Name = "grupoEtarioInput";
			
            //Field<StringGraphType>("idGrupoEtario");
			Field<FloatGraphType>("idadeMin");
			Field<FloatGraphType>("idadeMax");
			Field<StringGraphType>("modalidadeSeguroId");
			Field<StringGraphType>("formaContratacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codGrupoEtario");
			Field<FormaContratacaoInputType>("formaContratacao");
			Field<ModalidadeSeguroInputType>("modalidadeSeguro");
			
		}
	}
}