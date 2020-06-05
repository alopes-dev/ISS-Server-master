using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AutorizacaoType : ObjectGraphType<Autorizacao>
    {
        public AutorizacaoType()
        {
            // Defining the name of the object
            Name = "autorizacao";

            Field(x => x.IdAutorizacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.AutorizacaoConcedida, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CondicacaoAutorizaca, nullable: true);
            Field(x => x.DataDecisaoAutorizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.MeioAutorizacaoId, nullable: true);
            Field(x => x.DataHora, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.InformacaoAdicional, nullable: true);
            Field(x => x.MaximoValorMonetarioAutorizado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.AutorizadorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodAutorizacao, nullable: true);
            FieldAsync<PessoaType>("autorizador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.AutorizadorId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<MeioAutorizacaoType>("meioAutorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<MeioAutorizacao>(c.Source.MeioAutorizacaoId)));
            FieldAsync<ListGraphType<ReparacaoType>>("reparacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Reparacao>(x => x.Where(e => e.HasValue(c.Source.IdAutorizacao)))));
            
        }
    }

    public class AutorizacaoInputType : InputObjectGraphType
	{
		public AutorizacaoInputType()
		{
			// Defining the name of the object
			Name = "autorizacaoInput";
			
            //Field<StringGraphType>("idAutorizacao");
			Field<StringGraphType>("designacao");
			Field<BooleanGraphType>("autorizacaoConcedida");
			Field<StringGraphType>("condicacaoAutorizaca");
			Field<DateTimeGraphType>("dataDecisaoAutorizacao");
			Field<StringGraphType>("meioAutorizacaoId");
			Field<DateTimeGraphType>("dataHora");
			Field<StringGraphType>("informacaoAdicional");
			Field<FloatGraphType>("maximoValorMonetarioAutorizado");
			Field<StringGraphType>("autorizadorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codAutorizacao");
			Field<PessoaInputType>("autorizador");
			Field<EstadoInputType>("estado");
			Field<MeioAutorizacaoInputType>("meioAutorizacao");
			Field<ListGraphType<ReparacaoInputType>>("reparacao");
			
		}
	}
}