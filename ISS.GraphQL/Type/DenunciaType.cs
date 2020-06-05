using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class DenunciaType : ObjectGraphType<Denuncia>
    {
        public DenunciaType()
        {
            // Defining the name of the object
            Name = "denuncia";

            Field(x => x.IdDenuncia, nullable: true);
            Field(x => x.AssuntoDenuncia, nullable: true);
            Field(x => x.CodDenuncia, nullable: true);
            Field(x => x.DescricaoDenuncia, nullable: true);
            Field(x => x.PessoaQueDenunciaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoaQueDenuncia", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaQueDenunciaId)));
            
        }
    }

    public class DenunciaInputType : InputObjectGraphType
	{
		public DenunciaInputType()
		{
			// Defining the name of the object
			Name = "denunciaInput";
			
            //Field<StringGraphType>("idDenuncia");
			Field<StringGraphType>("assuntoDenuncia");
			Field<StringGraphType>("codDenuncia");
			Field<StringGraphType>("descricaoDenuncia");
			Field<StringGraphType>("pessoaQueDenunciaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoaQueDenuncia");
			
		}
	}
}