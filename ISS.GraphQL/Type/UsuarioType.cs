using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.GraphQL.Type;

namespace ISS.GraphQL
{
    public class UsuarioType : ObjectGraphType<Usuario>
    {
        public UsuarioType()
        {
            // Defining the name of the object
            Name = "usuario";

            Field(x => x.Sufixo, nullable: true);
            Field(x => x.IsAtivo, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.UsuarioComercial, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.OfflineUser, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.AgenteCampo, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.Fluxo, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ServicoNuvem, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.ApenasClassico, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.GraficoAutoContraste, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PermitePrevisao, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.DebugMode, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.CheckoutAtivo, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PessoaId, nullable: true);
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<ListGraphType<HistoricoLoginType>>("historicoLogin", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HistoricoLogin>(x => x.Where(e => e.HasValue(c.Source.Id)))));
            FieldAsync<ListGraphType<HistoricoVerificacaoIdentidadeType>>("historicoVerificacaoIdentidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<HistoricoVerificacaoIdentidade>(x => x.Where(e => e.HasValue(c.Source.Id)))));
            Field(x => x.Id, nullable: true);
            Field(x => x.UserName, nullable: true);
            Field(x => x.NormalizedUserName, nullable: true);
            Field(x => x.Email, nullable: true);
            Field(x => x.NormalizedEmail, nullable: true);
            Field(x => x.EmailConfirmed, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.PasswordHash, nullable: true);
            Field(x => x.SecurityStamp, nullable: true);
            Field(x => x.ConcurrencyStamp, nullable: true);
            Field(x => x.PhoneNumber, nullable: true);
            Field(x => x.PhoneNumberConfirmed, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.TwoFactorEnabled, nullable: true, type: typeof(BooleanGraphType));
            //FieldAsync<DateTimeOffsetType>("lockoutEnd", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<DateTimeOffset>(c.Source.Id)));
            Field(x => x.LockoutEnabled, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.AccessFailedCount, nullable: true, type: typeof(IntGraphType));
            
        }
    }

    public class UsuarioInputType : InputObjectGraphType
	{
		public UsuarioInputType()
		{
			// Defining the name of the object
			Name = "usuarioInput";
			
            Field<StringGraphType>("sufixo");
			Field<BooleanGraphType>("isAtivo");
			Field<BooleanGraphType>("usuarioComercial");
			Field<BooleanGraphType>("offlineUser");
			Field<BooleanGraphType>("agenteCampo");
			Field<BooleanGraphType>("fluxo");
			Field<BooleanGraphType>("servicoNuvem");
			Field<BooleanGraphType>("apenasClassico");
			Field<BooleanGraphType>("graficoAutoContraste");
			Field<BooleanGraphType>("permitePrevisao");
			Field<BooleanGraphType>("debugMode");
			Field<BooleanGraphType>("checkoutAtivo");
			Field<StringGraphType>("pessoaId");
			Field<PessoaInputType>("pessoa");
			Field<ListGraphType<HistoricoLoginInputType>>("historicoLogin");
			Field<ListGraphType<HistoricoVerificacaoIdentidadeInputType>>("historicoVerificacaoIdentidade");
			//Field<StringGraphType>("id");
			Field<StringGraphType>("userName");
			Field<StringGraphType>("normalizedUserName");
			Field<StringGraphType>("email");
			Field<StringGraphType>("normalizedEmail");
			Field<BooleanGraphType>("emailConfirmed");
			Field<StringGraphType>("passwordHash");
			Field<StringGraphType>("securityStamp");
			Field<StringGraphType>("concurrencyStamp");
			Field<StringGraphType>("phoneNumber");
			Field<BooleanGraphType>("phoneNumberConfirmed");
			Field<BooleanGraphType>("twoFactorEnabled");
			//Field<DateTimeOffsetInputType>("lockoutEnd");
			Field<BooleanGraphType>("lockoutEnabled");
			Field<IntGraphType>("accessFailedCount");
			
		}
	}
}