using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ObjectoEnvolvidoType : ObjectGraphType<ObjectoEnvolvido>
    {
        public ObjectoEnvolvidoType()
        {
            // Defining the name of the object
            Name = "objectoEnvolvido";

            Field(x => x.IdObjectoEnvolvido, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.AvaliacaoValor, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.InicioPontoEmbate, nullable: true);
            Field(x => x.DanosVisiveis, nullable: true);
            Field(x => x.TipoObjectoEnvolvidoId, nullable: true);
            Field(x => x.AutomovelId, nullable: true);
            Field(x => x.ConstrucaoId, nullable: true);
            Field(x => x.DonoId, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.DetalheCircunstancia, nullable: true);
            Field(x => x.Proprio, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.QuestionarioId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CondutorSinistroId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodObjectoEnvolvido, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            FieldAsync<PessoaType>("condutorSinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.CondutorSinistroId)));
            FieldAsync<ConstrucaoType>("construcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Construcao>(c.Source.ConstrucaoId)));
            FieldAsync<PessoaType>("dono", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.DonoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<QuestionarioType>("questionario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Questionario>(c.Source.QuestionarioId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            FieldAsync<TipoObjectoEnvolvidoType>("tipoObjectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoObjectoEnvolvido>(c.Source.TipoObjectoEnvolvidoId)));
            FieldAsync<ListGraphType<CircunstanciaObjectoEnvolvidoType>>("circunstanciaObjectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CircunstanciaObjectoEnvolvido>(x => x.Where(e => e.HasValue(c.Source.IdObjectoEnvolvido)))));
            FieldAsync<ListGraphType<DocumentosObjectoEnvolvidoType>>("documentosObjectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentosObjectoEnvolvido>(x => x.Where(e => e.HasValue(c.Source.IdObjectoEnvolvido)))));
            FieldAsync<ListGraphType<FotografiasObjectoEnvolvidoType>>("fotografiasObjectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FotografiasObjectoEnvolvido>(x => x.Where(e => e.HasValue(c.Source.IdObjectoEnvolvido)))));
            FieldAsync<ListGraphType<ReparacaoType>>("reparacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Reparacao>(x => x.Where(e => e.HasValue(c.Source.IdObjectoEnvolvido)))));
            
        }
    }

    public class ObjectoEnvolvidoInputType : InputObjectGraphType
	{
		public ObjectoEnvolvidoInputType()
		{
			// Defining the name of the object
			Name = "objectoEnvolvidoInput";
			
            //Field<StringGraphType>("idObjectoEnvolvido");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("avaliacaoValor");
			Field<StringGraphType>("inicioPontoEmbate");
			Field<StringGraphType>("danosVisiveis");
			Field<StringGraphType>("tipoObjectoEnvolvidoId");
			Field<StringGraphType>("automovelId");
			Field<StringGraphType>("construcaoId");
			Field<StringGraphType>("donoId");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("detalheCircunstancia");
			Field<BooleanGraphType>("proprio");
			Field<StringGraphType>("questionarioId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("condutorSinistroId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codObjectoEnvolvido");
			Field<AutomovelInputType>("automovel");
			Field<PessoaInputType>("condutorSinistro");
			Field<ConstrucaoInputType>("construcao");
			Field<PessoaInputType>("dono");
			Field<EstadoInputType>("estado");
			Field<QuestionarioInputType>("questionario");
			Field<SinistroInputType>("sinistro");
			Field<TipoObjectoEnvolvidoInputType>("tipoObjectoEnvolvido");
			Field<ListGraphType<CircunstanciaObjectoEnvolvidoInputType>>("circunstanciaObjectoEnvolvido");
			Field<ListGraphType<DocumentosObjectoEnvolvidoInputType>>("documentosObjectoEnvolvido");
			Field<ListGraphType<FotografiasObjectoEnvolvidoInputType>>("fotografiasObjectoEnvolvido");
			Field<ListGraphType<ReparacaoInputType>>("reparacao");
			
		}
	}
}