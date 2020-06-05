using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL
{
    public class ApoliceGraphicoType : ObjectGraphType<ApoliceGraphico>
    {
        public ApoliceGraphicoType()
        {
            // Defining the name of the object
            Name = "apolicegraphico";

           
            Field(x => x.QtdApolice);
            Field(x => x.Produto);
      
        
        }
    }

    public class ApoliceGraphicoInputType : InputObjectGraphType
	{
		public ApoliceGraphicoInputType()
		{
			// Defining the name of the object
			Name = "apolicegraphicoInput";
			
          
			Field<StringGraphType>("qtdApolice");
			Field<StringGraphType>("produto");
			
		}
	}
}