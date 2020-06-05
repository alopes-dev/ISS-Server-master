using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AccionistaEmpresaType : ObjectGraphType<AccionistaEmpresa>
    {
        public AccionistaEmpresaType()
        {
            // Defining the name of the object
            Name = "accionistaEmpresa";

            Field(x => x.IdAccionistaEmpresa, nullable: true);
            Field(x => x.ValorCota, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.AccionistaId, nullable: true);
            Field(x => x.EmpresaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<PessoaType>("accionista", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.AccionistaId)));
            FieldAsync<PessoaType>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.EmpresaId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class AccionistaEmpresaInputType : InputObjectGraphType
	{
		public AccionistaEmpresaInputType()
		{
			// Defining the name of the object
			Name = "accionistaEmpresaInput";
			
            //Field<StringGraphType>("idAccionistaEmpresa");
			Field<FloatGraphType>("valorCota");
			Field<StringGraphType>("accionistaId");
			Field<StringGraphType>("empresaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<PessoaInputType>("accionista");
			Field<PessoaInputType>("empresa");
			Field<EstadoInputType>("estado");
			
		}
	}
}