using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoSociedadeType : ObjectGraphType<TipoSociedade>
    {
        public TipoSociedadeType()
        {
            // Defining the name of the object
            Name = "tipoSociedade";

            Field(x => x.IdTipoSociedade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodTipoSociedade, nullable: true);
            Field(x => x.TipoEntidadeId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoEntidadeType>("tipoEntidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEntidade>(c.Source.TipoEntidadeId)));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdTipoSociedade)))));
            FieldAsync<ListGraphType<TipoSociedadePlanoType>>("tipoSociedadePlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSociedadePlano>(x => x.Where(e => e.HasValue(c.Source.IdTipoSociedade)))));
            
        }
    }

    public class TipoSociedadeInputType : InputObjectGraphType
	{
		public TipoSociedadeInputType()
		{
			// Defining the name of the object
			Name = "tipoSociedadeInput";
			
            //Field<StringGraphType>("idTipoSociedade");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codTipoSociedade");
			Field<StringGraphType>("tipoEntidadeId");
			Field<EstadoInputType>("estado");
			Field<TipoEntidadeInputType>("tipoEntidade");
			Field<ListGraphType<PessoaInputType>>("pessoa");
			Field<ListGraphType<TipoSociedadePlanoInputType>>("tipoSociedadePlano");
			
		}
	}
}