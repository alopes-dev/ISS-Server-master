using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SubMenuType : ObjectGraphType<SubMenu>
    {
        public SubMenuType()
        {
            // Defining the name of the object
            Name = "subMenu";

            Field(x => x.IdSubMenu, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodSubMenu, nullable: true);
            Field(x => x.Path, nullable: true);
            Field(x => x.Legenda, nullable: true);
            Field(x => x.MenuId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<MenuType>("menu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Menu>(c.Source.MenuId)));
            FieldAsync<ListGraphType<CanalMenuType>>("canalMenu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalMenu>(x => x.Where(e => e.HasValue(c.Source.IdSubMenu)))));
            
        }
    }

    public class SubMenuInputType : InputObjectGraphType
	{
		public SubMenuInputType()
		{
			// Defining the name of the object
			Name = "subMenuInput";
			
            //Field<StringGraphType>("idSubMenu");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codSubMenu");
			Field<StringGraphType>("path");
			Field<StringGraphType>("legenda");
			Field<StringGraphType>("menuId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<MenuInputType>("menu");
			Field<ListGraphType<CanalMenuInputType>>("canalMenu");
			
		}
	}
}