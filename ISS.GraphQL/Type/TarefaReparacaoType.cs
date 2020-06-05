using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TarefaReparacaoType : ObjectGraphType<TarefaReparacao>
    {
        public TarefaReparacaoType()
        {
            // Defining the name of the object
            Name = "tarefaReparacao";

            Field(x => x.IdTarefaReparacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.AutorizadaPorEngenheiro, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.AutorizadoPeloDono, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CategoriaLaboralId, nullable: true);
            Field(x => x.TipoTarefaReparacaoId, nullable: true);
            Field(x => x.ReparacaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<CategoriaLaboralType>("categoriaLaboral", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<CategoriaLaboral>(c.Source.CategoriaLaboralId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ReparacaoType>("reparacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Reparacao>(c.Source.ReparacaoId)));
            FieldAsync<TipoTarefaReparacaoType>("tipoTarefaReparacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoTarefaReparacao>(c.Source.TipoTarefaReparacaoId)));
            
        }
    }

    public class TarefaReparacaoInputType : InputObjectGraphType
	{
		public TarefaReparacaoInputType()
		{
			// Defining the name of the object
			Name = "tarefaReparacaoInput";
			
            //Field<StringGraphType>("idTarefaReparacao");
			Field<StringGraphType>("designacao");
			Field<BooleanGraphType>("autorizadaPorEngenheiro");
			Field<BooleanGraphType>("autorizadoPeloDono");
			Field<StringGraphType>("categoriaLaboralId");
			Field<StringGraphType>("tipoTarefaReparacaoId");
			Field<StringGraphType>("reparacaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<CategoriaLaboralInputType>("categoriaLaboral");
			Field<EstadoInputType>("estado");
			Field<ReparacaoInputType>("reparacao");
			Field<TipoTarefaReparacaoInputType>("tipoTarefaReparacao");
			
		}
	}
}