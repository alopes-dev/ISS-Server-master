using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DimensaoEmpresaType : ObjectGraphType<DimensaoEmpresa>
    {
        public DimensaoEmpresaType()
        {
            // Defining the name of the object
            Name = "dimensaoEmpresa";

            Field(x => x.IdDimensaoEmpresa, nullable: true);
            Field(x => x.CodDimensaoEmpresa, nullable: true);
            Field(x => x.MinFuncionarios, nullable: true, type: typeof(IntGraphType));
            Field(x => x.MaxFuncionarios, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Percentagem, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.TipoEmpresaId, nullable: true);
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<TipoEmpresaType>("tipoEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoEmpresa>(c.Source.TipoEmpresaId)));
            FieldAsync<ListGraphType<PessoaType>>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(x => x.Where(e => e.HasValue(c.Source.IdDimensaoEmpresa)))));
            FieldAsync<ListGraphType<TipoSegmentoType>>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(x => x.Where(e => e.HasValue(c.Source.IdDimensaoEmpresa)))));
            
        }
    }

    public class DimensaoEmpresaInputType : InputObjectGraphType
	{
		public DimensaoEmpresaInputType()
		{
			// Defining the name of the object
			Name = "dimensaoEmpresaInput";
			
            //Field<StringGraphType>("idDimensaoEmpresa");
			Field<StringGraphType>("codDimensaoEmpresa");
			Field<IntGraphType>("minFuncionarios");
			Field<IntGraphType>("maxFuncionarios");
			Field<FloatGraphType>("percentagem");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("tipoEmpresaId");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<TipoEmpresaInputType>("tipoEmpresa");
			Field<ListGraphType<PessoaInputType>>("pessoa");
			Field<ListGraphType<TipoSegmentoInputType>>("tipoSegmento");
			
		}
	}
}