using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModuloCoreDireccaoType : ObjectGraphType<ModuloCoreDireccao>
    {
        public ModuloCoreDireccaoType()
        {
            // Defining the name of the object
            Name = "moduloCoreDireccao";

            Field(x => x.IdModuloCoreDireccao, nullable: true);
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ModuloCoreId, nullable: true);
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ModuloCoreType>("moduloCore", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModuloCore>(c.Source.ModuloCoreId)));
            
        }
    }

    public class ModuloCoreDireccaoInputType : InputObjectGraphType
	{
		public ModuloCoreDireccaoInputType()
		{
			// Defining the name of the object
			Name = "moduloCoreDireccaoInput";
			
            //Field<StringGraphType>("idModuloCoreDireccao");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("moduloCoreId");
			Field<DireccaoInputType>("direccao");
			Field<EstadoInputType>("estado");
			Field<ModuloCoreInputType>("moduloCore");
			
		}
	}
}