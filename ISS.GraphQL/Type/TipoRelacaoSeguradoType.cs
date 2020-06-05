using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoRelacaoSeguradoType : ObjectGraphType<TipoRelacaoSegurado>
    {
        public TipoRelacaoSeguradoType()
        {
            // Defining the name of the object
            Name = "tipoRelacaoSegurado";

            Field(x => x.IdTipo, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoRelacaoSegurado, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<LesadoType>>("lesado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Lesado>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<PacienteType>>("paciente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Paciente>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<TerceiroType>>("terceiro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Terceiro>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            FieldAsync<ListGraphType<TestemunhaType>>("testemunha", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Testemunha>(x => x.Where(e => e.HasValue(c.Source.IdTipo)))));
            
        }
    }

    public class TipoRelacaoSeguradoInputType : InputObjectGraphType
	{
		public TipoRelacaoSeguradoInputType()
		{
			// Defining the name of the object
			Name = "tipoRelacaoSeguradoInput";
			
            //Field<StringGraphType>("idTipo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoRelacaoSegurado");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<LesadoInputType>>("lesado");
			Field<ListGraphType<PacienteInputType>>("paciente");
			Field<ListGraphType<TerceiroInputType>>("terceiro");
			Field<ListGraphType<TestemunhaInputType>>("testemunha");
			
		}
	}
}