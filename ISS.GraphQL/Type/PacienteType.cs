using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PacienteType : ObjectGraphType<Paciente>
    {
        public PacienteType()
        {
            // Defining the name of the object
            Name = "paciente";

            Field(x => x.IdPaciente, nullable: true);
            Field(x => x.NumeroPaciente, nullable: true);
            Field(x => x.RecebeuAlta, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataFimTratamento, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.ApoliceId, nullable: true);
            Field(x => x.TipoRelacaoSeguradoId, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.CaminhoBoletimExame, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            Field(x => x.CodPaciente, nullable: true);
            FieldAsync<ApoliceType>("apolice", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Apolice>(c.Source.ApoliceId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            FieldAsync<TipoRelacaoSeguradoType>("tipoRelacaoSegurado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoRelacaoSegurado>(c.Source.TipoRelacaoSeguradoId)));
            FieldAsync<ListGraphType<PerdaType>>("perda", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Perda>(x => x.Where(e => e.HasValue(c.Source.IdPaciente)))));
            
        }
    }

    public class PacienteInputType : InputObjectGraphType
	{
		public PacienteInputType()
		{
			// Defining the name of the object
			Name = "pacienteInput";
			
            //Field<StringGraphType>("idPaciente");
			Field<StringGraphType>("numeroPaciente");
			Field<BooleanGraphType>("recebeuAlta");
			Field<DateTimeGraphType>("dataFimTratamento");
			Field<StringGraphType>("apoliceId");
			Field<StringGraphType>("tipoRelacaoSeguradoId");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("sinistroId");
			Field<StringGraphType>("caminhoBoletimExame");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<StringGraphType>("codPaciente");
			Field<ApoliceInputType>("apolice");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<SinistroInputType>("sinistro");
			Field<TipoRelacaoSeguradoInputType>("tipoRelacaoSegurado");
			Field<ListGraphType<PerdaInputType>>("perda");
			
		}
	}
}