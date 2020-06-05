using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ContactoType : ObjectGraphType<Contacto>
    {
        public ContactoType()
        {
            // Defining the name of the object
            Name = "contacto";

            Field(x => x.IdContacto, nullable: true);
			Field<BooleanGraphType>(name: nameof(ContactoPessoa.Principal), resolve: c => true);
            Field(x => x.Telemovel, nullable: true);
            Field(x => x.Telefone, nullable: true);
            Field(x => x.Email, nullable: true);
            Field(x => x.Fax, nullable: true);
            Field(x => x.WebSite, nullable: true);
            Field(x => x.TipoContactoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PaisId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.ContaFinanceiraId, nullable: true);
            FieldAsync<ContaFinanceiraType>("contaFinanceira", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaFinanceira>(c.Source.ContaFinanceiraId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PaisType>("pais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pais>(c.Source.PaisId)));
            FieldAsync<TipoContactoType>("tipoContacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContacto>(c.Source.TipoContactoId)));
            FieldAsync<ListGraphType<BalcaoType>>("balcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Balcao>(x => x.Where(e => e.HasValue(c.Source.IdContacto)))));
            FieldAsync<ListGraphType<ContactoEmpresaType>>("contactoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContactoEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdContacto)))));
            FieldAsync<ListGraphType<ContactoPessoaType>>("contactoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContactoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdContacto)))));
            FieldAsync<ListGraphType<DepartamentoType>>("departamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Departamento>(x => x.Where(e => e.HasValue(c.Source.IdContacto)))));
            FieldAsync<ListGraphType<NewsletterType>>("newsletter", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Newsletter>(x => x.Where(e => e.HasValue(c.Source.IdContacto)))));
            FieldAsync<ListGraphType<PessoaProfissaoType>>("pessoaProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(x => x.Where(e => e.HasValue(c.Source.IdContacto)))));
            FieldAsync<ListGraphType<RedeSociaisType>>("redeSociais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RedeSociais>(x => x.Where(e => e.HasValue(c.Source.IdContacto)))));
            FieldAsync<ListGraphType<SeccaoType>>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(x => x.Where(e => e.HasValue(c.Source.IdContacto)))));
            FieldAsync<ListGraphType<SectorType>>("sector", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sector>(x => x.Where(e => e.HasValue(c.Source.IdContacto)))));
            
        }
    }

    public class ContactoInputType : InputObjectGraphType
	{
		public ContactoInputType()
		{
			// Defining the name of the object
			Name = "contactoInput";
			
            //Field<StringGraphType>("idContacto");
			Field<StringGraphType>("telemovel");
			Field<StringGraphType>("telefone");
			Field<StringGraphType>("email");
			Field<StringGraphType>("fax");
			Field<StringGraphType>("webSite");
			Field<StringGraphType>("tipoContactoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("paisId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("contaFinanceiraId");
			Field<ContaFinanceiraInputType>("contaFinanceira");
			Field<EstadoInputType>("estado");
			Field<PaisInputType>("pais");
			Field<TipoContactoInputType>("tipoContacto");
			Field<ListGraphType<BalcaoInputType>>("balcao");
			Field<ListGraphType<ContactoEmpresaInputType>>("contactoEmpresa");
			Field<ListGraphType<ContactoPessoaInputType>>("contactoPessoa");
			Field<ListGraphType<DepartamentoInputType>>("departamento");
			Field<ListGraphType<NewsletterInputType>>("newsletter");
			Field<ListGraphType<PessoaProfissaoInputType>>("pessoaProfissao");
			Field<ListGraphType<RedeSociaisInputType>>("redeSociais");
			Field<ListGraphType<SeccaoInputType>>("seccao");
			Field<ListGraphType<SectorInputType>>("sector");
			
		}
	}
}