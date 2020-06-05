using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LocaisComissaoType : ObjectGraphType<LocaisComissao>
    {
        public LocaisComissaoType()
        {
            // Defining the name of the object
            Name = "locaisComissao";

            Field(x => x.IdLocaisComissao, nullable: true);
            Field(x => x.NivelAbrangenciaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.LocalComissao, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<EnderecoType>("localComissaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.LocalComissao)));
            FieldAsync<NivelAbrangenciaType>("nivelAbrangencia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<NivelAbrangencia>(c.Source.NivelAbrangenciaId)));
            
        }
    }

    public class LocaisComissaoInputType : InputObjectGraphType
	{
		public LocaisComissaoInputType()
		{
			// Defining the name of the object
			Name = "locaisComissaoInput";
			
            //Field<StringGraphType>("idLocaisComissao");
			Field<StringGraphType>("nivelAbrangenciaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("localComissao");
			Field<EstadoInputType>("estado");
			Field<EnderecoInputType>("localComissaoNavigation");
			Field<NivelAbrangenciaInputType>("nivelAbrangencia");
			
		}
	}
}