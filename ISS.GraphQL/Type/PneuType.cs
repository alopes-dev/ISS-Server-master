using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PneuType : ObjectGraphType<Pneu>
    {
        public PneuType()
        {
            // Defining the name of the object
            Name = "pneu";

            Field(x => x.IdPneu, nullable: true);
            Field(x => x.TipoConstrucaoPneusId, nullable: true);
            Field(x => x.IndiceVelocidadePneuId, nullable: true);
            Field(x => x.IndiceCargaPneuId, nullable: true);
            Field(x => x.LocalizacaoPneuId, nullable: true);
            Field(x => x.AutomovelId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<IndiceCargaPneuType>("indiceCargaPneu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<IndiceCargaPneu>(c.Source.IndiceCargaPneuId)));
            FieldAsync<IndiceVelocidadePneuType>("indiceVelocidadePneu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<IndiceVelocidadePneu>(c.Source.IndiceVelocidadePneuId)));
            FieldAsync<LocalizacaoPneuType>("localizacaoPneu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalizacaoPneu>(c.Source.LocalizacaoPneuId)));
            FieldAsync<TipoConstrucaoPneusType>("tipoConstrucaoPneus", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConstrucaoPneus>(c.Source.TipoConstrucaoPneusId)));
            
        }
    }

    public class PneuInputType : InputObjectGraphType
	{
		public PneuInputType()
		{
			// Defining the name of the object
			Name = "pneuInput";
			
            //Field<StringGraphType>("idPneu");
			Field<StringGraphType>("tipoConstrucaoPneusId");
			Field<StringGraphType>("indiceVelocidadePneuId");
			Field<StringGraphType>("indiceCargaPneuId");
			Field<StringGraphType>("localizacaoPneuId");
			Field<StringGraphType>("automovelId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<AutomovelInputType>("automovel");
			Field<EstadoInputType>("estado");
			Field<IndiceCargaPneuInputType>("indiceCargaPneu");
			Field<IndiceVelocidadePneuInputType>("indiceVelocidadePneu");
			Field<LocalizacaoPneuInputType>("localizacaoPneu");
			Field<TipoConstrucaoPneusInputType>("tipoConstrucaoPneus");
			
		}
	}
}