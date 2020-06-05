using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoCofreType : ObjectGraphType<TipoCofre>
    {
        public TipoCofreType()
        {
            // Defining the name of the object
            Name = "tipoCofre";

            Field(x => x.IdTipoCofre, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoCofre, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<CofreType>>("cofre", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cofre>(x => x.Where(e => e.HasValue(c.Source.IdTipoCofre)))));
            
        }
    }

    public class TipoCofreInputType : InputObjectGraphType
	{
		public TipoCofreInputType()
		{
			// Defining the name of the object
			Name = "tipoCofreInput";
			
            //Field<StringGraphType>("idTipoCofre");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoCofre");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<CofreInputType>>("cofre");
			
		}
	}
}