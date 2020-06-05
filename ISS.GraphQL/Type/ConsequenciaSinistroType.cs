using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ConsequenciaSinistroType : ObjectGraphType<ConsequenciaSinistro>
    {
        public ConsequenciaSinistroType()
        {
            // Defining the name of the object
            Name = "consequenciaSinistro";

            Field(x => x.IdConsequenciaSinistro, nullable: true);
            Field(x => x.FerimentosResultantes, nullable: true);
            Field(x => x.CodConsequenciaSinistro, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.HouveNecessidadeRecorrerHospital, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.QualNecessidade, nullable: true);
            Field(x => x.FoiTransferidoParaOutroHospital, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DeslocouseEmAmbulancia, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DosBombeiro, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstaSerTratadoEmAlgumCentroMedico, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.FicouInternado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.OsinistradoEstaParcialOuTotalImpossiblitadoTrabalhar, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.FicouEmRegimeTratamentoAmbulatorio, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PessoaId, nullable: true);
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class ConsequenciaSinistroInputType : InputObjectGraphType
	{
		public ConsequenciaSinistroInputType()
		{
			// Defining the name of the object
			Name = "consequenciaSinistroInput";
			
            //Field<StringGraphType>("idConsequenciaSinistro");
			Field<StringGraphType>("ferimentosResultantes");
			Field<StringGraphType>("codConsequenciaSinistro");
			Field<StringGraphType>("sinistroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("houveNecessidadeRecorrerHospital");
			Field<StringGraphType>("qualNecessidade");
			Field<BooleanGraphType>("foiTransferidoParaOutroHospital");
			Field<BooleanGraphType>("deslocouseEmAmbulancia");
			Field<BooleanGraphType>("dosBombeiro");
			Field<BooleanGraphType>("estaSerTratadoEmAlgumCentroMedico");
			Field<BooleanGraphType>("ficouInternado");
			Field<BooleanGraphType>("osinistradoEstaParcialOuTotalImpossiblitadoTrabalhar");
			Field<BooleanGraphType>("ficouEmRegimeTratamentoAmbulatorio");
			Field<StringGraphType>("pessoaId");
			Field<PessoaInputType>("pessoa");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}