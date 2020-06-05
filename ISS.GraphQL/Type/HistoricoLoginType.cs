using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class HistoricoLoginType : ObjectGraphType<HistoricoLogin>
    {
        public HistoricoLoginType()
        {
            // Defining the name of the object
            Name = "historicoLogin";

            Field(x => x.IdHistoricoLogin, nullable: true);
            Field(x => x.IpMaquina, nullable: true);
            Field(x => x.NomePais, nullable: true);
            Field(x => x.Navegador, nullable: true);
            Field(x => x.SistemaOperativo, nullable: true);
            Field(x => x.Aplicativo, nullable: true);
            Field(x => x.VersaoCliente, nullable: true);
            Field(x => x.TipoApi, nullable: true);
            Field(x => x.VersaoApi, nullable: true);
            Field(x => x.Urllogin, nullable: true);
            Field(x => x.TipoLogin, nullable: true);
            Field(x => x.Httpmetodo, nullable: true);
            Field(x => x.Estado, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DataHoraLogin, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.UsuarioId, nullable: true);
            
        }
    }

    public class HistoricoLoginInputType : InputObjectGraphType
	{
		public HistoricoLoginInputType()
		{
			// Defining the name of the object
			Name = "historicoLoginInput";
			
            //Field<StringGraphType>("idHistoricoLogin");
			Field<StringGraphType>("ipMaquina");
			Field<StringGraphType>("nomePais");
			Field<StringGraphType>("navegador");
			Field<StringGraphType>("sistemaOperativo");
			Field<StringGraphType>("aplicativo");
			Field<StringGraphType>("versaoCliente");
			Field<StringGraphType>("tipoApi");
			Field<StringGraphType>("versaoApi");
			Field<StringGraphType>("urllogin");
			Field<StringGraphType>("tipoLogin");
			Field<StringGraphType>("httpmetodo");
			Field<BooleanGraphType>("estado");
			Field<DateTimeGraphType>("dataHoraLogin");
			Field<StringGraphType>("usuarioId");
			
		}
	}
}