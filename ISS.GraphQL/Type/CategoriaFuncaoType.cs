using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CategoriaFuncaoType : ObjectGraphType<CategoriaFuncao>
    {
        public CategoriaFuncaoType()
        {
            // Defining the name of the object
            Name = "categoriaFuncao";

            Field(x => x.IdCategoriaFuncao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodCategoriaFuncao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<FuncionarioType>>("funcionario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(x => x.Where(e => e.HasValue(c.Source.IdCategoriaFuncao)))));
            FieldAsync<ListGraphType<PessoaProfissaoType>>("pessoaProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(x => x.Where(e => e.HasValue(c.Source.IdCategoriaFuncao)))));
            
        }
    }

    public class CategoriaFuncaoInputType : InputObjectGraphType
	{
		public CategoriaFuncaoInputType()
		{
			// Defining the name of the object
			Name = "categoriaFuncaoInput";
			
            //Field<StringGraphType>("idCategoriaFuncao");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codCategoriaFuncao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<FuncionarioInputType>>("funcionario");
			Field<ListGraphType<PessoaProfissaoInputType>>("pessoaProfissao");
			
		}
	}
}