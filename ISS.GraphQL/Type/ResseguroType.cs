using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ResseguroType : ObjectGraphType<Resseguro>
    {
        public ResseguroType()
        {
            // Defining the name of the object
            Name = "resseguro";

            Field(x => x.IdResseguro, nullable: true);
            Field(x => x.CapitalSeguro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Premio, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ResseguradorId, nullable: true);
            Field(x => x.MediadorId, nullable: true);
            Field(x => x.TipoResseguroId, nullable: true);
            Field(x => x.LinhaProdutoId, nullable: true);
            Field(x => x.SeguradoraDirectaId, nullable: true);
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataExpiracao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CodResseguro, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.NotaId, nullable: true);
            Field(x => x.TarefaId, nullable: true);
            Field(x => x.ValorLiquido, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.FormaResseguroId, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.Cedencia, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Comissao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Snistros, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            FieldAsync<ListGraphType<CoberturaResseguroType>>("coberturaResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaResseguro>(x => x.Where(e => e.HasValue(c.Source.IdResseguro)))));
            FieldAsync<ListGraphType<ComissaoResseguroType>>("comissaoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ComissaoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdResseguro)))));
            FieldAsync<ListGraphType<CondicoesReSeguroType>>("condicoesReSeguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CondicoesReSeguro>(x => x.Where(e => e.HasValue(c.Source.IdResseguro)))));
            FieldAsync<ListGraphType<ContratoResseguroType>>("contratoResseguro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoResseguro>(x => x.Where(e => e.HasValue(c.Source.IdResseguro)))));
            FieldAsync<ListGraphType<ExcessoPerdaType>>("excessoPerda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ExcessoPerda>(x => x.Where(e => e.HasValue(c.Source.IdResseguro)))));
            FieldAsync<ListGraphType<SubscricaoCessaoRetencaoType>>("subscricaoCessaoRetencao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<SubscricaoCessaoRetencao>(x => x.Where(e => e.HasValue(c.Source.IdResseguro)))));
            
        }
    }

    public class ResseguroInputType : InputObjectGraphType
	{
		public ResseguroInputType()
		{
			// Defining the name of the object
			Name = "resseguroInput";
			
            //Field<StringGraphType>("idResseguro");
			Field<FloatGraphType>("capitalSeguro");
			Field<FloatGraphType>("premio");
			Field<StringGraphType>("resseguradorId");
			Field<StringGraphType>("mediadorId");
			Field<StringGraphType>("tipoResseguroId");
			Field<StringGraphType>("linhaProdutoId");
			Field<StringGraphType>("seguradoraDirectaId");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataExpiracao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("codResseguro");
			Field<DateTimeGraphType>("ultModificacaoPorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("notaId");
			Field<StringGraphType>("tarefaId");
			Field<FloatGraphType>("valorLiquido");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("formaResseguroId");
			Field<StringGraphType>("contratoId");
			Field<FloatGraphType>("cedencia");
			Field<FloatGraphType>("comissao");
			Field<FloatGraphType>("snistros");
			Field<SinistroInputType>("sinistro");
			Field<ListGraphType<CoberturaResseguroInputType>>("coberturaResseguro");
			Field<ListGraphType<ComissaoResseguroInputType>>("comissaoResseguro");
			Field<ListGraphType<CondicoesReSeguroInputType>>("condicoesReSeguro");
			Field<ListGraphType<ContratoResseguroInputType>>("contratoResseguro");
			Field<ListGraphType<ExcessoPerdaInputType>>("excessoPerda");
			Field<ListGraphType<SubscricaoCessaoRetencaoInputType>>("subscricaoCessaoRetencao");
			
		}
	}
}