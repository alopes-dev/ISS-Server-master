using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ExcedenteType : ObjectGraphType<Excedente>
    {
        public ExcedenteType()
        {
            // Defining the name of the object
            Name = "excedente";

            Field(x => x.IdExcedente, nullable: true);
            Field(x => x.Cedencia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ComissaoId, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.MoedaId, nullable: true);
            Field(x => x.ValorLiquido, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.EntidadeId, nullable: true);
            FieldAsync<ComissaoType>("comissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissao>(c.Source.ComissaoId)));
            FieldAsync<PessoaType>("entidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.EntidadeId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MoedaType>("moeda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.MoedaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class ExcedenteInputType : InputObjectGraphType
	{
		public ExcedenteInputType()
		{
			// Defining the name of the object
			Name = "excedenteInput";
			
            //Field<StringGraphType>("idExcedente");
			Field<FloatGraphType>("cedencia");
			Field<StringGraphType>("comissaoId");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("moedaId");
			Field<FloatGraphType>("valorLiquido");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("entidadeId");
			Field<ComissaoInputType>("comissao");
			Field<PessoaInputType>("entidade");
			Field<EstadoInputType>("estado");
			Field<MoedaInputType>("moeda");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}