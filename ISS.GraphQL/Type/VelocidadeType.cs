using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class VelocidadeType : ObjectGraphType<Velocidade>
    {
        public VelocidadeType()
        {
            // Defining the name of the object
            Name = "velocidade";

            Field(x => x.IdVelocidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodVelocidade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<AutomovelType>>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(x => x.Where(e => e.HasValue(c.Source.IdVelocidade)))));
            
        }
    }

    public class VelocidadeInputType : InputObjectGraphType
	{
		public VelocidadeInputType()
		{
			// Defining the name of the object
			Name = "velocidadeInput";
			
            //Field<StringGraphType>("idVelocidade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codVelocidade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<AutomovelInputType>>("automovel");
			
		}
	}
}