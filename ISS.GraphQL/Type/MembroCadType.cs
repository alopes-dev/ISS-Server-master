using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MembroCadType : ObjectGraphType<MembroCad>
    {
        public MembroCadType()
        {
            // Defining the name of the object
            Name = "membroCad";

            Field(x => x.IdMembroCad, nullable: true);
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.MembroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FuncionarioType>("membro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.MembroId)));
            
        }
    }

    public class MembroCadInputType : InputObjectGraphType
	{
		public MembroCadInputType()
		{
			// Defining the name of the object
			Name = "membroCadInput";
			
            //Field<StringGraphType>("idMembroCad");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("membroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<DireccaoInputType>("direccao");
			Field<EstadoInputType>("estado");
			Field<FuncionarioInputType>("membro");
			
		}
	}
}