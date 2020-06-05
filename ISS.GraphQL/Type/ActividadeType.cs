using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ActividadeType : ObjectGraphType<Actividade>
    {
        public ActividadeType()
        {
            // Defining the name of the object
            Name = "actividade";

            Field(x => x.IdActividade, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataInicio, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataFim, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Prazo, nullable: true, type: typeof(IntGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.PessoaResponsavelId, nullable: true);
            Field(x => x.BeneficiarioId, nullable: true);
            Field(x => x.DonoPedidoId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoActividadeId, nullable: true);
            Field(x => x.CodActividade, nullable: true);
            Field(x => x.FuncaoId, nullable: true);
            Field(x => x.CargoFuncionarioId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<PessoaType>("beneficiario", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.BeneficiarioId)));
            FieldAsync<PessoaType>("donoPedido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.DonoPedidoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<FuncaoType>("funcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcao>(c.Source.FuncaoId)));
            FieldAsync<PessoaType>("pessoaResponsavel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaResponsavelId)));
            FieldAsync<TipoActividadeType>("tipoActividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoActividade>(c.Source.TipoActividadeId)));
            FieldAsync<ListGraphType<ActividadePlanoType>>("actividadePlano", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ActividadePlano>(x => x.Where(e => e.HasValue(c.Source.IdActividade)))));
            FieldAsync<ListGraphType<ActividadesAgendaType>>("actividadesAgenda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ActividadesAgenda>(x => x.Where(e => e.HasValue(c.Source.IdActividade)))));
            FieldAsync<ListGraphType<ContratoPrestadorEmpresaType>>("contratoPrestadorEmpresa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ContratoPrestadorEmpresa>(x => x.Where(e => e.HasValue(c.Source.IdActividade)))));
            FieldAsync<ListGraphType<TarefasActividadeType>>("tarefasActividade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefasActividade>(x => x.Where(e => e.HasValue(c.Source.IdActividade)))));
            
        }
    }

    public class ActividadeInputType : InputObjectGraphType
	{
		public ActividadeInputType()
		{
			// Defining the name of the object
			Name = "actividadeInput";
			
            //Field<StringGraphType>("idActividade");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataInicio");
			Field<DateTimeGraphType>("dataFim");
			Field<IntGraphType>("prazo");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("pessoaResponsavelId");
			Field<StringGraphType>("beneficiarioId");
			Field<StringGraphType>("donoPedidoId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoActividadeId");
			Field<StringGraphType>("codActividade");
			Field<StringGraphType>("funcaoId");
			Field<StringGraphType>("cargoFuncionarioId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<PessoaInputType>("beneficiario");
			Field<PessoaInputType>("donoPedido");
			Field<EstadoInputType>("estado");
			Field<FuncaoInputType>("funcao");
			Field<PessoaInputType>("pessoaResponsavel");
			Field<TipoActividadeInputType>("tipoActividade");
			Field<ListGraphType<ActividadePlanoInputType>>("actividadePlano");
			Field<ListGraphType<ActividadesAgendaInputType>>("actividadesAgenda");
			Field<ListGraphType<ContratoPrestadorEmpresaInputType>>("contratoPrestadorEmpresa");
			Field<ListGraphType<TarefasActividadeInputType>>("tarefasActividade");
			
		}
	}
}