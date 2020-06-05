using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoEntidadeType : ObjectGraphType<TipoEntidade>
    {
        public TipoEntidadeType()
        {
            // Defining the name of the object
            Name = "tipoEntidade";

            Field(x => x.IdTipoEntidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoEntidade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ClassificacaoEntidadeType>>("classificacaoEntidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoEntidade>(x => x.Where(e => e.HasValue(c.Source.IdTipoEntidade)))));
            FieldAsync<ListGraphType<SectorAtividadeEconomicaType>>("sectorAtividadeEconomica", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SectorAtividadeEconomica>(x => x.Where(e => e.HasValue(c.Source.IdTipoEntidade)))));
            FieldAsync<ListGraphType<TipoEntidadePlanoType>>("tipoEntidadePlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEntidadePlano>(x => x.Where(e => e.HasValue(c.Source.IdTipoEntidade)))));
            FieldAsync<ListGraphType<TipoSociedadeType>>("tipoSociedade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSociedade>(x => x.Where(e => e.HasValue(c.Source.IdTipoEntidade)))));
            
        }
    }

    public class TipoEntidadeInputType : InputObjectGraphType
	{
		public TipoEntidadeInputType()
		{
			// Defining the name of the object
			Name = "tipoEntidadeInput";
			
            //Field<StringGraphType>("idTipoEntidade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoEntidade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ClassificacaoEntidadeInputType>>("classificacaoEntidade");
			Field<ListGraphType<SectorAtividadeEconomicaInputType>>("sectorAtividadeEconomica");
			Field<ListGraphType<TipoEntidadePlanoInputType>>("tipoEntidadePlano");
			Field<ListGraphType<TipoSociedadeInputType>>("tipoSociedade");
			
		}
	}
}