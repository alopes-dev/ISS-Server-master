using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HabilitacoesLiterariasType : ObjectGraphType<HabilitacoesLiterarias>
    {
        public HabilitacoesLiterariasType()
        {
            // Defining the name of the object
            Name = "habilitacoesLiterarias";

            Field(x => x.IdHabilitacoesLiterarias, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodHabilitacoesLiterarias, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<HabilitacoesLiterariasPessoaType>>("habilitacoesLiterariasPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HabilitacoesLiterariasPessoa>(x => x.Where(e => e.HasValue(c.Source.IdHabilitacoesLiterarias)))));
            
        }
    }

    public class HabilitacoesLiterariasInputType : InputObjectGraphType
	{
		public HabilitacoesLiterariasInputType()
		{
			// Defining the name of the object
			Name = "habilitacoesLiterariasInput";
			
            //Field<StringGraphType>("idHabilitacoesLiterarias");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codHabilitacoesLiterarias");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<HabilitacoesLiterariasPessoaInputType>>("habilitacoesLiterariasPessoa");
			
		}
	}
}