using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ReembolsoDespesasMedicasType : ObjectGraphType<ReembolsoDespesasMedicas>
    {
        public ReembolsoDespesasMedicasType()
        {
            // Defining the name of the object
            Name = "reembolsoDespesasMedicas";

            Field(x => x.IdReembolsoDespesasMedicas, nullable: true);
            Field(x => x.CodReembolsoDespesasMedicas, nullable: true);
            Field(x => x.Empregado, nullable: true);
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.PessoaSegura, nullable: true);
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<FuncionarioType>("empregadoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcionario>(c.Source.Empregado)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoaSeguraNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaSegura)));
            FieldAsync<ListGraphType<GarantiasAfetasDespesasMedicasType>>("garantiasAfetasDespesasMedicas", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<GarantiasAfetasDespesasMedicas>(x => x.Where(e => e.HasValue(c.Source.IdReembolsoDespesasMedicas)))));
            
        }
    }

    public class ReembolsoDespesasMedicasInputType : InputObjectGraphType
	{
		public ReembolsoDespesasMedicasInputType()
		{
			// Defining the name of the object
			Name = "reembolsoDespesasMedicasInput";
			
            //Field<StringGraphType>("idReembolsoDespesasMedicas");
			Field<StringGraphType>("codReembolsoDespesasMedicas");
			Field<StringGraphType>("empregado");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("pessoaSegura");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<StringGraphType>("estadoId");
			Field<ApoliceInputType>("apolice");
			Field<FuncionarioInputType>("empregadoNavigation");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoaSeguraNavigation");
			Field<ListGraphType<GarantiasAfetasDespesasMedicasInputType>>("garantiasAfetasDespesasMedicas");
			
		}
	}
}