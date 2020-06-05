using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CarteiraClienteType : ObjectGraphType<CarteiraCliente>
    {
        public CarteiraClienteType()
        {
            // Defining the name of the object
            Name = "carteiraCliente";

            Field(x => x.IdCarteiraClinte, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            Field(x => x.CodCarteira, nullable: true);
            Field(x => x.TomadorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.MontanteMin, nullable: true, type: typeof(FloatGraphType));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            FieldAsync<PessoaType>("tomador", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.TomadorId)));
            
        }
    }

    public class CarteiraClienteInputType : InputObjectGraphType
	{
		public CarteiraClienteInputType()
		{
			// Defining the name of the object
			Name = "carteiraClienteInput";
			
            //Field<StringGraphType>("idCarteiraClinte");
			Field<StringGraphType>("produtorId");
			Field<StringGraphType>("codCarteira");
			Field<StringGraphType>("tomadorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<FloatGraphType>("montanteMin");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("produtor");
			Field<PessoaInputType>("tomador");
			
		}
	}
}