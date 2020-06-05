using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoContratacaoType : ObjectGraphType<TipoContratacao>
    {
        public TipoContratacaoType()
        {
            // Defining the name of the object
            Name = "tipoContratacao";

            Field(x => x.IdTipoContratacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoContratacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoPessoaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoPessoaType>("tipoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPessoa>(c.Source.TipoPessoaId)));
            FieldAsync<ListGraphType<PapelType>>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(x => x.Where(e => e.HasValue(c.Source.IdTipoContratacao)))));
            FieldAsync<ListGraphType<RendimentosPessoaType>>("rendimentosPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RendimentosPessoa>(x => x.Where(e => e.HasValue(c.Source.IdTipoContratacao)))));
            
        }
    }

    public class TipoContratacaoInputType : InputObjectGraphType
	{
		public TipoContratacaoInputType()
		{
			// Defining the name of the object
			Name = "tipoContratacaoInput";
			
            //Field<StringGraphType>("idTipoContratacao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoContratacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoPessoaId");
			Field<EstadoInputType>("estado");
			Field<TipoPessoaInputType>("tipoPessoa");
			Field<ListGraphType<PapelInputType>>("papel");
			Field<ListGraphType<RendimentosPessoaInputType>>("rendimentosPessoa");
			
		}
	}
}