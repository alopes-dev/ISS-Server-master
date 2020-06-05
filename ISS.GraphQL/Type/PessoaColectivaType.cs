using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PessoaColectivaType : PessoaType
    {
        public PessoaColectivaType()
        {
            // Defining the name of the object
            Name = "pessoaColectiva";

            Field(x => x.Caeid, nullable: true);
            Field(x => x.NumRegistoInapem, nullable: true);
            Field(x => x.NumAlvara, nullable: true);
            Field(x => x.CapitalSocial, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumeroProprietarios, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumeroMembros, nullable: true, type: typeof(IntGraphType));
            Field(x => x.DimensaoEmpresaId, nullable: true);
            Field(x => x.Sigla, nullable: true);
            Field(x => x.NumRegistroComercial, nullable: true);
            Field(x => x.DespesaTotalDosFuncionarios, nullable: true);
            Field(x => x.NumRegistroEmpresa, nullable: true);
            Field(x => x.DespesaTotalFuncionarios, nullable: true, type: typeof(IntGraphType));
            Field(x => x.TipoSociedadeId, nullable: true);
            FieldAsync<CaeType>("cae", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cae>(c.Source.Caeid)));
            FieldAsync<DimensaoEmpresaType>("dimensaoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DimensaoEmpresa>(c.Source.DimensaoEmpresaId)));
            FieldAsync<TipoSociedadeType>("tipoSociedade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSociedade>(c.Source.TipoSociedadeId)));
            
        }
    }

    public class PessoaColectivaInputType : PessoaInputType
	{
		public PessoaColectivaInputType()
		{
			// Defining the name of the object
			Name = "pessoaColectivaInput";
			
            Field(x => x.Caeid,nullable:true);
            Field(x => x.NumRegistoInapem,nullable:true);
            Field(x => x.NumAlvara,nullable:true);
            Field(x => x.NumeroProprietarios,nullable:true);
            Field(x => x.NumeroMembros,nullable:true);
            Field(x => x.DimensaoEmpresaId,nullable:true);
            Field(x => x.Sigla,nullable:true);
            Field(x => x.NumRegistroComercial,nullable:true);
            Field(x => x.DespesaTotalDosFuncionarios,nullable:true);
            Field(x => x.NumRegistroEmpresa,nullable:true);
            Field(x => x.DespesaTotalFuncionarios,nullable:true);
            Field(x => x.TipoSociedadeId,nullable:true);
			Field(x => x.DimensaoEmpresa,nullable:true,type:typeof(DimensaoEmpresaInputType));
		}
	}
}