using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ObjectoTrabalhoType : ObjectGraphType<ObjectoTrabalho>
    {
        public ObjectoTrabalhoType()
        {
            // Defining the name of the object
            Name = "objectoTrabalho";

            Field(x => x.IdObjectoTrabalho, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodObjectoTrabalho, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ObjectoTrabalhoPessoaType>>("objectoTrabalhoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoTrabalhoPessoa>(x => x.Where(e => e.HasValue(c.Source.IdObjectoTrabalho)))));
            
        }
    }

    public class ObjectoTrabalhoInputType : InputObjectGraphType
	{
		public ObjectoTrabalhoInputType()
		{
			// Defining the name of the object
			Name = "objectoTrabalhoInput";
			
            //Field<StringGraphType>("idObjectoTrabalho");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codObjectoTrabalho");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ObjectoTrabalhoPessoaInputType>>("objectoTrabalhoPessoa");
			
		}
	}
}