using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MenuType : ObjectGraphType<Menu>
    {
        public MenuType()
        {
            // Defining the name of the object
            Name = "menu";

            Field(x => x.IdMenu, nullable: true);
            Field(x => x.Name, nullable: true);
            Field(x => x.Path, nullable: true);
            Field(x => x.PapelId, nullable: true);
            Field(x => x.DesignacaoModulo, nullable: true);
            Field(x => x.Icon, nullable: true);
            Field(x => x.Legenda, nullable: true);
            Field(x => x.LicencaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NivelPaiId, nullable: true);
            Field(x => x.NumOrdem, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Collapse, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.State, nullable: true);
            Field(x => x.Layout, nullable: true);
            Field(x => x.Component, nullable: true);
            Field(x => x.CodMenu, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<LicencaType>("licenca", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Licenca>(c.Source.LicencaId)));
            FieldAsync<MenuType>("nivelPai", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Menu>(c.Source.NivelPaiId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<ListGraphType<CanalMenuType>>("canalMenu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CanalMenu>(x => x.Where(e => e.HasValue(c.Source.IdMenu)))));
            FieldAsync<ListGraphType<MenuType>>("inverseNivelPai", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Menu>(x => x.Where(e => e.HasValue(c.Source.IdMenu)))));
            FieldAsync<ListGraphType<SubMenuType>>("subMenu", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubMenu>(x => x.Where(e => e.HasValue(c.Source.IdMenu)))));
            
        }
    }

    public class MenuInputType : InputObjectGraphType
	{
		public MenuInputType()
		{
			// Defining the name of the object
			Name = "menuInput";
			
            //Field<StringGraphType>("idMenu");
			Field<StringGraphType>("name");
			Field<StringGraphType>("path");
			Field<StringGraphType>("papelId");
			Field<StringGraphType>("designacaoModulo");
			Field<StringGraphType>("icon");
			Field<StringGraphType>("legenda");
			Field<StringGraphType>("licencaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("nivelPaiId");
			Field<IntGraphType>("numOrdem");
			Field<BooleanGraphType>("collapse");
			Field<StringGraphType>("state");
			Field<StringGraphType>("layout");
			Field<StringGraphType>("component");
			Field<StringGraphType>("codMenu");
			Field<EstadoInputType>("estado");
			Field<LicencaInputType>("licenca");
			Field<MenuInputType>("nivelPai");
			Field<PapelInputType>("papel");
			Field<ListGraphType<CanalMenuInputType>>("canalMenu");
			Field<ListGraphType<MenuInputType>>("inverseNivelPai");
			Field<ListGraphType<SubMenuInputType>>("subMenu");
			
		}
	}
}