using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoRegimeType : ObjectGraphType<TipoRegime>
    {
        public TipoRegimeType()
        {
            // Defining the name of the object
            Name = "tipoRegime";

            Field(x => x.IdTipoRegime, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PercentagemIva, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.TipoPessoaId, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ValorMin, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ValorMax, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.AtualizacaoCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodTipoRegime, nullable: true);
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<TipoPessoaType>("tipoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPessoa>(c.Source.TipoPessoaId)));
            
        }
    }

    public class TipoRegimeInputType : InputObjectGraphType
	{
		public TipoRegimeInputType()
		{
			// Defining the name of the object
			Name = "tipoRegimeInput";
			
            //Field<StringGraphType>("idTipoRegime");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("percentagemIva");
			Field<StringGraphType>("tipoPessoaId");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("valorMin");
			Field<FloatGraphType>("valorMax");
			Field<StringGraphType>("moedaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("atualizacaoCriacao");
			Field<StringGraphType>("codTipoRegime");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<TipoPessoaInputType>("tipoPessoa");
			
		}
	}
}