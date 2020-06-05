using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SeccaoType : ObjectGraphType<Seccao>
    {
        public SeccaoType()
        {
            // Defining the name of the object
            Name = "seccao";

            Field(x => x.IdSeccao, nullable: true);
            Field(x => x.NomeSeccao, nullable: true);
            Field(x => x.ContactoId, nullable: true);
            Field(x => x.SectorId, nullable: true);
            Field(x => x.CodSeccao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CargoId, nullable: true);
            Field(x => x.FuncaoId, nullable: true);
            FieldAsync<CargoType>("cargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cargo>(c.Source.CargoId)));
            FieldAsync<ContactoType>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(c.Source.ContactoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FuncaoType>("funcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcao>(c.Source.FuncaoId)));
            FieldAsync<SectorType>("sector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sector>(c.Source.SectorId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<CentroCustoType>>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(x => x.Where(e => e.HasValue(c.Source.IdSeccao)))));
            FieldAsync<ListGraphType<CentroResponsabilidadeType>>("centroResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdSeccao)))));
            FieldAsync<ListGraphType<ChefeSeccaoType>>("chefeSeccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ChefeSeccao>(x => x.Where(e => e.HasValue(c.Source.IdSeccao)))));
            FieldAsync<ListGraphType<FuncionarioType>>("funcionario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(x => x.Where(e => e.HasValue(c.Source.IdSeccao)))));
            FieldAsync<ListGraphType<OperacoesCrudpessoaType>>("operacoesCrudpessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesCrudpessoa>(x => x.Where(e => e.HasValue(c.Source.IdSeccao)))));
            FieldAsync<ListGraphType<PessoaTarefaType>>("pessoaTarefa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaTarefa>(x => x.Where(e => e.HasValue(c.Source.IdSeccao)))));
            FieldAsync<ListGraphType<PosicaoType>>("posicao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Posicao>(x => x.Where(e => e.HasValue(c.Source.IdSeccao)))));
            
        }
    }

    public class SeccaoInputType : InputObjectGraphType
	{
		public SeccaoInputType()
		{
			// Defining the name of the object
			Name = "seccaoInput";
			
            //Field<StringGraphType>("idSeccao");
			Field<StringGraphType>("nomeSeccao");
			Field<StringGraphType>("contactoId");
			Field<StringGraphType>("sectorId");
			Field<StringGraphType>("codSeccao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("subContaId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("cargoId");
			Field<StringGraphType>("funcaoId");
			Field<CargoInputType>("cargo");
			Field<ContactoInputType>("contacto");
			Field<EstadoInputType>("estado");
			Field<FuncaoInputType>("funcao");
			Field<SectorInputType>("sector");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<CentroCustoInputType>>("centroCusto");
			Field<ListGraphType<CentroResponsabilidadeInputType>>("centroResponsabilidade");
			Field<ListGraphType<ChefeSeccaoInputType>>("chefeSeccao");
			Field<ListGraphType<FuncionarioInputType>>("funcionario");
			Field<ListGraphType<OperacoesCrudpessoaInputType>>("operacoesCrudpessoa");
			Field<ListGraphType<PessoaTarefaInputType>>("pessoaTarefa");
			Field<ListGraphType<PosicaoInputType>>("posicao");
			
		}
	}
}