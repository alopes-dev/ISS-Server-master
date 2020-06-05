using GraphQL.Types;
using ISS.Application.Dto;
using ISS.GraphQL.Type;

namespace ISS.GraphQL
{
    public class CalculoModelType : ObjectGraphType<CalculoModel>
    {
        public CalculoModelType()
        {
            // Defining the name of the object
            Name = "calculoModel";

            Field(x => x.NumDiasApolice, nullable: true, type: typeof(IntGraphType));
            Field(x => x.NumUnidadesContratadas, nullable: true, type: typeof(IntGraphType));
            Field(x => x.CapitalSeguro, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioBase, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioRisco, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioComercial, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SinistroEsperado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EncargosAdministrativos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioBruto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioCobrado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Despesas, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Descontos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescontosPorIdade, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Ofertas, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Comissoes, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Encargos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.JurosFraccionamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Agravamentos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Impostos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Status, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Message, nullable: true);
            Field(x => x.AgravamentosPorIdade, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Cotacao, nullable: false, type: typeof(CotacaoType));

            Field(x => x.Pessoa, nullable: true, type: typeof(PessoaType));
            Field(x => x.PremiosFraccionado, nullable: true, type: typeof(ListGraphType<FraccionamentoModelType>));
            Field(x => x.AnaliseRisco, nullable: true, type: typeof(ListGraphType<CalculoModelType>));

            Field(x => x.OfertasDetalhe, nullable: true, type: typeof(ListGraphType<CalculoDetalheType>));
            Field(x => x.DespesasDetalhe, nullable: true, type: typeof(ListGraphType<CalculoDetalheType>));
            Field(x => x.ImpostosDetalhe, nullable: true, type: typeof(ListGraphType<CalculoDetalheType>));
            Field(x => x.ComissoesDetalhe, nullable: true, type: typeof(ListGraphType<CalculoDetalheType>));
            Field(x => x.DescontosDetalhe, nullable: true, type: typeof(ListGraphType<CalculoDetalheType>));
            Field(x => x.AgravamentosDetalhe, nullable: true, type: typeof(ListGraphType<CalculoDetalheType>));
            Field(x => x.DescontosPorIdadeDetalhe, nullable: true, type: typeof(ListGraphType<CalculoDetalheType>));
            Field(x => x.AgravamentosPorIdadeDetalhe, nullable: true, type: typeof(ListGraphType<CalculoDetalheType>));
            Field(x => x.EncargosAdministrativosDetalhe, nullable: true, type: typeof(ListGraphType<CalculoDetalheType>));
            Field(x => x.EncargosDetalhe, nullable: true, type: typeof(ListGraphType<CalculoDetalheType>));
            Field(x => x.Transacoes, nullable: true, type: typeof(ListGraphType<MovimentoType>));
        }
    }

}