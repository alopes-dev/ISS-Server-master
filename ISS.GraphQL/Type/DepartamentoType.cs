using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DepartamentoType : ObjectGraphType<Departamento>
    {
        public DepartamentoType()
        {
            // Defining the name of the object
            Name = "departamento";

            Field(x => x.IdDepartamento, nullable: true);
            Field(x => x.NomeDepartamento, nullable: true);
            Field(x => x.CodDepartamento, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.ContactoId, nullable: true);
            FieldAsync<ContactoType>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(c.Source.ContactoId)));
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<CasoClassificacaoType>>("casoClassificacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CasoClassificacao>(x => x.Where(e => e.HasValue(c.Source.IdDepartamento)))));
            FieldAsync<ListGraphType<CentroResponsabilidadeType>>("centroResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdDepartamento)))));
            FieldAsync<ListGraphType<ChefeDepartamentoType>>("chefeDepartamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ChefeDepartamento>(x => x.Where(e => e.HasValue(c.Source.IdDepartamento)))));
            FieldAsync<ListGraphType<DireccaoEmpresaDepartamentoType>>("direccaoEmpresaDepartamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DireccaoEmpresaDepartamento>(x => x.Where(e => e.HasValue(c.Source.IdDepartamento)))));
            FieldAsync<ListGraphType<FuncionarioType>>("funcionario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(x => x.Where(e => e.HasValue(c.Source.IdDepartamento)))));
            FieldAsync<ListGraphType<OperacoesCrudpessoaType>>("operacoesCrudpessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesCrudpessoa>(x => x.Where(e => e.HasValue(c.Source.IdDepartamento)))));
            FieldAsync<ListGraphType<PessoaTarefaType>>("pessoaTarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaTarefa>(x => x.Where(e => e.HasValue(c.Source.IdDepartamento)))));
            FieldAsync<ListGraphType<SectorType>>("sector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sector>(x => x.Where(e => e.HasValue(c.Source.IdDepartamento)))));
            
        }
    }

    public class DepartamentoInputType : InputObjectGraphType
	{
		public DepartamentoInputType()
		{
			// Defining the name of the object
			Name = "departamentoInput";
			
            //Field<StringGraphType>("idDepartamento");
			Field<StringGraphType>("nomeDepartamento");
			Field<StringGraphType>("codDepartamento");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("subContaId");
			Field<StringGraphType>("contactoId");
			Field<ContactoInputType>("contacto");
			Field<DireccaoInputType>("direccao");
			Field<EstadoInputType>("estado");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<CasoClassificacaoInputType>>("casoClassificacao");
			Field<ListGraphType<CentroResponsabilidadeInputType>>("centroResponsabilidade");
			Field<ListGraphType<ChefeDepartamentoInputType>>("chefeDepartamento");
			Field<ListGraphType<DireccaoEmpresaDepartamentoInputType>>("direccaoEmpresaDepartamento");
			Field<ListGraphType<FuncionarioInputType>>("funcionario");
			Field<ListGraphType<OperacoesCrudpessoaInputType>>("operacoesCrudpessoa");
			Field<ListGraphType<PessoaTarefaInputType>>("pessoaTarefa");
			Field<ListGraphType<SectorInputType>>("sector");
			
		}
	}
}