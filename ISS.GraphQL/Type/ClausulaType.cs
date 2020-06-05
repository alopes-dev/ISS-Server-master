using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClausulaType : ObjectGraphType<Clausula>
    {
        public ClausulaType()
        {
            // Defining the name of the object
            Name = "clausula";

            Field(x => x.IdClausula, nullable: true);
            Field(x => x.NumClausula, nullable: true);
            Field(x => x.Titulo, nullable: true);
            Field(x => x.Obs, nullable: true);
            Field(x => x.RegiaoId, nullable: true);
            Field(x => x.CodClausula, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.ArtigoId, nullable: true);
            Field(x => x.CapituloId, nullable: true);
            FieldAsync<ArtigoType>("artigo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Artigo>(c.Source.ArtigoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<RegiaoType>("regiao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Regiao>(c.Source.RegiaoId)));
            FieldAsync<ListGraphType<ContratoClausulaType>>("contratoClausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoClausula>(x => x.Where(e => e.HasValue(c.Source.IdClausula)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdClausula)))));
            FieldAsync<ListGraphType<PontosClausulaType>>("pontosClausula", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PontosClausula>(x => x.Where(e => e.HasValue(c.Source.IdClausula)))));
            
        }
    }

    public class ClausulaInputType : InputObjectGraphType
	{
		public ClausulaInputType()
		{
			// Defining the name of the object
			Name = "clausulaInput";
			
            //Field<StringGraphType>("idClausula");
			Field<StringGraphType>("numClausula");
			Field<StringGraphType>("titulo");
			Field<StringGraphType>("obs");
			Field<StringGraphType>("regiaoId");
			Field<StringGraphType>("codClausula");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("artigoId");
			Field<StringGraphType>("capituloId");
			Field<ArtigoInputType>("artigo");
			Field<EstadoInputType>("estado");
			Field<RegiaoInputType>("regiao");
			Field<ListGraphType<ContratoClausulaInputType>>("contratoClausula");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			Field<ListGraphType<PontosClausulaInputType>>("pontosClausula");
			
		}
	}
}