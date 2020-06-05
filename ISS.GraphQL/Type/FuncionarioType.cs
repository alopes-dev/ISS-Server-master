using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FuncionarioType : ObjectGraphType<Funcionario>
    {
        public FuncionarioType()
        {
            // Defining the name of the object
            Name = "funcionario";

            Field(x => x.IdFuncionario, nullable: true);
            Field(x => x.EmpresaId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.NumIdentificacao, nullable: true);
            Field(x => x.DataContratacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataInicioTrabalho, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DepartamentoId, nullable: true);
            Field(x => x.SectorId, nullable: true);
            Field(x => x.SeccaoId, nullable: true);
            Field(x => x.FuncaoId, nullable: true);
            Field(x => x.CategoriaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CargoFuncionarioId, nullable: true);
            Field(x => x.AreaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.NumeroCedulaProfissional, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CodFuncionario, nullable: true);
            FieldAsync<AreaType>("area", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Area>(c.Source.AreaId)));
            FieldAsync<CategoriaFuncaoType>("categoria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaFuncao>(c.Source.CategoriaId)));
            FieldAsync<DepartamentoType>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(c.Source.DepartamentoId)));
            FieldAsync<PessoaType>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.EmpresaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FuncaoType>("funcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcao>(c.Source.FuncaoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SeccaoType>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(c.Source.SeccaoId)));
            FieldAsync<SectorType>("sector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sector>(c.Source.SectorId)));
            FieldAsync<ListGraphType<CaixaType>>("caixa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Caixa>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<ChefeDepartamentoType>>("chefeDepartamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ChefeDepartamento>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<ChefeSeccaoType>>("chefeSeccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ChefeSeccao>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<ChefeSectorType>>("chefeSector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ChefeSector>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<DirectorDireccaoType>>("directorDireccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DirectorDireccao>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<MembroCadType>>("membroCad", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MembroCad>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<ReembolsoDespesasMedicasType>>("reembolsoDespesasMedicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReembolsoDespesasMedicas>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<ReembolsoTratamentoDentarioType>>("reembolsoTratamentoDentario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReembolsoTratamentoDentario>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<ResponsavelBalcaoType>>("responsavelBalcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ResponsavelBalcao>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<TermoResponsabilidadeType>>("termoResponsabilidadeEmpregadoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TermoResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<TermoResponsabilidadeType>>("termoResponsabilidadeMedicoPrescritorNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TermoResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<ValorCativoType>>("valorCativoCativadoPor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValorCativo>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            FieldAsync<ListGraphType<ValorCativoType>>("valorCativoDescativadoPor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ValorCativo>(x => x.Where(e => e.HasValue(c.Source.IdFuncionario)))));
            
        }
    }

    public class FuncionarioInputType : InputObjectGraphType
	{
		public FuncionarioInputType()
		{
			// Defining the name of the object
			Name = "funcionarioInput";
			
            //Field<StringGraphType>("idFuncionario");
			Field<StringGraphType>("empresaId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("numIdentificacao");
			Field<DateTimeGraphType>("dataContratacao");
			Field<DateTimeGraphType>("dataInicioTrabalho");
			Field<StringGraphType>("departamentoId");
			Field<StringGraphType>("sectorId");
			Field<StringGraphType>("seccaoId");
			Field<StringGraphType>("funcaoId");
			Field<StringGraphType>("categoriaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("cargoFuncionarioId");
			Field<StringGraphType>("areaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<IntGraphType>("numeroCedulaProfissional");
			Field<StringGraphType>("codFuncionario");
			Field<AreaInputType>("area");
			Field<CategoriaFuncaoInputType>("categoria");
			Field<DepartamentoInputType>("departamento");
			Field<PessoaInputType>("empresa");
			Field<EstadoInputType>("estado");
			Field<FuncaoInputType>("funcao");
			Field<PessoaInputType>("pessoa");
			Field<SeccaoInputType>("seccao");
			Field<SectorInputType>("sector");
			Field<ListGraphType<CaixaInputType>>("caixa");
			Field<ListGraphType<ChefeDepartamentoInputType>>("chefeDepartamento");
			Field<ListGraphType<ChefeSeccaoInputType>>("chefeSeccao");
			Field<ListGraphType<ChefeSectorInputType>>("chefeSector");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			Field<ListGraphType<DirectorDireccaoInputType>>("directorDireccao");
			Field<ListGraphType<MembroCadInputType>>("membroCad");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<ReembolsoDespesasMedicasInputType>>("reembolsoDespesasMedicas");
			Field<ListGraphType<ReembolsoTratamentoDentarioInputType>>("reembolsoTratamentoDentario");
			Field<ListGraphType<ResponsavelBalcaoInputType>>("responsavelBalcao");
			Field<ListGraphType<TermoResponsabilidadeInputType>>("termoResponsabilidadeEmpregadoNavigation");
			Field<ListGraphType<TermoResponsabilidadeInputType>>("termoResponsabilidadeMedicoPrescritorNavigation");
			Field<ListGraphType<ValorCativoInputType>>("valorCativoCativadoPor");
			Field<ListGraphType<ValorCativoInputType>>("valorCativoDescativadoPor");
			
		}
	}
}