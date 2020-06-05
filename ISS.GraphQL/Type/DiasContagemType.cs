using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DiasContagemType : ObjectGraphType<DiasContagem>
    {
        public DiasContagemType()
        {
            // Defining the name of the object
            Name = "diasContagem";

            Field(x => x.IdDiasContagem, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.Segunda, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Terca, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Quarta, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Quinta, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Sexta, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Sabado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Domingo, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class DiasContagemInputType : InputObjectGraphType
	{
		public DiasContagemInputType()
		{
			// Defining the name of the object
			Name = "diasContagemInput";
			
            //Field<StringGraphType>("idDiasContagem");
			Field<StringGraphType>("apoliceId");
			Field<BooleanGraphType>("segunda");
			Field<BooleanGraphType>("terca");
			Field<BooleanGraphType>("quarta");
			Field<BooleanGraphType>("quinta");
			Field<BooleanGraphType>("sexta");
			Field<BooleanGraphType>("sabado");
			Field<BooleanGraphType>("domingo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			
		}
	}
}