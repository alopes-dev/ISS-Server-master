using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class MotoristaType : ObjectGraphType<Motorista>
    {
        public MotoristaType()
        {
            // Defining the name of the object
            Name = "motorista";

            Field(x => x.IdMotorista, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodMotorista, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.AutomovelId, nullable: true);
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<AutomovelType>("automovel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Automovel>(c.Source.AutomovelId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class MotoristaInputType : InputObjectGraphType
	{
		public MotoristaInputType()
		{
			// Defining the name of the object
			Name = "motoristaInput";
			
            //Field<StringGraphType>("idMotorista");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codMotorista");
			Field<StringGraphType>("sinistroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("automovelId");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<AutomovelInputType>("automovel");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}