using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TerceiroType : ObjectGraphType<Terceiro>
    {
        public TerceiroType()
        {
            // Defining the name of the object
            Name = "terceiro";

            Field(x => x.IdTerceiro, nullable: true);
            Field(x => x.TipoRelacaoSeguradoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.ValorEstimado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodTerceiro, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            FieldAsync<TipoRelacaoSeguradoType>("tipoRelacaoSegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRelacaoSegurado>(c.Source.TipoRelacaoSeguradoId)));
            
        }
    }

    public class TerceiroInputType : InputObjectGraphType
	{
		public TerceiroInputType()
		{
			// Defining the name of the object
			Name = "terceiroInput";
			
            //Field<StringGraphType>("idTerceiro");
			Field<StringGraphType>("tipoRelacaoSeguradoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("sinistroId");
			Field<FloatGraphType>("valorEstimado");
			Field<StringGraphType>("moedaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codTerceiro");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<PessoaInputType>("pessoa");
			Field<SinistroInputType>("sinistro");
			Field<TipoRelacaoSeguradoInputType>("tipoRelacaoSegurado");
			
		}
	}
}