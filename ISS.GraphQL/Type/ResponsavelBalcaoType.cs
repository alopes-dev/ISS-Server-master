using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ResponsavelBalcaoType : ObjectGraphType<ResponsavelBalcao>
    {
        public ResponsavelBalcaoType()
        {
            // Defining the name of the object
            Name = "responsavelBalcao";

            Field(x => x.IdResponsavelBalcao, nullable: true);
            Field(x => x.ResponsavelId, nullable: true);
            Field(x => x.BalcaoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<BalcaoType>("balcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Balcao>(c.Source.BalcaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FuncionarioType>("responsavel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.ResponsavelId)));
            
        }
    }

    public class ResponsavelBalcaoInputType : InputObjectGraphType
	{
		public ResponsavelBalcaoInputType()
		{
			// Defining the name of the object
			Name = "responsavelBalcaoInput";
			
            //Field<StringGraphType>("idResponsavelBalcao");
			Field<StringGraphType>("responsavelId");
			Field<StringGraphType>("balcaoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<BalcaoInputType>("balcao");
			Field<EstadoInputType>("estado");
			Field<FuncionarioInputType>("responsavel");
			
		}
	}
}