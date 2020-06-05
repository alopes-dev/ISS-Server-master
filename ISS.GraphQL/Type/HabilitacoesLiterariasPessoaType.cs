using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HabilitacoesLiterariasPessoaType : ObjectGraphType<HabilitacoesLiterariasPessoa>
    {
        public HabilitacoesLiterariasPessoaType()
        {
            // Defining the name of the object
            Name = "habilitacoesLiterariasPessoa";

            Field(x => x.IdHabilitacoesLiterariasPessoa, nullable: true);
            Field(x => x.HabilitacoesLiterariasId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CursoId, nullable: true);
            Field(x => x.DataInicioHabilitacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFimHabilitacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodHabilitacoesLiterariasPessoa, nullable: true);
            FieldAsync<FaculdadeCursoType>("curso", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FaculdadeCurso>(c.Source.CursoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<HabilitacoesLiterariasType>("habilitacoesLiterarias", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HabilitacoesLiterarias>(c.Source.HabilitacoesLiterariasId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class HabilitacoesLiterariasPessoaInputType : InputObjectGraphType
	{
		public HabilitacoesLiterariasPessoaInputType()
		{
			// Defining the name of the object
			Name = "habilitacoesLiterariasPessoaInput";
			
            //Field<StringGraphType>("idHabilitacoesLiterariasPessoa");
			Field<StringGraphType>("habilitacoesLiterariasId");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("cursoId");
			Field<DateTimeGraphType>("dataInicioHabilitacao");
			Field<DateTimeGraphType>("dataFimHabilitacao");
			Field<StringGraphType>("codHabilitacoesLiterariasPessoa");
			Field<FaculdadeCursoInputType>("curso");
			Field<EstadoInputType>("estado");
			Field<HabilitacoesLiterariasInputType>("habilitacoesLiterarias");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}