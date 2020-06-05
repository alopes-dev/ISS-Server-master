using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL
{
    public class FileSystType : ObjectGraphType<FileSyst>
    {
        public FileSystType()
        {
            // Defining the name of the object
            Name = "fileSyst";

            Field(x => x.fileName, nullable: true);
            Field(x => x.fileExtensao, nullable: true);
            Field(x => x.url, nullable: true);
            Field(x => x.urlDownload, nullable: true);
            Field(x => x.extType, nullable: true);
            Field(x => x.dirprincipal,nullable:true);
            
        }
    }

    public class FileSystInputType : InputObjectGraphType
	{
		public FileSystInputType()
		{
			// Defining the name of the object
			Name = "fileSystInput";
			
            Field<StringGraphType>("fileName");
			Field<StringGraphType>("fileExtensao");
			Field<StringGraphType>("url");
			Field<StringGraphType>("urlDownload");
			Field<StringGraphType>("extType");
            Field<StringGraphType>("dirprincipal");
			
		}
	}
}