using GraphQL.Types;
using ISS.Application.ViewModels;

namespace ISS.GraphQL
{
    public class RegisterType : ObjectGraphType<RegisterResultViewModel>
    {
        public RegisterType()
        {
            Field(x => x.IdUsuario, nullable: false);
            Field(x => x.Username, nullable: false);
            Field(x => x.Email, nullable: false);
            Field(x => x.Token, nullable: false);
            Field(x => x.Pessoa, nullable: false);
        }
    }

    public class RegisterInputType : InputObjectGraphType<RegisterViewModel>
    {
        public RegisterInputType()
        {
            Name = "registerInput";
            Field(x => x.Username, nullable: false);
            Field(x => x.Email, nullable: false);
            Field(x => x.Password, nullable: false);
            Field(x => x.ConfirmarPassword, nullable: false);
            Field(x => x.Pessoa, nullable: false);
        }
    }
}