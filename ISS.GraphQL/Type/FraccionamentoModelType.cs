using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL
{
    public class FraccionamentoModelType : ObjectGraphType<FraccionamentoModel>
    {
        public FraccionamentoModelType()
        {
            // Defining the name of the object
            Name = "fraccionamentoModel";

            Field(x => x.Fraccionamento, nullable: true);
            Field(x => x.FraccionamentoId, nullable: true);
            Field(x => x.Taxa, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioBase, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioRisco, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioSimples, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioComercial, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.SinistroEsperado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.EncargosAdminstrativos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Encargos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.JurosFraccionamento, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioBruto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PremioCobrado, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Despesas, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Descontos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescontosPorIdade, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Ofertas, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Comissoes, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Agravamentos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.AgravamentosPorIdade, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Impostos, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Iva, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Arseg, nullable: true, type: typeof(FloatGraphType));
            
        }
    }

    public class FraccionamentoModelInputType : InputObjectGraphType
	{
		public FraccionamentoModelInputType()
		{
			// Defining the name of the object
			Name = "fraccionamentoModelInput";
			
            Field<StringGraphType>("fraccionamento");
			Field<StringGraphType>("fraccionamentoId");
			Field<FloatGraphType>("taxa");
			Field<FloatGraphType>("premioBase");
			Field<FloatGraphType>("premioRisco");
			Field<FloatGraphType>("premioSimples");
			Field<FloatGraphType>("premioComercial");
			Field<FloatGraphType>("sinistroEsperado");
			Field<FloatGraphType>("encargosAdminstrativos");
			Field<FloatGraphType>("premioBruto");
			Field<FloatGraphType>("premioCobrado");
			Field<FloatGraphType>("despesas");
			Field<FloatGraphType>("descontos");
			Field<FloatGraphType>("descontosPorIdade");
			Field<FloatGraphType>("ofertas");
			Field<FloatGraphType>("comissoes");
			Field<FloatGraphType>("agravamentos");
			Field<FloatGraphType>("agravamentosPorIdade");
			Field<FloatGraphType>("impostos");
			Field<FloatGraphType>("iva");
			Field<FloatGraphType>("arseg");
			
		}
	}
}