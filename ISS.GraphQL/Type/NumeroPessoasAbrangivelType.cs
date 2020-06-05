using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class NumeroPessoasAbrangivelType : ObjectGraphType<NumeroPessoasAbrangivel>
    {
        public NumeroPessoasAbrangivelType()
        {
            // Defining the name of the object
            Name = "numeroPessoasAbrangivel";

            Field(x => x.IdNumeroPessoasAbrangivel, nullable: true);
            Field(x => x.FormaContratacaoId, nullable: true);
            Field(x => x.CodNumeroPessoasAbrangivel, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.NumeroPessoasAbrangivel1, nullable: true);
            Field(x => x.NumeroMinPessoasAbrangidas, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.NumeroMaxPessoasAbrangidas, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Nota, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FormaContratacaoType>("formaContratacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<FormaContratacao>(c.Source.FormaContratacaoId)));
            
        }
    }

    public class NumeroPessoasAbrangivelInputType : InputObjectGraphType
	{
		public NumeroPessoasAbrangivelInputType()
		{
			// Defining the name of the object
			Name = "numeroPessoasAbrangivelInput";
			
            //Field<StringGraphType>("idNumeroPessoasAbrangivel");
			Field<StringGraphType>("formaContratacaoId");
			Field<StringGraphType>("codNumeroPessoasAbrangivel");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("numeroPessoasAbrangivel1");
			Field<FloatGraphType>("numeroMinPessoasAbrangidas");
			Field<FloatGraphType>("numeroMaxPessoasAbrangidas");
			Field<StringGraphType>("nota");
			Field<EstadoInputType>("estado");
			Field<FormaContratacaoInputType>("formaContratacao");
			
		}
	}
}