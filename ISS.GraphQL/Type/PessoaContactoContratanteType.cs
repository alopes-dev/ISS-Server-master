using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PessoaContactoContratanteType : ObjectGraphType<PessoaContactoContratante>
    {
        public PessoaContactoContratanteType()
        {
            // Defining the name of the object
            Name = "pessoaContactoContratante";

            Field(x => x.IdPessoaContactoContratante, nullable: true);
            Field(x => x.PessoaContactoId, nullable: true);
            Field(x => x.ContratanteId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodPessoaContactoContratante, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            FieldAsync<PessoaType>("contratante", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.ContratanteId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<PessoaType>("pessoaContacto", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaContactoId)));
            
        }
    }

    public class PessoaContactoContratanteInputType : InputObjectGraphType
	{
		public PessoaContactoContratanteInputType()
		{
			// Defining the name of the object
			Name = "pessoaContactoContratanteInput";
			
            //Field<StringGraphType>("idPessoaContactoContratante");
			Field<StringGraphType>("pessoaContactoId");
			Field<StringGraphType>("contratanteId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codPessoaContactoContratante");
			Field<StringGraphType>("contratoId");
			Field<PessoaInputType>("contratante");
			Field<ContratoInputType>("contrato");
			Field<PessoaInputType>("pessoaContacto");
			
		}
	}
}