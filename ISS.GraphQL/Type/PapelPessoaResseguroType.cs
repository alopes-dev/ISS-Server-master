using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PapelPessoaResseguroType : ObjectGraphType<PapelPessoaResseguro>
    {
        public PapelPessoaResseguroType()
        {
            // Defining the name of the object
            Name = "papelPessoaResseguro";

            Field(x => x.IdPapelPessoaResseguro, nullable: true);
            Field(x => x.SubscricaoCessaoRetencao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodPapelPessoaResseguro, nullable: true);
            Field(x => x.IdPessoaRetente, nullable: true);
            Field(x => x.IdPessoCedente, nullable: true);
            FieldAsync<PapelPessoaType>("idPessoCedenteNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPessoa>(c.Source.IdPessoCedente)));
            FieldAsync<PapelPessoaType>("idPessoaRetenteNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPessoa>(c.Source.IdPessoaRetente)));
            FieldAsync<SubscricaoCessaoRetencaoType>("subscricaoCessaoRetencaoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubscricaoCessaoRetencao>(c.Source.SubscricaoCessaoRetencao)));
            
        }
    }

    public class PapelPessoaResseguroInputType : InputObjectGraphType
	{
		public PapelPessoaResseguroInputType()
		{
			// Defining the name of the object
			Name = "papelPessoaResseguroInput";
			
            //Field<StringGraphType>("idPapelPessoaResseguro");
			Field<StringGraphType>("subscricaoCessaoRetencao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codPapelPessoaResseguro");
			Field<StringGraphType>("idPessoaRetente");
			Field<StringGraphType>("idPessoCedente");
			Field<PapelPessoaInputType>("idPessoCedenteNavigation");
			Field<PapelPessoaInputType>("idPessoaRetenteNavigation");
			Field<SubscricaoCessaoRetencaoInputType>("subscricaoCessaoRetencaoNavigation");
			
		}
	}
}