using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class GrauParentescoType : ObjectGraphType<GrauParentesco>
    {
        public GrauParentescoType()
        {
            // Defining the name of the object
            Name = "grauParentesco";

            Field(x => x.IdGrau, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PercentagemIndemnizacao, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DescricaoIndemnizacao, nullable: true);
            Field(x => x.DescricaoMaxIndemnizacao, nullable: true);
            Field(x => x.CodGrauParentesco, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<BeneficiarioType>>("beneficiario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Beneficiario>(x => x.Where(e => e.HasValue(c.Source.IdGrau)))));
            FieldAsync<ListGraphType<DependenteType>>("dependente", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Dependente>(x => x.Where(e => e.HasValue(c.Source.IdGrau)))));
            FieldAsync<ListGraphType<ReembolsoTratamentoDentarioType>>("reembolsoTratamentoDentario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ReembolsoTratamentoDentario>(x => x.Where(e => e.HasValue(c.Source.IdGrau)))));
            
        }
    }

    public class GrauParentescoInputType : InputObjectGraphType
	{
		public GrauParentescoInputType()
		{
			// Defining the name of the object
			Name = "grauParentescoInput";
			
            //Field<StringGraphType>("idGrau");
			Field<StringGraphType>("designacao");
			Field<FloatGraphType>("percentagemIndemnizacao");
			Field<StringGraphType>("descricaoIndemnizacao");
			Field<StringGraphType>("descricaoMaxIndemnizacao");
			Field<StringGraphType>("codGrauParentesco");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<BeneficiarioInputType>>("beneficiario");
			Field<ListGraphType<DependenteInputType>>("dependente");
			Field<ListGraphType<ReembolsoTratamentoDentarioInputType>>("reembolsoTratamentoDentario");
			
		}
	}
}