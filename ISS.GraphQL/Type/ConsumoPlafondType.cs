using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ConsumoPlafondType : ObjectGraphType<ConsumoPlafond>
    {
        public ConsumoPlafondType()
        {
            // Defining the name of the object
            Name = "consumoPlafond";

            Field(x => x.IdConsumoPlafond, nullable: true);
            Field(x => x.DataValor, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataMovimento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ValorConsumido, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.CoberturaComplementarSeleccionadaId, nullable: true);
            Field(x => x.CoberturaSeleccionadaId, nullable: true);
            Field(x => x.FornecedorId, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodConsumoPlafond, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<CoberturaSelecionadaType>("coberturaSeleccionada", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CoberturaSelecionada>(c.Source.CoberturaSeleccionadaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("fornecedor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.FornecedorId)));
            
        }
    }

    public class ConsumoPlafondInputType : InputObjectGraphType
	{
		public ConsumoPlafondInputType()
		{
			// Defining the name of the object
			Name = "consumoPlafondInput";
			
            //Field<StringGraphType>("idConsumoPlafond");
			Field<DateTimeGraphType>("dataValor");
			Field<DateTimeGraphType>("dataMovimento");
			Field<FloatGraphType>("valorConsumido");
			Field<StringGraphType>("coberturaComplementarSeleccionadaId");
			Field<StringGraphType>("coberturaSeleccionadaId");
			Field<StringGraphType>("fornecedorId");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codConsumoPlafond");
			Field<ApoliceInputType>("apolice");
			Field<CoberturaSelecionadaInputType>("coberturaSeleccionada");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("fornecedor");
			
		}
	}
}