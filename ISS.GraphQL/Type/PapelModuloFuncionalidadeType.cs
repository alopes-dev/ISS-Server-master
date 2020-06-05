using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PapelModuloFuncionalidadeType : ObjectGraphType<PapelModuloFuncionalidade>
    {
        public PapelModuloFuncionalidadeType()
        {
            // Defining the name of the object
            Name = "papelModuloFuncionalidade";

            Field(x => x.IdPapelModuloFuncionalidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.FuncionalidadeId, nullable: true);
            Field(x => x.PapelModuloPessoaId, nullable: true);
            Field(x => x.CodPapelModuloFuncionalidade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FuncionalidadeType>("funcionalidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionalidade>(c.Source.FuncionalidadeId)));
            FieldAsync<PapelModuloPessoaType>("papelModuloPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelModuloPessoa>(c.Source.PapelModuloPessoaId)));
            FieldAsync<ListGraphType<ProcessoFuncionalidadeType>>("processoFuncionalidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ProcessoFuncionalidade>(x => x.Where(e => e.HasValue(c.Source.IdPapelModuloFuncionalidade)))));
            
        }
    }

    public class PapelModuloFuncionalidadeInputType : InputObjectGraphType
	{
		public PapelModuloFuncionalidadeInputType()
		{
			// Defining the name of the object
			Name = "papelModuloFuncionalidadeInput";
			
            //Field<StringGraphType>("idPapelModuloFuncionalidade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("funcionalidadeId");
			Field<StringGraphType>("papelModuloPessoaId");
			Field<StringGraphType>("codPapelModuloFuncionalidade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<FuncionalidadeInputType>("funcionalidade");
			Field<PapelModuloPessoaInputType>("papelModuloPessoa");
			Field<ListGraphType<ProcessoFuncionalidadeInputType>>("processoFuncionalidade");
			
		}
	}
}