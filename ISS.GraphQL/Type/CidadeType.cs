using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CidadeType : ObjectGraphType<Cidade>
    {
        public CidadeType()
        {
            // Defining the name of the object
            Name = "cidade";

            Field(x => x.IdCidade, nullable: true);
            Field(x => x.CodCidade, nullable: true);
            Field(x => x.NomeCidade, nullable: true);
            Field(x => x.ProvinciaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ProvinciaType>("provincia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Provincia>(c.Source.ProvinciaId)));
            FieldAsync<ListGraphType<EnderecoType>>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(x => x.Where(e => e.HasValue(c.Source.IdCidade)))));
            
        }
    }

    public class CidadeInputType : InputObjectGraphType
	{
		public CidadeInputType()
		{
			// Defining the name of the object
			Name = "cidadeInput";
			
            //Field<StringGraphType>("idCidade");
			Field<StringGraphType>("codCidade");
			Field<StringGraphType>("nomeCidade");
			Field<StringGraphType>("provinciaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ProvinciaInputType>("provincia");
			Field<ListGraphType<EnderecoInputType>>("endereco");
			
		}
	}
}