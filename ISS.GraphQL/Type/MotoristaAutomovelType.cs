using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MotoristaAutomovelType : ObjectGraphType<MotoristaAutomovel>
    {
        public MotoristaAutomovelType()
        {
            // Defining the name of the object
            Name = "motoristaAutomovel";

            Field(x => x.IdMotoristaAutomovel, nullable: true);
            Field(x => x.MotoristaId, nullable: true);
            Field(x => x.AutomovelId, nullable: true);
            Field(x => x.Principal, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodMotoristaAutomovel, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("motorista", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.MotoristaId)));
            
        }
    }

    public class MotoristaAutomovelInputType : InputObjectGraphType
	{
		public MotoristaAutomovelInputType()
		{
			// Defining the name of the object
			Name = "motoristaAutomovelInput";
			
            //Field<StringGraphType>("idMotoristaAutomovel");
			Field<StringGraphType>("motoristaId");
			Field<StringGraphType>("automovelId");
			Field<BooleanGraphType>("principal");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codMotoristaAutomovel");
			Field<AutomovelInputType>("automovel");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("motorista");
			
		}
	}
}