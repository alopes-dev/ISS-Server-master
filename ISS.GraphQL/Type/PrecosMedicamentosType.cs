using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrecosMedicamentosType : ObjectGraphType<PrecosMedicamentos>
    {
        public PrecosMedicamentosType()
        {
            // Defining the name of the object
            Name = "precosMedicamentos";

            Field(x => x.IdPrecarioMedicamentos, nullable: true);
            Field(x => x.Unidade, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Minimo, nullable: true, type: typeof(IntGraphType));
            Field(x => x.IdPessoa, nullable: true);
            Field(x => x.IdMedicamento, nullable: true);
            Field(x => x.Valor, nullable: true);
            Field(x => x.IdMoeda, nullable: true);
            Field(x => x.PvPaOa, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.CodPrecosMedicamentos, nullable: true);
            FieldAsync<MedicamentosType>("idMedicamentoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Medicamentos>(c.Source.IdMedicamento)));
            FieldAsync<MoedaType>("idMoedaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.IdMoeda)));
            FieldAsync<PessoaType>("idPessoaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.IdPessoa)));
            
        }
    }

    public class PrecosMedicamentosInputType : InputObjectGraphType
	{
		public PrecosMedicamentosInputType()
		{
			// Defining the name of the object
			Name = "precosMedicamentosInput";
			
            //Field<StringGraphType>("idPrecarioMedicamentos");
			Field<IntGraphType>("unidade");
			Field<IntGraphType>("minimo");
			Field<StringGraphType>("idPessoa");
			Field<StringGraphType>("idMedicamento");
			Field<StringGraphType>("valor");
			Field<StringGraphType>("idMoeda");
			Field<StringGraphType>("pvPaOa");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("codPrecosMedicamentos");
			Field<MedicamentosInputType>("idMedicamentoNavigation");
			Field<MoedaInputType>("idMoedaNavigation");
			Field<PessoaInputType>("idPessoaNavigation");
			
		}
	}
}