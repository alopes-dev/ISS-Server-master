using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DestaquesPaginaType : ObjectGraphType<DestaquesPagina>
    {
        public DestaquesPaginaType()
        {
            // Defining the name of the object
            Name = "destaquesPagina";

            Field(x => x.IdDestaquesPagina, nullable: true);
            Field(x => x.Titulo, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.InformacaoBase, nullable: true);
            Field(x => x.CorTituloId, nullable: true);
            Field(x => x.CorInformacaoBaseId, nullable: true);
            Field(x => x.CaminhoWeb, nullable: true);
            Field(x => x.CaminhoImagem, nullable: true);
            FieldAsync<CorType>("corInformacaoBase", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cor>(c.Source.CorInformacaoBaseId)));
            FieldAsync<CorType>("corTitulo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cor>(c.Source.CorTituloId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class DestaquesPaginaInputType : InputObjectGraphType
	{
		public DestaquesPaginaInputType()
		{
			// Defining the name of the object
			Name = "destaquesPaginaInput";
			
            //Field<StringGraphType>("idDestaquesPagina");
			Field<StringGraphType>("titulo");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("informacaoBase");
			Field<StringGraphType>("corTituloId");
			Field<StringGraphType>("corInformacaoBaseId");
			Field<StringGraphType>("caminhoWeb");
			Field<StringGraphType>("caminhoImagem");
			Field<CorInputType>("corInformacaoBase");
			Field<CorInputType>("corTitulo");
			Field<EstadoInputType>("estado");
			
		}
	}
}