using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PapelPessoaType : ObjectGraphType<PapelPessoa>
    {
        public PapelPessoaType()
        {
            // Defining the name of the object
            Name = "papelPessoa";

            Field(x => x.IdPapelPessoa, nullable: true);
            Field(x => x.PapelId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.Contabiliza, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodPapelPessoa, nullable: true);
            Field(x => x.TipoSegmentoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            FieldAsync<ListGraphType<PapelModuloPessoaType>>("papelModuloPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelModuloPessoa>(x => x.Where(e => e.HasValue(c.Source.IdPapelPessoa)))));
            FieldAsync<ListGraphType<PapelPessoaResseguroType>>("papelPessoaResseguroIdPessoCedenteNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPessoaResseguro>(x => x.Where(e => e.HasValue(c.Source.IdPapelPessoa)))));
            FieldAsync<ListGraphType<PapelPessoaResseguroType>>("papelPessoaResseguroIdPessoaRetenteNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPessoaResseguro>(x => x.Where(e => e.HasValue(c.Source.IdPapelPessoa)))));
            
        }
    }

    public class PapelPessoaInputType : InputObjectGraphType
	{
		public PapelPessoaInputType()
		{
			// Defining the name of the object
			Name = "papelPessoaInput";
			
            //Field<StringGraphType>("idPapelPessoa");
			Field<StringGraphType>("papelId");
			Field<StringGraphType>("estadoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<BooleanGraphType>("contabiliza");
			Field<StringGraphType>("codPapelPessoa");
			Field<StringGraphType>("tipoSegmentoId");
			Field<EstadoInputType>("estado");
			Field<PapelInputType>("papel");
			Field<PessoaInputType>("pessoa");
			Field<TipoSegmentoInputType>("tipoSegmento");
			Field<ListGraphType<PapelModuloPessoaInputType>>("papelModuloPessoa");
			Field<ListGraphType<PapelPessoaResseguroInputType>>("papelPessoaResseguroIdPessoCedenteNavigation");
			Field<ListGraphType<PapelPessoaResseguroInputType>>("papelPessoaResseguroIdPessoaRetenteNavigation");
			
		}
	}
}