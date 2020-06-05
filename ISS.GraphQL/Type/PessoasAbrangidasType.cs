using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PessoasAbrangidasType : ObjectGraphType<PessoasAbrangidas>
    {
        public PessoasAbrangidasType()
        {
            // Defining the name of the object
            Name = "pessoasAbrangidas";

            Field(x => x.IdPessoaAbrangida, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodPessoasAbrangidas, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CotacaoType>>("cotacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cotacao>(x => x.Where(e => e.HasValue(c.Source.IdPessoaAbrangida)))));
            
        }
    }

    public class PessoasAbrangidasInputType : InputObjectGraphType
	{
		public PessoasAbrangidasInputType()
		{
			// Defining the name of the object
			Name = "pessoasAbrangidasInput";
			
            //Field<StringGraphType>("idPessoaAbrangida");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codPessoasAbrangidas");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CotacaoInputType>>("cotacao");
			
		}
	}
}