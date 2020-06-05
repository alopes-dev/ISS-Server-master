using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoVerificacaoIdentidadeType : ObjectGraphType<HistoricoVerificacaoIdentidade>
    {
        public HistoricoVerificacaoIdentidadeType()
        {
            // Defining the name of the object
            Name = "historicoVerificacaoIdentidade";

            Field(x => x.IdHistoricoVerificacaoIdentidade, nullable: true);
            Field(x => x.IpMaquina, nullable: true);
            Field(x => x.NomePais, nullable: true);
            Field(x => x.MensagemActividade, nullable: true);
            Field(x => x.Metodo, nullable: true);
            Field(x => x.Estado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.TentativaVerificacao, nullable: true);
            Field(x => x.DataHoraLogin, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.UsuarioId, nullable: true);
            
        }
    }

    public class HistoricoVerificacaoIdentidadeInputType : InputObjectGraphType
	{
		public HistoricoVerificacaoIdentidadeInputType()
		{
			// Defining the name of the object
			Name = "historicoVerificacaoIdentidadeInput";
			
            //Field<StringGraphType>("idHistoricoVerificacaoIdentidade");
			Field<StringGraphType>("ipMaquina");
			Field<StringGraphType>("nomePais");
			Field<StringGraphType>("mensagemActividade");
			Field<StringGraphType>("metodo");
			Field<BooleanGraphType>("estado");
			Field<StringGraphType>("tentativaVerificacao");
			Field<DateTimeGraphType>("dataHoraLogin");
			Field<StringGraphType>("usuarioId");
			
		}
	}
}