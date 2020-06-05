using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ObservacoesBoletimAdesaoType : ObjectGraphType<ObservacoesBoletimAdesao>
    {
        public ObservacoesBoletimAdesaoType()
        {
            // Defining the name of the object
            Name = "observacoesBoletimAdesao";

            Field(x => x.IdObservacoesBoletimAdesao, nullable: true);
            Field(x => x.Observacao, nullable: true);
            Field(x => x.Aprovado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.IntroduzidoPor, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodObservacoesBoletimAdesao, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("introduzidoPorNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.IntroduzidoPor)));
            FieldAsync<ListGraphType<BoletimAdesaoSaudeType>>("boletimAdesaoSaude", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<BoletimAdesaoSaude>(x => x.Where(e => e.HasValue(c.Source.IdObservacoesBoletimAdesao)))));
            
        }
    }

    public class ObservacoesBoletimAdesaoInputType : InputObjectGraphType
	{
		public ObservacoesBoletimAdesaoInputType()
		{
			// Defining the name of the object
			Name = "observacoesBoletimAdesaoInput";
			
            //Field<StringGraphType>("idObservacoesBoletimAdesao");
			Field<StringGraphType>("observacao");
			Field<BooleanGraphType>("aprovado");
			Field<StringGraphType>("introduzidoPor");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codObservacoesBoletimAdesao");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("introduzidoPorNavigation");
			Field<ListGraphType<BoletimAdesaoSaudeInputType>>("boletimAdesaoSaude");
			
		}
	}
}