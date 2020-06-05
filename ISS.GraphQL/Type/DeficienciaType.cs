using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DeficienciaType : ObjectGraphType<Deficiencia>
    {
        public DeficienciaType()
        {
            // Defining the name of the object
            Name = "deficiencia";

            Field(x => x.IdDeficiencia, nullable: true);
            Field(x => x.Descricao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodDeficiencia, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdDeficiencia)))));
            
        }
    }

    public class DeficienciaInputType : InputObjectGraphType
	{
		public DeficienciaInputType()
		{
			// Defining the name of the object
			Name = "deficienciaInput";
			
            //Field<StringGraphType>("idDeficiencia");
			Field<StringGraphType>("descricao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codDeficiencia");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PessoaInputType>>("pessoa");
			
		}
	}
}