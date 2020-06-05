using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NivelCompetenciaType : ObjectGraphType<NivelCompetencia>
    {
        public NivelCompetenciaType()
        {
            // Defining the name of the object
            Name = "nivelCompetencia";

            Field(x => x.IdNivelCompetencia, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodNivelCompetencia, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.FormaPagamentoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaPagamentoType>("formaPagamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaPagamento>(c.Source.FormaPagamentoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class NivelCompetenciaInputType : InputObjectGraphType
	{
		public NivelCompetenciaInputType()
		{
			// Defining the name of the object
			Name = "nivelCompetenciaInput";
			
            //Field<StringGraphType>("idNivelCompetencia");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codNivelCompetencia");
			Field<StringGraphType>("pessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("formaPagamentoId");
			Field<EstadoInputType>("estado");
			Field<FormaPagamentoInputType>("formaPagamento");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}