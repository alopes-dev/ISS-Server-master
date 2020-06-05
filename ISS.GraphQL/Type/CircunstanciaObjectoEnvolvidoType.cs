using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CircunstanciaObjectoEnvolvidoType : ObjectGraphType<CircunstanciaObjectoEnvolvido>
    {
        public CircunstanciaObjectoEnvolvidoType()
        {
            // Defining the name of the object
            Name = "circunstanciaObjectoEnvolvido";

            Field(x => x.IdCircunstanciaObjectoEnvolvido, nullable: true);
            Field(x => x.CircunstanciaVeiculoId, nullable: true);
            Field(x => x.ObjectoEnvolvidoId, nullable: true);
            Field(x => x.CodCircunstanciaObjectoEnvolvido, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CircunstanciaAutomovelType>("circunstanciaVeiculo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CircunstanciaAutomovel>(c.Source.CircunstanciaVeiculoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ObjectoEnvolvidoType>("objectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoEnvolvido>(c.Source.ObjectoEnvolvidoId)));
            
        }
    }

    public class CircunstanciaObjectoEnvolvidoInputType : InputObjectGraphType
	{
		public CircunstanciaObjectoEnvolvidoInputType()
		{
			// Defining the name of the object
			Name = "circunstanciaObjectoEnvolvidoInput";
			
            //Field<StringGraphType>("idCircunstanciaObjectoEnvolvido");
			Field<StringGraphType>("circunstanciaVeiculoId");
			Field<StringGraphType>("objectoEnvolvidoId");
			Field<StringGraphType>("codCircunstanciaObjectoEnvolvido");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CircunstanciaAutomovelInputType>("circunstanciaVeiculo");
			Field<EstadoInputType>("estado");
			Field<ObjectoEnvolvidoInputType>("objectoEnvolvido");
			
		}
	}
}