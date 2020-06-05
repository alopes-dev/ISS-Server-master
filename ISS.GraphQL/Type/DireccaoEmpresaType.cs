using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DireccaoEmpresaType : ObjectGraphType<DireccaoEmpresa>
    {
        public DireccaoEmpresaType()
        {
            // Defining the name of the object
            Name = "direccaoEmpresa";

            Field(x => x.IdDireccaoEmpresa, nullable: true);
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.CodDireccaoEmpresa, nullable: true);
            Field(x => x.EmpresaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<EmpresaType>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Empresa>(c.Source.EmpresaId)));
            FieldAsync<ListGraphType<DireccaoEmpresaDepartamentoType>>("direccaoEmpresaDepartamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DireccaoEmpresaDepartamento>(x => x.Where(e => e.HasValue(c.Source.IdDireccaoEmpresa)))));
            
        }
    }

    public class DireccaoEmpresaInputType : InputObjectGraphType
	{
		public DireccaoEmpresaInputType()
		{
			// Defining the name of the object
			Name = "direccaoEmpresaInput";
			
            //Field<StringGraphType>("idDireccaoEmpresa");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("codDireccaoEmpresa");
			Field<StringGraphType>("empresaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<DireccaoInputType>("direccao");
			Field<EmpresaInputType>("empresa");
			Field<ListGraphType<DireccaoEmpresaDepartamentoInputType>>("direccaoEmpresaDepartamento");
			
		}
	}
}