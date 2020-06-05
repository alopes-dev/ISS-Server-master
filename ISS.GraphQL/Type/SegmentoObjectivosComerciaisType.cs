using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class SegmentoObjectivosComerciaisType : ObjectGraphType<SegmentoObjectivosComerciais>
    {
        public SegmentoObjectivosComerciaisType()
        {
            // Defining the name of the object
            Name = "segmentoObjectivosComerciais";

            Field(x => x.IdSegmentoObjectivosComerciais, nullable: true);
            Field(x => x.ProdutorId, nullable: true);
            Field(x => x.TipoSegmentoId, nullable: true);
            Field(x => x.ObjectivosComerciaisId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodSegmentoObjectivosComerciais, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ObjectivosComerciaisType>("objectivosComerciais", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectivosComerciais>(c.Source.ObjectivosComerciaisId)));
            FieldAsync<PessoaType>("produtor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ProdutorId)));
            FieldAsync<TipoSegmentoType>("tipoSegmento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoSegmento>(c.Source.TipoSegmentoId)));
            
        }
    }

    public class SegmentoObjectivosComerciaisInputType : InputObjectGraphType
	{
		public SegmentoObjectivosComerciaisInputType()
		{
			// Defining the name of the object
			Name = "segmentoObjectivosComerciaisInput";
			
            //Field<StringGraphType>("idSegmentoObjectivosComerciais");
			Field<StringGraphType>("produtorId");
			Field<StringGraphType>("tipoSegmentoId");
			Field<StringGraphType>("objectivosComerciaisId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codSegmentoObjectivosComerciais");
			Field<EstadoInputType>("estado");
			Field<ObjectivosComerciaisInputType>("objectivosComerciais");
			Field<PessoaInputType>("produtor");
			Field<TipoSegmentoInputType>("tipoSegmento");
			
		}
	}
}