using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AtosMedicosType : ObjectGraphType<AtosMedicos>
    {
        public AtosMedicosType()
        {
            // Defining the name of the object
            Name = "atosMedicos";

            Field(x => x.IdAtosMedicos, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodAtosMedicos, nullable: true);
            Field(x => x.TipoConsultaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Valor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Moeda, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moedaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.Moeda)));
            FieldAsync<TipoConsultaType>("tipoConsulta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoConsulta>(c.Source.TipoConsultaId)));
            FieldAsync<ListGraphType<DescricaoTratamentoDentarioType>>("descricaoTratamentoDentario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DescricaoTratamentoDentario>(x => x.Where(e => e.HasValue(c.Source.IdAtosMedicos)))));
            FieldAsync<ListGraphType<PrecosAtosMedicosType>>("precosAtosMedicos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecosAtosMedicos>(x => x.Where(e => e.HasValue(c.Source.IdAtosMedicos)))));
            FieldAsync<ListGraphType<TermoResponsabilidadeType>>("termoResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TermoResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdAtosMedicos)))));
            
        }
    }

    public class AtosMedicosInputType : InputObjectGraphType
	{
		public AtosMedicosInputType()
		{
			// Defining the name of the object
			Name = "atosMedicosInput";
			
            //Field<StringGraphType>("idAtosMedicos");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codAtosMedicos");
			Field<StringGraphType>("tipoConsultaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("valor");
			Field<StringGraphType>("moeda");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moedaNavigation");
			Field<TipoConsultaInputType>("tipoConsulta");
			Field<ListGraphType<DescricaoTratamentoDentarioInputType>>("descricaoTratamentoDentario");
			Field<ListGraphType<PrecosAtosMedicosInputType>>("precosAtosMedicos");
			Field<ListGraphType<TermoResponsabilidadeInputType>>("termoResponsabilidade");
			
		}
	}
}