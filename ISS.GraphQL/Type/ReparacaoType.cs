using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ReparacaoType : ObjectGraphType<Reparacao>
    {
        public ReparacaoType()
        {
            // Defining the name of the object
            Name = "reparacao";

            Field(x => x.IdReparacao, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.DataHora, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.FacturaDisponivel, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PerdaId, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.AutorizacaoId, nullable: true);
            Field(x => x.ObjectoEnvolvidoId, nullable: true);
            Field(x => x.FornecedorId, nullable: true);
            Field(x => x.Imposto, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodReparacao, nullable: true);
            FieldAsync<AutorizacaoType>("autorizacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Autorizacao>(c.Source.AutorizacaoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("fornecedor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.FornecedorId)));
            FieldAsync<ObjectoEnvolvidoType>("objectoEnvolvido", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ObjectoEnvolvido>(c.Source.ObjectoEnvolvidoId)));
            FieldAsync<PerdaType>("perda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perda>(c.Source.PerdaId)));
            FieldAsync<ListGraphType<CustoType>>("custo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Custo>(x => x.Where(e => e.HasValue(c.Source.IdReparacao)))));
            FieldAsync<ListGraphType<TarefaReparacaoType>>("tarefaReparacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TarefaReparacao>(x => x.Where(e => e.HasValue(c.Source.IdReparacao)))));
            
        }
    }

    public class ReparacaoInputType : InputObjectGraphType
	{
		public ReparacaoInputType()
		{
			// Defining the name of the object
			Name = "reparacaoInput";
			
            //Field<StringGraphType>("idReparacao");
			Field<StringGraphType>("designacao");
			Field<DateTimeGraphType>("dataHora");
			Field<BooleanGraphType>("facturaDisponivel");
			Field<StringGraphType>("perdaId");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("autorizacaoId");
			Field<StringGraphType>("objectoEnvolvidoId");
			Field<StringGraphType>("fornecedorId");
			Field<FloatGraphType>("imposto");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codReparacao");
			Field<AutorizacaoInputType>("autorizacao");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("fornecedor");
			Field<ObjectoEnvolvidoInputType>("objectoEnvolvido");
			Field<PerdaInputType>("perda");
			Field<ListGraphType<CustoInputType>>("custo");
			Field<ListGraphType<TarefaReparacaoInputType>>("tarefaReparacao");
			
		}
	}
}