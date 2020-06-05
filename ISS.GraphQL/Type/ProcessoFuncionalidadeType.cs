using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ProcessoFuncionalidadeType : ObjectGraphType<ProcessoFuncionalidade>
    {
        public ProcessoFuncionalidadeType()
        {
            // Defining the name of the object
            Name = "processoFuncionalidade";

            Field(x => x.IdFuncionalidade, nullable: true);
            Field(x => x.ProcessoId, nullable: true);
            Field(x => x.PapelModuloFuncionalidadeId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodProcessoFuncionalidade, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PapelModuloFuncionalidadeType>("papelModuloFuncionalidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelModuloFuncionalidade>(c.Source.PapelModuloFuncionalidadeId)));
            FieldAsync<ProcessoType>("processo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Processo>(c.Source.ProcessoId)));
            FieldAsync<ListGraphType<TipoOperacaoProcessoType>>("tipoOperacaoProcesso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoOperacaoProcesso>(x => x.Where(e => e.HasValue(c.Source.IdFuncionalidade)))));
            
        }
    }

    public class ProcessoFuncionalidadeInputType : InputObjectGraphType
	{
		public ProcessoFuncionalidadeInputType()
		{
			// Defining the name of the object
			Name = "processoFuncionalidadeInput";
			
            //Field<StringGraphType>("idFuncionalidade");
			Field<StringGraphType>("processoId");
			Field<StringGraphType>("papelModuloFuncionalidadeId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codProcessoFuncionalidade");
			Field<EstadoInputType>("estado");
			Field<PapelModuloFuncionalidadeInputType>("papelModuloFuncionalidade");
			Field<ProcessoInputType>("processo");
			Field<ListGraphType<TipoOperacaoProcessoInputType>>("tipoOperacaoProcesso");
			
		}
	}
}