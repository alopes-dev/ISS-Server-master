using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoProdutorType : ObjectGraphType<TipoProdutor>
    {
        public TipoProdutorType()
        {
            // Defining the name of the object
            Name = "tipoProdutor";

            Field(x => x.IdTipoProdutor, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoProdutor, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PessoasPosType>>("pessoasPos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoasPos>(x => x.Where(e => e.HasValue(c.Source.IdTipoProdutor)))));
            
        }
    }

    public class TipoProdutorInputType : InputObjectGraphType
	{
		public TipoProdutorInputType()
		{
			// Defining the name of the object
			Name = "tipoProdutorInput";
			
            //Field<StringGraphType>("idTipoProdutor");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoProdutor");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PessoasPosInputType>>("pessoasPos");
			
		}
	}
}