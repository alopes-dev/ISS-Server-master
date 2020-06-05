using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class AssinaturaType : ObjectGraphType<Assinatura>
    {
        public AssinaturaType()
        {
            // Defining the name of the object
            Name = "assinatura";

            Field(x => x.IdAssinatura, nullable: true);
            //FieldAsync<Byte[]Type>("imgAssinatura", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Byte[]>(c.Source.IdAssinatura)));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Finalidade, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodAssinatura, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            
        }
    }

    public class AssinaturaInputType : InputObjectGraphType
	{
		public AssinaturaInputType()
		{
			// Defining the name of the object
			Name = "assinaturaInput";
			
            //Field<StringGraphType>("idAssinatura");
			//Field<Byte[]InputType>("imgAssinatura");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("finalidade");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codAssinatura");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			
		}
	}
}