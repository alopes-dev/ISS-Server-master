using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LocalTrabalhoType : ObjectGraphType<LocalTrabalho>
    {
        public LocalTrabalhoType()
        {
            // Defining the name of the object
            Name = "localTrabalho";

            Field(x => x.IdLocalTrabalho, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodLocalTrabalho, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<LocalTrabalhoPessoaType>>("localTrabalhoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LocalTrabalhoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdLocalTrabalho)))));
            
        }
    }

    public class LocalTrabalhoInputType : InputObjectGraphType
	{
		public LocalTrabalhoInputType()
		{
			// Defining the name of the object
			Name = "localTrabalhoInput";
			
            //Field<StringGraphType>("idLocalTrabalho");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codLocalTrabalho");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<LocalTrabalhoPessoaInputType>>("localTrabalhoPessoa");
			
		}
	}
}