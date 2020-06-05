using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ChefeSectorType : ObjectGraphType<ChefeSector>
    {
        public ChefeSectorType()
        {
            // Defining the name of the object
            Name = "chefeSector";

            Field(x => x.IdChefeDepartamento, nullable: true);
            Field(x => x.SectorId, nullable: true);
            Field(x => x.ChefeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<FuncionarioType>("chefe", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.ChefeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SectorType>("sector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sector>(c.Source.SectorId)));
            
        }
    }

    public class ChefeSectorInputType : InputObjectGraphType
	{
		public ChefeSectorInputType()
		{
			// Defining the name of the object
			Name = "chefeSectorInput";
			
            //Field<StringGraphType>("idChefeDepartamento");
			Field<StringGraphType>("sectorId");
			Field<StringGraphType>("chefeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<FuncionarioInputType>("chefe");
			Field<EstadoInputType>("estado");
			Field<SectorInputType>("sector");
			
		}
	}
}