using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DirectorDireccaoType : ObjectGraphType<DirectorDireccao>
    {
        public DirectorDireccaoType()
        {
            // Defining the name of the object
            Name = "directorDireccao";

            Field(x => x.IdDirectorDireccao, nullable: true);
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.DirectorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<FuncionarioType>("director", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.DirectorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class DirectorDireccaoInputType : InputObjectGraphType
	{
		public DirectorDireccaoInputType()
		{
			// Defining the name of the object
			Name = "directorDireccaoInput";
			
            //Field<StringGraphType>("idDirectorDireccao");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("directorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<DireccaoInputType>("direccao");
			Field<FuncionarioInputType>("director");
			Field<EstadoInputType>("estado");
			
		}
	}
}