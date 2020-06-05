using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DireccaoType : ObjectGraphType<Direccao>
    {
        public DireccaoType()
        {
            // Defining the name of the object
            Name = "direccao";

            Field(x => x.IdDireccao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodDireccao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<CentroCustoType>>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            FieldAsync<ListGraphType<CentroResponsabilidadeType>>("centroResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            FieldAsync<ListGraphType<DepartamentoType>>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            FieldAsync<ListGraphType<DireccaoEmpresaType>>("direccaoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DireccaoEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            FieldAsync<ListGraphType<DirectorDireccaoType>>("directorDireccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DirectorDireccao>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            FieldAsync<ListGraphType<EmpresaType>>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Empresa>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            FieldAsync<ListGraphType<MembroCadType>>("membroCad", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MembroCad>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            FieldAsync<ListGraphType<ModuloCoreDireccaoType>>("moduloCoreDireccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModuloCoreDireccao>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            FieldAsync<ListGraphType<OperacoesCrudpessoaType>>("operacoesCrudpessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesCrudpessoa>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            FieldAsync<ListGraphType<PosicaoType>>("posicao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Posicao>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            FieldAsync<ListGraphType<TarefaType>>("tarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Tarefa>(x => x.Where(e => e.HasValue(c.Source.IdDireccao)))));
            
        }
    }

    public class DireccaoInputType : InputObjectGraphType
	{
		public DireccaoInputType()
		{
			// Defining the name of the object
			Name = "direccaoInput";
			
            //Field<StringGraphType>("idDireccao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codDireccao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("subContaId");
			Field<BooleanGraphType>("contabiliza");
			Field<EstadoInputType>("estado");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<CentroCustoInputType>>("centroCusto");
			Field<ListGraphType<CentroResponsabilidadeInputType>>("centroResponsabilidade");
			Field<ListGraphType<DepartamentoInputType>>("departamento");
			Field<ListGraphType<DireccaoEmpresaInputType>>("direccaoEmpresa");
			Field<ListGraphType<DirectorDireccaoInputType>>("directorDireccao");
			Field<ListGraphType<EmpresaInputType>>("empresa");
			Field<ListGraphType<MembroCadInputType>>("membroCad");
			Field<ListGraphType<ModuloCoreDireccaoInputType>>("moduloCoreDireccao");
			Field<ListGraphType<OperacoesCrudpessoaInputType>>("operacoesCrudpessoa");
			Field<ListGraphType<PosicaoInputType>>("posicao");
			Field<ListGraphType<TarefaInputType>>("tarefa");
			
		}
	}
}