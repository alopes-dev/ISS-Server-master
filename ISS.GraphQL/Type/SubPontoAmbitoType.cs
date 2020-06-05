using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubPontoAmbitoType : ObjectGraphType<SubPontoAmbito>
    {
        public SubPontoAmbitoType()
        {
            // Defining the name of the object
            Name = "subPontoAmbito";

            Field(x => x.IdSubPontoAmbito, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NumOrdem, nullable: true);
            Field(x => x.CodSubPontoAmbito, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.AmbitoId, nullable: true);
            FieldAsync<AmbitoType>("ambito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Ambito>(c.Source.AmbitoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class SubPontoAmbitoInputType : InputObjectGraphType
	{
		public SubPontoAmbitoInputType()
		{
			// Defining the name of the object
			Name = "subPontoAmbitoInput";
			
            //Field<StringGraphType>("idSubPontoAmbito");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("numOrdem");
			Field<StringGraphType>("codSubPontoAmbito");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ambitoId");
			Field<AmbitoInputType>("ambito");
			Field<EstadoInputType>("estado");
			
		}
	}
}