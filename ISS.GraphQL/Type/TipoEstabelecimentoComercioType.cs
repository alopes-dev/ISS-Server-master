using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoEstabelecimentoComercioType : ObjectGraphType<TipoEstabelecimentoComercio>
    {
        public TipoEstabelecimentoComercioType()
        {
            // Defining the name of the object
            Name = "tipoEstabelecimentoComercio";

            Field(x => x.IdTipoEstabelecimentoComercio, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.ModalidadeResponsabilidadeCivilId, nullable: true);
            Field(x => x.CodTipoEstabelecimentoComercio, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ModalidadesResponsabilidadeCivilType>("modalidadeResponsabilidadeCivil", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesResponsabilidadeCivil>(c.Source.ModalidadeResponsabilidadeCivilId)));
            FieldAsync<ListGraphType<ModalidadesRcselecionadasType>>("modalidadesRcselecionadas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModalidadesRcselecionadas>(x => x.Where(e => e.HasValue(c.Source.IdTipoEstabelecimentoComercio)))));
            
        }
    }

    public class TipoEstabelecimentoComercioInputType : InputObjectGraphType
	{
		public TipoEstabelecimentoComercioInputType()
		{
			// Defining the name of the object
			Name = "tipoEstabelecimentoComercioInput";
			
            //Field<StringGraphType>("idTipoEstabelecimentoComercio");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("modalidadeResponsabilidadeCivilId");
			Field<StringGraphType>("codTipoEstabelecimentoComercio");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ModalidadesResponsabilidadeCivilInputType>("modalidadeResponsabilidadeCivil");
			Field<ListGraphType<ModalidadesRcselecionadasInputType>>("modalidadesRcselecionadas");
			
		}
	}
}