using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CorType : ObjectGraphType<Cor>
    {
        public CorType()
        {
            // Defining the name of the object
            Name = "cor";

            Field(x => x.IdCor, nullable: true);
            Field(x => x.Nome, nullable: true);
            Field(x => x.TripletoHex, nullable: true);
            Field(x => x.R, nullable: true, type: typeof(IntGraphType));
            Field(x => x.G, nullable: true, type: typeof(IntGraphType));
            Field(x => x.B, nullable: true, type: typeof(IntGraphType));
            Field(x => x.H, nullable: true);
            Field(x => x.S, nullable: true);
            Field(x => x.V, nullable: true);
            Field(x => x.NomeWeb, nullable: true);
            Field(x => x.CodCor, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdCor)))));
            FieldAsync<ListGraphType<CategoriaTarefaType>>("categoriaTarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaTarefa>(x => x.Where(e => e.HasValue(c.Source.IdCor)))));
            FieldAsync<ListGraphType<DestaquesPaginaType>>("destaquesPaginaCorInformacaoBase", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DestaquesPagina>(x => x.Where(e => e.HasValue(c.Source.IdCor)))));
            FieldAsync<ListGraphType<DestaquesPaginaType>>("destaquesPaginaCorTitulo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DestaquesPagina>(x => x.Where(e => e.HasValue(c.Source.IdCor)))));
            FieldAsync<ListGraphType<TipoRedeSociaisType>>("tipoRedeSociais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRedeSociais>(x => x.Where(e => e.HasValue(c.Source.IdCor)))));
            
        }
    }

    public class CorInputType : InputObjectGraphType
	{
		public CorInputType()
		{
			// Defining the name of the object
			Name = "corInput";
			
            //Field<StringGraphType>("idCor");
			Field<StringGraphType>("nome");
			Field<StringGraphType>("tripletoHex");
			Field<IntGraphType>("r");
			Field<IntGraphType>("g");
			Field<IntGraphType>("b");
			Field<StringGraphType>("h");
			Field<StringGraphType>("s");
			Field<StringGraphType>("v");
			Field<StringGraphType>("nomeWeb");
			Field<StringGraphType>("codCor");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			Field<ListGraphType<CategoriaTarefaInputType>>("categoriaTarefa");
			Field<ListGraphType<DestaquesPaginaInputType>>("destaquesPaginaCorInformacaoBase");
			Field<ListGraphType<DestaquesPaginaInputType>>("destaquesPaginaCorTitulo");
			Field<ListGraphType<TipoRedeSociaisInputType>>("tipoRedeSociais");
			
		}
	}
}