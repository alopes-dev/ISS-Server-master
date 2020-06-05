using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ChefeDepartamentoType : ObjectGraphType<ChefeDepartamento>
    {
        public ChefeDepartamentoType()
        {
            // Defining the name of the object
            Name = "chefeDepartamento";

            Field(x => x.IdChefeDepartamento, nullable: true);
            Field(x => x.DepartamentoId, nullable: true);
            Field(x => x.ChefeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<FuncionarioType>("chefe", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.ChefeId)));
            FieldAsync<DepartamentoType>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(c.Source.DepartamentoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class ChefeDepartamentoInputType : InputObjectGraphType
	{
		public ChefeDepartamentoInputType()
		{
			// Defining the name of the object
			Name = "chefeDepartamentoInput";
			
            //Field<StringGraphType>("idChefeDepartamento");
			Field<StringGraphType>("departamentoId");
			Field<StringGraphType>("chefeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FuncionarioInputType>("chefe");
			Field<DepartamentoInputType>("departamento");
			Field<EstadoInputType>("estado");
			
		}
	}
}