using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MoradaType : ObjectGraphType<Morada>
    {
        public MoradaType()
        {
            // Defining the name of the object
            Name = "morada";

            Field(x => x.IdMorada, nullable: true);
            Field(x => x.CodMorada, nullable: true);
            Field(x => x.NumCasa, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CaixaPostal, nullable: true);
            Field(x => x.NumAndar, nullable: true);
            Field(x => x.Latitude, nullable: true, type: typeof(IntGraphType));
            Field(x => x.PontoReferencia, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class MoradaInputType : InputObjectGraphType
	{
		public MoradaInputType()
		{
			// Defining the name of the object
			Name = "moradaInput";
			
            //Field<StringGraphType>("idMorada");
			Field<StringGraphType>("codMorada");
			Field<IntGraphType>("numCasa");
			Field<StringGraphType>("caixaPostal");
			Field<StringGraphType>("numAndar");
			Field<IntGraphType>("latitude");
			Field<StringGraphType>("pontoReferencia");
			Field<StringGraphType>("enderecoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			
		}
	}
}