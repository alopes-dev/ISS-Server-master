using GraphQL.Types;
using ISS.Application.ViewModels;

namespace ISS.GraphQL
{
    public class LoginType : ObjectGraphType<LoginResultViewModel>
    {
        public LoginType()
        {
            Field(x => x.NomeUsuarioOuEmail, nullable: false).Description("O email ou username");
            Field(x => x.LembrarDeMim, nullable: true);
            Field(x => x.Token, nullable: true);
            Field(x => x.PessoaLogar, nullable: true);
        }
    }

    public class LoginInputType : InputObjectGraphType<LoginViewModel>
    {
        public LoginInputType()
        {
            Name = "loginInput";
            Field(x => x.NomeUsuarioOuEmail, nullable: false);
            Field(x => x.Senha, nullable: false);
            Field(x => x.LembrarDeMim, nullable: true);
            Field(x => x.PessoaLogar, nullable: true);
        }
    }
}