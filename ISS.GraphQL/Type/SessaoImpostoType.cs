using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SessaoImpostoType : ObjectGraphType<SessaoImposto>
    {
        public SessaoImpostoType()
        {
            // Defining the name of the object
            Name = "sessaoImposto";

            Field(x => x.IdSessaoImposto, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PeriodoAnualImpostoType>>("periodoAnualImposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PeriodoAnualImposto>(x => x.Where(e => e.HasValue(c.Source.IdSessaoImposto)))));
            
        }
    }

    public class SessaoImpostoInputType : InputObjectGraphType
	{
		public SessaoImpostoInputType()
		{
			// Defining the name of the object
			Name = "sessaoImpostoInput";
			
            //Field<StringGraphType>("idSessaoImposto");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PeriodoAnualImpostoInputType>>("periodoAnualImposto");
			
		}
	}
}