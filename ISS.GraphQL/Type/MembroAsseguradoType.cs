using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MembroAsseguradoType : ObjectGraphType<MembroAssegurado>
    {
        public MembroAsseguradoType()
        {
            // Defining the name of the object
            Name = "membroAssegurado";

            Field(x => x.IdMembroAssegurado, nullable: true);
            Field(x => x.CotacaoId, nullable: true);
            Field(x => x.ValorPremio, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.DescontoId, nullable: true);
            Field(x => x.PremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EncargoAdministrativo, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioComercial, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CapitalSeguro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioBase, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioRisco, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioCobrado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescontosPorIdade, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.AgravamentosPorIdade, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Agravamentos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SinistroEsperado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Despesas, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Arseg, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Descontos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Ofertas, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Impostos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Iva, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.ProfissaoId, nullable: true);
            Field(x => x.SalarioBaseMensal, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SubSidioAlimentacaoMensal, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.OutrosRendimentos, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CotacaoType>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(c.Source.CotacaoId)));
            FieldAsync<DescontoType>("desconto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Desconto>(c.Source.DescontoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PessoaProfissaoType>("profissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(c.Source.ProfissaoId)));
            FieldAsync<ListGraphType<DocumentoMembroAsseguradoType>>("documentoMembroAssegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DocumentoMembroAssegurado>(x => x.Where(e => e.HasValue(c.Source.IdMembroAssegurado)))));
            
        }
    }

    public class MembroAsseguradoInputType : InputObjectGraphType
	{
		public MembroAsseguradoInputType()
		{
			// Defining the name of the object
			Name = "membroAsseguradoInput";
			
            //Field<StringGraphType>("idMembroAssegurado");
			Field<StringGraphType>("cotacaoId");
			Field<FloatGraphType>("valorPremio");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("descontoId");
			Field<FloatGraphType>("premioSimples");
			Field<FloatGraphType>("encargoAdministrativo");
			Field<FloatGraphType>("premioComercial");
			Field<FloatGraphType>("capitalSeguro");
			Field<FloatGraphType>("premioBase");
			Field<FloatGraphType>("premioRisco");
			Field<FloatGraphType>("premioCobrado");
			Field<FloatGraphType>("descontosPorIdade");
			Field<FloatGraphType>("agravamentosPorIdade");
			Field<FloatGraphType>("agravamentos");
			Field<FloatGraphType>("sinistroEsperado");
			Field<FloatGraphType>("despesas");
			Field<FloatGraphType>("arseg");
			Field<FloatGraphType>("descontos");
			Field<FloatGraphType>("ofertas");
			Field<FloatGraphType>("impostos");
			Field<FloatGraphType>("iva");
			Field<StringGraphType>("profissaoId");
			Field<FloatGraphType>("salarioBaseMensal");
			Field<FloatGraphType>("subSidioAlimentacaoMensal");
			Field<FloatGraphType>("outrosRendimentos");
			Field<ApoliceInputType>("apolice");
			Field<CotacaoInputType>("cotacao");
			Field<DescontoInputType>("desconto");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<PessoaProfissaoInputType>("profissao");
			Field<ListGraphType<DocumentoMembroAsseguradoInputType>>("documentoMembroAssegurado");
			
		}
	}
}