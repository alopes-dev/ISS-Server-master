using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PosType : ObjectGraphType<Pos>
    {
        public PosType()
        {
            // Defining the name of the object
            Name = "pos";

            Field(x => x.IdPos, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodPos, nullable: true);
            Field(x => x.NumPos, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ContaBancariaPosType>>("contaBancariaPos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContaBancariaPos>(x => x.Where(e => e.HasValue(c.Source.IdPos)))));
            FieldAsync<ListGraphType<InformacaoBancariaPosType>>("informacaoBancariaPos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<InformacaoBancariaPos>(x => x.Where(e => e.HasValue(c.Source.IdPos)))));
            FieldAsync<ListGraphType<PessoasPosType>>("pessoasPos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoasPos>(x => x.Where(e => e.HasValue(c.Source.IdPos)))));
            
        }
    }

    public class PosInputType : InputObjectGraphType
	{
		public PosInputType()
		{
			// Defining the name of the object
			Name = "posInput";
			
            //Field<StringGraphType>("idPos");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codPos");
			Field<StringGraphType>("numPos");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ContaBancariaPosInputType>>("contaBancariaPos");
			Field<ListGraphType<InformacaoBancariaPosInputType>>("informacaoBancariaPos");
			Field<ListGraphType<PessoasPosInputType>>("pessoasPos");
			
		}
	}
}