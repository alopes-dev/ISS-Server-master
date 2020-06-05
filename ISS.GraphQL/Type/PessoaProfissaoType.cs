using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PessoaProfissaoType : ObjectGraphType<PessoaProfissao>
    {
        public PessoaProfissaoType()
        {
            // Defining the name of the object
            Name = "pessoaProfissao";

            Field(x => x.IdPessoaProfissao, nullable: true);
            Field(x => x.EnderecoEmpresaId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.ProfissaoId, nullable: true);
            Field(x => x.FormaEntregaId, nullable: true);
            Field(x => x.ContactoEmpresaId, nullable: true);
            Field(x => x.FuncaoId, nullable: true);
            Field(x => x.CategoriaId, nullable: true);
            Field(x => x.NomeEmpresa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodPessoaProfissao, nullable: true);
            Field(x => x.CargoId, nullable: true);
            Field(x => x.SalarioBase, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SalarioLiquido, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.OutroRendimento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SalarioId, nullable: true);
            FieldAsync<CargoType>("cargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cargo>(c.Source.CargoId)));
            FieldAsync<CategoriaFuncaoType>("categoria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaFuncao>(c.Source.CategoriaId)));
            FieldAsync<ContactoType>("contactoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(c.Source.ContactoEmpresaId)));
            FieldAsync<EnderecoType>("enderecoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoEmpresaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaEntregaType>("formaEntrega", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaEntrega>(c.Source.FormaEntregaId)));
            FieldAsync<FuncaoType>("funcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcao>(c.Source.FuncaoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<ProfissaoType>("profissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Profissao>(c.Source.ProfissaoId)));
            FieldAsync<RendimentoPessoaType>("salario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RendimentoPessoa>(c.Source.SalarioId)));
            FieldAsync<ListGraphType<LocalTrabalhoPessoaType>>("localTrabalhoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalTrabalhoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdPessoaProfissao)))));
            FieldAsync<ListGraphType<MembroAsseguradoType>>("membroAssegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MembroAssegurado>(x => x.Where(e => e.HasValue(c.Source.IdPessoaProfissao)))));
            
        }
    }

    public class PessoaProfissaoInputType : InputObjectGraphType
	{
		public PessoaProfissaoInputType()
		{
			// Defining the name of the object
			Name = "pessoaProfissaoInput";
			
            //Field<StringGraphType>("idPessoaProfissao");
			Field<StringGraphType>("enderecoEmpresaId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("profissaoId");
			Field<StringGraphType>("formaEntregaId");
			Field<StringGraphType>("contactoEmpresaId");
			Field<StringGraphType>("funcaoId");
			Field<StringGraphType>("categoriaId");
			Field<StringGraphType>("nomeEmpresa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codPessoaProfissao");
			Field<StringGraphType>("cargoId");
			Field<FloatGraphType>("salarioBase");
			Field<FloatGraphType>("salarioLiquido");
			Field<FloatGraphType>("outroRendimento");
			Field<StringGraphType>("salarioId");
			Field<CargoInputType>("cargo");
			Field<CategoriaFuncaoInputType>("categoria");
			Field<ContactoInputType>("contactoEmpresa");
			Field<EnderecoInputType>("enderecoEmpresa");
			Field<EstadoInputType>("estado");
			Field<FormaEntregaInputType>("formaEntrega");
			Field<FuncaoInputType>("funcao");
			Field<PessoaInputType>("pessoa");
			Field<ProfissaoInputType>("profissao");
			Field<RendimentoPessoaInputType>("salario");
			Field<ListGraphType<LocalTrabalhoPessoaInputType>>("localTrabalhoPessoa");
			Field<ListGraphType<MembroAsseguradoInputType>>("membroAssegurado");
			
		}
	}
}