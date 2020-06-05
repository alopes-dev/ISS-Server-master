using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CanalMenuType : ObjectGraphType<CanalMenu>
    {
        public CanalMenuType()
        {
            // Defining the name of the object
            Name = "canalMenu";

            Field(x => x.IdCanalMenu, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCanalMenu, nullable: true);
            Field(x => x.CanalId, nullable: true);
            Field(x => x.MenuId, nullable: true);
            Field(x => x.SubMenuId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<CanalType>("canal", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Canal>(c.Source.CanalId)));
            FieldAsync<MenuType>("menu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Menu>(c.Source.MenuId)));
            FieldAsync<SubMenuType>("subMenu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubMenu>(c.Source.SubMenuId)));
            
        }
    }

    public class CanalMenuInputType : InputObjectGraphType
	{
		public CanalMenuInputType()
		{
			// Defining the name of the object
			Name = "canalMenuInput";
			
            //Field<StringGraphType>("idCanalMenu");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCanalMenu");
			Field<StringGraphType>("canalId");
			Field<StringGraphType>("menuId");
			Field<StringGraphType>("subMenuId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<CanalInputType>("canal");
			Field<MenuInputType>("menu");
			Field<SubMenuInputType>("subMenu");
			
		}
	}
}