using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ChefeSeccaoType : ObjectGraphType<ChefeSeccao>
    {
        public ChefeSeccaoType()
        {
            // Defining the name of the object
            Name = "chefeSeccao";

            Field(x => x.IdChefeSeccao, nullable: true);
            Field(x => x.SeccaoId, nullable: true);
            Field(x => x.ChefeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<FuncionarioType>("chefe", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.ChefeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<SeccaoType>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(c.Source.SeccaoId)));
            
        }
    }

    public class ChefeSeccaoInputType : InputObjectGraphType
	{
		public ChefeSeccaoInputType()
		{
			// Defining the name of the object
			Name = "chefeSeccaoInput";
			
            //Field<StringGraphType>("idChefeSeccao");
			Field<StringGraphType>("seccaoId");
			Field<StringGraphType>("chefeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<FuncionarioInputType>("chefe");
			Field<EstadoInputType>("estado");
			Field<SeccaoInputType>("seccao");
			
		}
	}
}