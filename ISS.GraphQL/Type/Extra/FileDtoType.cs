
using GraphQL.Types;
using ISS.Application.Dto;

namespace ISS.GraphQL
{

    public class FileDtoType : ObjectGraphType<FileDto>
    {
        public FileDtoType()
        {
            Name = "fileDto";
            Field(x => x.Nome);
            Field(x => x.Extensao);
            Field(x => x.Data);
        }
    }
    public class FileDtoInputType : InputObjectGraphType
    {
        public FileDtoInputType()
        {
            Name = "fileDtoInput";
            Field<StringGraphType>("nome");
            Field<StringGraphType>("extensao");
            Field<StringGraphType>("data");

        }
    }

}
