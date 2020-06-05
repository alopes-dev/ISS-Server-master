using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CodigoResponsabilidadeType : ObjectGraphType<CodigoResponsabilidade>
    {
        public CodigoResponsabilidadeType()
        {
            // Defining the name of the object
            Name = "codigoResponsabilidade";

            Field(x => x.IdCodigoResponsabilidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ReclamacaoType>>("reclamacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Reclamacao>(x => x.Where(e => e.HasValue(c.Source.IdCodigoResponsabilidade)))));
            
        }
    }

    public class CodigoResponsabilidadeInputType : InputObjectGraphType
	{
		public CodigoResponsabilidadeInputType()
		{
			// Defining the name of the object
			Name = "codigoResponsabilidadeInput";
			
            //Field<StringGraphType>("idCodigoResponsabilidade");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ReclamacaoInputType>>("reclamacao");
			
		}
	}
}