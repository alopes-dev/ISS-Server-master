using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SectorType : ObjectGraphType<Sector>
    {
        public SectorType()
        {
            // Defining the name of the object
            Name = "sector";

            Field(x => x.IdSector, nullable: true);
            Field(x => x.NomeSector, nullable: true);
            Field(x => x.ContactoId, nullable: true);
            Field(x => x.CodSector, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.SubContaId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DepartamentoId, nullable: true);
            FieldAsync<ContactoType>("contacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contacto>(c.Source.ContactoId)));
            FieldAsync<DepartamentoType>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(c.Source.DepartamentoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PlanoContasType>("subConta", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PlanoContas>(c.Source.SubContaId)));
            FieldAsync<ListGraphType<CentroCustoType>>("centroCusto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroCusto>(x => x.Where(e => e.HasValue(c.Source.IdSector)))));
            FieldAsync<ListGraphType<CentroResponsabilidadeType>>("centroResponsabilidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CentroResponsabilidade>(x => x.Where(e => e.HasValue(c.Source.IdSector)))));
            FieldAsync<ListGraphType<ChefeSectorType>>("chefeSector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ChefeSector>(x => x.Where(e => e.HasValue(c.Source.IdSector)))));
            FieldAsync<ListGraphType<FuncionarioType>>("funcionario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(x => x.Where(e => e.HasValue(c.Source.IdSector)))));
            FieldAsync<ListGraphType<OperacoesCrudpessoaType>>("operacoesCrudpessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesCrudpessoa>(x => x.Where(e => e.HasValue(c.Source.IdSector)))));
            FieldAsync<ListGraphType<SeccaoType>>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(x => x.Where(e => e.HasValue(c.Source.IdSector)))));
            
        }
    }

    public class SectorInputType : InputObjectGraphType
	{
		public SectorInputType()
		{
			// Defining the name of the object
			Name = "sectorInput";
			
            //Field<StringGraphType>("idSector");
			Field<StringGraphType>("nomeSector");
			Field<StringGraphType>("contactoId");
			Field<StringGraphType>("codSector");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("subContaId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("departamentoId");
			Field<ContactoInputType>("contacto");
			Field<DepartamentoInputType>("departamento");
			Field<EstadoInputType>("estado");
			Field<PlanoContasInputType>("subConta");
			Field<ListGraphType<CentroCustoInputType>>("centroCusto");
			Field<ListGraphType<CentroResponsabilidadeInputType>>("centroResponsabilidade");
			Field<ListGraphType<ChefeSectorInputType>>("chefeSector");
			Field<ListGraphType<FuncionarioInputType>>("funcionario");
			Field<ListGraphType<OperacoesCrudpessoaInputType>>("operacoesCrudpessoa");
			Field<ListGraphType<SeccaoInputType>>("seccao");
			
		}
	}
}