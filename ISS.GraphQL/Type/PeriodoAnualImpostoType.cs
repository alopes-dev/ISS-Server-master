using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PeriodoAnualImpostoType : ObjectGraphType<PeriodoAnualImposto>
    {
        public PeriodoAnualImpostoType()
        {
            // Defining the name of the object
            Name = "periodoAnualImposto";

            Field(x => x.IdPeriodoAnualImposto, nullable: true);
            Field(x => x.MesId, nullable: true);
            Field(x => x.TipoImpostoId, nullable: true);
            Field(x => x.CodPeriodoAnualImposto, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.GrupoImpostoId, nullable: true);
            Field(x => x.SessaoImpostoId, nullable: true);
            Field(x => x.Obs, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<GrupoImpostoType>("grupoImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GrupoImposto>(c.Source.GrupoImpostoId)));
            FieldAsync<MesesType>("mes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Meses>(c.Source.MesId)));
            FieldAsync<SessaoImpostoType>("sessaoImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SessaoImposto>(c.Source.SessaoImpostoId)));
            FieldAsync<TipoImpostoType>("tipoImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoImposto>(c.Source.TipoImpostoId)));
            
        }
    }

    public class PeriodoAnualImpostoInputType : InputObjectGraphType
	{
		public PeriodoAnualImpostoInputType()
		{
			// Defining the name of the object
			Name = "periodoAnualImpostoInput";
			
            //Field<StringGraphType>("idPeriodoAnualImposto");
			Field<StringGraphType>("mesId");
			Field<StringGraphType>("tipoImpostoId");
			Field<StringGraphType>("codPeriodoAnualImposto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("descricao");
			Field<StringGraphType>("grupoImpostoId");
			Field<StringGraphType>("sessaoImpostoId");
			Field<StringGraphType>("obs");
			Field<EstadoInputType>("estado");
			Field<GrupoImpostoInputType>("grupoImposto");
			Field<MesesInputType>("mes");
			Field<SessaoImpostoInputType>("sessaoImposto");
			Field<TipoImpostoInputType>("tipoImposto");
			
		}
	}
}