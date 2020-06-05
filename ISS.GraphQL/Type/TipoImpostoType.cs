using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoImpostoType : ObjectGraphType<TipoImposto>
    {
        public TipoImpostoType()
        {
            // Defining the name of the object
            Name = "tipoImposto";

            Field(x => x.IdTipoImposto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoImposto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ClassificacaoImpostoId, nullable: true);
            Field(x => x.TipoRamoSeguroId, nullable: true);
            FieldAsync<ClassificacaoImpostoType>("classificacaoImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ClassificacaoImposto>(c.Source.ClassificacaoImpostoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoRamoSeguroType>("tipoRamoSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRamoSeguro>(c.Source.TipoRamoSeguroId)));
            FieldAsync<ListGraphType<ImpostoType>>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(x => x.Where(e => e.HasValue(c.Source.IdTipoImposto)))));
            FieldAsync<ListGraphType<PeriodoAnualImpostoType>>("periodoAnualImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PeriodoAnualImposto>(x => x.Where(e => e.HasValue(c.Source.IdTipoImposto)))));
            
        }
    }

    public class TipoImpostoInputType : InputObjectGraphType
	{
		public TipoImpostoInputType()
		{
			// Defining the name of the object
			Name = "tipoImpostoInput";
			
            //Field<StringGraphType>("idTipoImposto");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoImposto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("classificacaoImpostoId");
			Field<StringGraphType>("tipoRamoSeguroId");
			Field<ClassificacaoImpostoInputType>("classificacaoImposto");
			Field<EstadoInputType>("estado");
			Field<TipoRamoSeguroInputType>("tipoRamoSeguro");
			Field<ListGraphType<ImpostoInputType>>("imposto");
			Field<ListGraphType<PeriodoAnualImpostoInputType>>("periodoAnualImposto");
			
		}
	}
}