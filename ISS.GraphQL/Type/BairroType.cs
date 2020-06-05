using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class BairroType : ObjectGraphType<Bairro>
    {
        public BairroType()
        {
            // Defining the name of the object
            Name = "bairro";

            Field(x => x.IdBairro, nullable: true);
            Field(x => x.NomeBairro, nullable: true);
            Field(x => x.DistritoId, nullable: true);
            Field(x => x.CodBairro, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<DistritoType>("distrito", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Distrito>(c.Source.DistritoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<ComunaType>>("comuna", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comuna>(x => x.Where(e => e.HasValue(c.Source.IdBairro)))));
            FieldAsync<ListGraphType<EnderecoType>>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(x => x.Where(e => e.HasValue(c.Source.IdBairro)))));
            FieldAsync<ListGraphType<RuaType>>("rua", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Rua>(x => x.Where(e => e.HasValue(c.Source.IdBairro)))));
            
        }
    }

    public class BairroInputType : InputObjectGraphType
	{
		public BairroInputType()
		{
			// Defining the name of the object
			Name = "bairroInput";
			
            //Field<StringGraphType>("idBairro");
			Field<StringGraphType>("nomeBairro");
			Field<StringGraphType>("distritoId");
			Field<StringGraphType>("codBairro");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<DistritoInputType>("distrito");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<ComunaInputType>>("comuna");
			Field<ListGraphType<EnderecoInputType>>("endereco");
			Field<ListGraphType<RuaInputType>>("rua");
			
		}
	}
}