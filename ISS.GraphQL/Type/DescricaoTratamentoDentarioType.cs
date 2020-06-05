using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DescricaoTratamentoDentarioType : ObjectGraphType<DescricaoTratamentoDentario>
    {
        public DescricaoTratamentoDentarioType()
        {
            // Defining the name of the object
            Name = "descricaoTratamentoDentario";

            Field(x => x.IdDescricaoTratamentoDentario, nullable: true);
            Field(x => x.CodDescricaoTratamentoDentario, nullable: true);
            Field(x => x.DataTratamento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Dente, nullable: true);
            Field(x => x.Face, nullable: true);
            Field(x => x.AtosMedicosId, nullable: true);
            Field(x => x.Custo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<AtosMedicosType>("atosMedicos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AtosMedicos>(c.Source.AtosMedicosId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ReembolsoTratamentoDentarioType>>("reembolsoTratamentoDentario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReembolsoTratamentoDentario>(x => x.Where(e => e.HasValue(c.Source.IdDescricaoTratamentoDentario)))));
            
        }
    }

    public class DescricaoTratamentoDentarioInputType : InputObjectGraphType
	{
		public DescricaoTratamentoDentarioInputType()
		{
			// Defining the name of the object
			Name = "descricaoTratamentoDentarioInput";
			
            //Field<StringGraphType>("idDescricaoTratamentoDentario");
			Field<StringGraphType>("codDescricaoTratamentoDentario");
			Field<DateTimeGraphType>("dataTratamento");
			Field<StringGraphType>("dente");
			Field<StringGraphType>("face");
			Field<StringGraphType>("atosMedicosId");
			Field<FloatGraphType>("custo");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<AtosMedicosInputType>("atosMedicos");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ReembolsoTratamentoDentarioInputType>>("reembolsoTratamentoDentario");
			
		}
	}
}