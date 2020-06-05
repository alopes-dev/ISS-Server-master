using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoContratoEmpresaType : ObjectGraphType<TipoContratoEmpresa>
    {
        public TipoContratoEmpresaType()
        {
            // Defining the name of the object
            Name = "tipoContratoEmpresa";

            Field(x => x.IdTipoContratoEmpresa, nullable: true);
            Field(x => x.TipoContratoId, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.EmpresaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodTipoContratoEmpresa, nullable: true);
            FieldAsync<EmpresaType>("empresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Empresa>(c.Source.EmpresaId)));
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<TipoContratoType>("tipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContrato>(c.Source.TipoContratoId)));
            
        }
    }

    public class TipoContratoEmpresaInputType : InputObjectGraphType
	{
		public TipoContratoEmpresaInputType()
		{
			// Defining the name of the object
			Name = "tipoContratoEmpresaInput";
			
            //Field<StringGraphType>("idTipoContratoEmpresa");
			Field<StringGraphType>("tipoContratoId");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("empresaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codTipoContratoEmpresa");
			Field<EmpresaInputType>("empresa");
			Field<EnderecoInputType>("endereco");
			Field<TipoContratoInputType>("tipoContrato");
			
		}
	}
}