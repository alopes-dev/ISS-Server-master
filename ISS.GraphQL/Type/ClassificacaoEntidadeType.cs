using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ClassificacaoEntidadeType : ObjectGraphType<ClassificacaoEntidade>
    {
        public ClassificacaoEntidadeType()
        {
            // Defining the name of the object
            Name = "classificacaoEntidade";

            Field(x => x.IdClassificacaoEntidade, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoEntidadeId, nullable: true);
            Field(x => x.CodClassificacaoEntidade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoEntidadeType>("tipoEntidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEntidade>(c.Source.TipoEntidadeId)));
            FieldAsync<ListGraphType<BancoType>>("banco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Banco>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoEntidade)))));
            FieldAsync<ListGraphType<EntidadeEmpregadoraType>>("entidadeEmpregadora", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<EntidadeEmpregadora>(x => x.Where(e => e.HasValue(c.Source.IdClassificacaoEntidade)))));
            
        }
    }

    public class ClassificacaoEntidadeInputType : InputObjectGraphType
	{
		public ClassificacaoEntidadeInputType()
		{
			// Defining the name of the object
			Name = "classificacaoEntidadeInput";
			
            //Field<StringGraphType>("idClassificacaoEntidade");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoEntidadeId");
			Field<StringGraphType>("codClassificacaoEntidade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TipoEntidadeInputType>("tipoEntidade");
			Field<ListGraphType<BancoInputType>>("banco");
			Field<ListGraphType<EntidadeEmpregadoraInputType>>("entidadeEmpregadora");
			
		}
	}
}