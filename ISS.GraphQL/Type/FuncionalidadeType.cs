using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class FuncionalidadeType : ObjectGraphType<Funcionalidade>
    {
        public FuncionalidadeType()
        {
            // Defining the name of the object
            Name = "funcionalidade";

            Field(x => x.IdFuncionalidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodFuncionalidade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PapelModuloFuncionalidadeType>>("papelModuloFuncionalidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelModuloFuncionalidade>(x => x.Where(e => e.HasValue(c.Source.IdFuncionalidade)))));
            
        }
    }

    public class FuncionalidadeInputType : InputObjectGraphType
	{
		public FuncionalidadeInputType()
		{
			// Defining the name of the object
			Name = "funcionalidadeInput";
			
            //Field<StringGraphType>("idFuncionalidade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codFuncionalidade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PapelModuloFuncionalidadeInputType>>("papelModuloFuncionalidade");
			
		}
	}
}