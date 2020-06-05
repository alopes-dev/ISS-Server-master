using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PessoaContactoContratadoType : ObjectGraphType<PessoaContactoContratado>
    {
        public PessoaContactoContratadoType()
        {
            // Defining the name of the object
            Name = "pessoaContactoContratado";

            Field(x => x.IdPessoaContactoContratado, nullable: true);
            Field(x => x.PessoaContactoId, nullable: true);
            Field(x => x.ContratanteId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodPessoaContactoContratado, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            FieldAsync<PessoaType>("contratante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ContratanteId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<PessoaType>("pessoaContacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaContactoId)));
            
        }
    }

    public class PessoaContactoContratadoInputType : InputObjectGraphType
	{
		public PessoaContactoContratadoInputType()
		{
			// Defining the name of the object
			Name = "pessoaContactoContratadoInput";
			
            //Field<StringGraphType>("idPessoaContactoContratado");
			Field<StringGraphType>("pessoaContactoId");
			Field<StringGraphType>("contratanteId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codPessoaContactoContratado");
			Field<StringGraphType>("contratoId");
			Field<PessoaInputType>("contratante");
			Field<ContratoInputType>("contrato");
			Field<PessoaInputType>("pessoaContacto");
			
		}
	}
}