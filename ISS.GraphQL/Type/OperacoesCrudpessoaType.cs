using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class OperacoesCrudpessoaType : ObjectGraphType<OperacoesCrudpessoa>
    {
        public OperacoesCrudpessoaType()
        {
            // Defining the name of the object
            Name = "operacoesCrudpessoa";

            Field(x => x.IdOperacoesCrudpessoa, nullable: true);
            Field(x => x.ModuloCoreId, nullable: true);
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.DepartamentoId, nullable: true);
            Field(x => x.SectorId, nullable: true);
            Field(x => x.SeccaoId, nullable: true);
            Field(x => x.AreaId, nullable: true);
            Field(x => x.FuncaoId, nullable: true);
            Field(x => x.CargoFuncionarioId, nullable: true);
            Field(x => x.PapelId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.OperacoesCrudId, nullable: true);
            FieldAsync<AreaType>("area", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Area>(c.Source.AreaId)));
            FieldAsync<DepartamentoType>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(c.Source.DepartamentoId)));
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FuncaoType>("funcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcao>(c.Source.FuncaoId)));
            FieldAsync<ModuloCoreType>("moduloCore", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModuloCore>(c.Source.ModuloCoreId)));
            FieldAsync<OperacoesCrudType>("operacoesCrud", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesCrud>(c.Source.OperacoesCrudId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<SeccaoType>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(c.Source.SeccaoId)));
            FieldAsync<SectorType>("sector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sector>(c.Source.SectorId)));
            
        }
    }

    public class OperacoesCrudpessoaInputType : InputObjectGraphType
	{
		public OperacoesCrudpessoaInputType()
		{
			// Defining the name of the object
			Name = "operacoesCrudpessoaInput";
			
            //Field<StringGraphType>("idOperacoesCrudpessoa");
			Field<StringGraphType>("moduloCoreId");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("departamentoId");
			Field<StringGraphType>("sectorId");
			Field<StringGraphType>("seccaoId");
			Field<StringGraphType>("areaId");
			Field<StringGraphType>("funcaoId");
			Field<StringGraphType>("cargoFuncionarioId");
			Field<StringGraphType>("papelId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("operacoesCrudId");
			Field<AreaInputType>("area");
			Field<DepartamentoInputType>("departamento");
			Field<DireccaoInputType>("direccao");
			Field<EstadoInputType>("estado");
			Field<FuncaoInputType>("funcao");
			Field<ModuloCoreInputType>("moduloCore");
			Field<OperacoesCrudInputType>("operacoesCrud");
			Field<PapelInputType>("papel");
			Field<SeccaoInputType>("seccao");
			Field<SectorInputType>("sector");
			
		}
	}
}