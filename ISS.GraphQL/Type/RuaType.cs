using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class RuaType : ObjectGraphType<Rua>
    {
        public RuaType()
        {
            // Defining the name of the object
            Name = "rua";

            Field(x => x.IdRua, nullable: true);
            Field(x => x.NomeRua, nullable: true);
            Field(x => x.CodRua, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.BairroId, nullable: true);
            FieldAsync<BairroType>("bairro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Bairro>(c.Source.BairroId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<EnderecoType>>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(x => x.Where(e => e.HasValue(c.Source.IdRua)))));
            
        }
    }

    public class RuaInputType : InputObjectGraphType
	{
		public RuaInputType()
		{
			// Defining the name of the object
			Name = "ruaInput";
			
            //Field<StringGraphType>("idRua");
			Field<StringGraphType>("nomeRua");
			Field<StringGraphType>("codRua");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("bairroId");
			Field<BairroInputType>("bairro");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<EnderecoInputType>>("endereco");
			
		}
	}
}