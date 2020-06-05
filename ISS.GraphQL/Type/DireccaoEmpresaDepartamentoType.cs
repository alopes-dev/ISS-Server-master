using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DireccaoEmpresaDepartamentoType : ObjectGraphType<DireccaoEmpresaDepartamento>
    {
        public DireccaoEmpresaDepartamentoType()
        {
            // Defining the name of the object
            Name = "direccaoEmpresaDepartamento";

            Field(x => x.IdDireccaoEmpresaDepartamento, nullable: true);
            Field(x => x.DepartamentoId, nullable: true);
            Field(x => x.DireccaoEmpresaId, nullable: true);
            Field(x => x.CodDireccaoEmpresaDepartamento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<DepartamentoType>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(c.Source.DepartamentoId)));
            FieldAsync<DireccaoEmpresaType>("direccaoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DireccaoEmpresa>(c.Source.DireccaoEmpresaId)));
            
        }
    }

    public class DireccaoEmpresaDepartamentoInputType : InputObjectGraphType
	{
		public DireccaoEmpresaDepartamentoInputType()
		{
			// Defining the name of the object
			Name = "direccaoEmpresaDepartamentoInput";
			
            //Field<StringGraphType>("idDireccaoEmpresaDepartamento");
			Field<StringGraphType>("departamentoId");
			Field<StringGraphType>("direccaoEmpresaId");
			Field<StringGraphType>("codDireccaoEmpresaDepartamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<DepartamentoInputType>("departamento");
			Field<DireccaoEmpresaInputType>("direccaoEmpresa");
			
		}
	}
}