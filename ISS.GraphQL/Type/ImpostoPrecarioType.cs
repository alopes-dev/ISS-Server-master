using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ImpostoPrecarioType : ObjectGraphType<ImpostoPrecario>
    {
        public ImpostoPrecarioType()
        {
            // Defining the name of the object
            Name = "impostoPrecario";

            Field(x => x.IdImpostoPrecario, nullable: true);
            Field(x => x.ImpostoId, nullable: true);
            Field(x => x.PrecarioProdutoId, nullable: true);
            Field(x => x.CodImpostoPrecario, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.ZonaId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ImpostoType>("imposto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Imposto>(c.Source.ImpostoId)));
            FieldAsync<PrecarioProdutoType>("precarioProduto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecarioProduto>(c.Source.PrecarioProdutoId)));
            FieldAsync<ZonaType>("zona", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Zona>(c.Source.ZonaId)));
            FieldAsync<ListGraphType<EncargosType>>("encargos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Encargos>(x => x.Where(e => e.HasValue(c.Source.IdImpostoPrecario)))));
            
        }
    }

    public class ImpostoPrecarioInputType : InputObjectGraphType
	{
		public ImpostoPrecarioInputType()
		{
			// Defining the name of the object
			Name = "impostoPrecarioInput";
			
            //Field<StringGraphType>("idImpostoPrecario");
			Field<StringGraphType>("impostoId");
			Field<StringGraphType>("precarioProdutoId");
			Field<StringGraphType>("codImpostoPrecario");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("zonaId");
			Field<EstadoInputType>("estado");
			Field<ImpostoInputType>("imposto");
			Field<PrecarioProdutoInputType>("precarioProduto");
			Field<ZonaInputType>("zona");
			Field<ListGraphType<EncargosInputType>>("encargos");
			
		}
	}
}