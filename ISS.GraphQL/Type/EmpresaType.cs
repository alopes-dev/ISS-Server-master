using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class EmpresaType : ObjectGraphType<Empresa>
    {
        public EmpresaType()
        {
            // Defining the name of the object
            Name = "empresa";

            Field(x => x.IdDadosEmpresa, nullable: true);
            Field(x => x.NomeEmpresa, nullable: true);
            Field(x => x.RazaoSocial, nullable: true);
            Field(x => x.CapitalSocial, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Nif, nullable: true);
            Field(x => x.Caeid, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Inss, nullable: true);
            Field(x => x.NumAlvara, nullable: true);
            Field(x => x.CaixaPostal, nullable: true);
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.CodEmpresa, nullable: true);
            Field(x => x.Carimbo, nullable: true);
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.Caeid)));
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ComiteType>>("comite", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comite>(x => x.Where(e => e.HasValue(c.Source.IdDadosEmpresa)))));
            FieldAsync<ListGraphType<ContactoEmpresaType>>("contactoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContactoEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdDadosEmpresa)))));
            FieldAsync<ListGraphType<DireccaoEmpresaType>>("direccaoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DireccaoEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdDadosEmpresa)))));
            FieldAsync<ListGraphType<InformacaoBancariaType>>("informacaoBancaria", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancaria>(x => x.Where(e => e.HasValue(c.Source.IdDadosEmpresa)))));
            FieldAsync<ListGraphType<MovimentoType>>("movimento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Movimento>(x => x.Where(e => e.HasValue(c.Source.IdDadosEmpresa)))));
            FieldAsync<ListGraphType<PerguntasFrequentesEmpresaType>>("perguntasFrequentesEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PerguntasFrequentesEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdDadosEmpresa)))));
            FieldAsync<ListGraphType<TipoContratoEmpresaType>>("tipoContratoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContratoEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdDadosEmpresa)))));
            
        }
    }

    public class EmpresaInputType : InputObjectGraphType
	{
		public EmpresaInputType()
		{
			// Defining the name of the object
			Name = "empresaInput";
			
            //Field<StringGraphType>("idDadosEmpresa");
			Field<StringGraphType>("nomeEmpresa");
			Field<StringGraphType>("razaoSocial");
			Field<FloatGraphType>("capitalSocial");
			Field<StringGraphType>("nif");
			Field<StringGraphType>("caeid");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("inss");
			Field<StringGraphType>("numAlvara");
			Field<StringGraphType>("caixaPostal");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("codEmpresa");
			Field<StringGraphType>("carimbo");
			Field<CaeInputType>("cae");
			Field<DireccaoInputType>("direccao");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ComiteInputType>>("comite");
			Field<ListGraphType<ContactoEmpresaInputType>>("contactoEmpresa");
			Field<ListGraphType<DireccaoEmpresaInputType>>("direccaoEmpresa");
			Field<ListGraphType<InformacaoBancariaInputType>>("informacaoBancaria");
			Field<ListGraphType<MovimentoInputType>>("movimento");
			Field<ListGraphType<PerguntasFrequentesEmpresaInputType>>("perguntasFrequentesEmpresa");
			Field<ListGraphType<TipoContratoEmpresaInputType>>("tipoContratoEmpresa");
			
		}
	}
}