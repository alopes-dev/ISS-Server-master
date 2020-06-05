using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PapelProdutorType : ObjectGraphType<PapelProdutor>
    {
        public PapelProdutorType()
        {
            // Defining the name of the object
            Name = "papelProdutor";

            Field(x => x.IdPapelProdutor, nullable: true);
            Field(x => x.PapelId, nullable: true);
            Field(x => x.CodPapelProdutor, nullable: true);
            Field(x => x.RapelProdutorId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            FieldAsync<PapelType>("papel", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Papel>(c.Source.PapelId)));
            FieldAsync<RapelProdutorType>("rapelProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<RapelProdutor>(c.Source.RapelProdutorId)));
            
        }
    }

    public class PapelProdutorInputType : InputObjectGraphType
	{
		public PapelProdutorInputType()
		{
			// Defining the name of the object
			Name = "papelProdutorInput";
			
            //Field<StringGraphType>("idPapelProdutor");
			Field<StringGraphType>("papelId");
			Field<StringGraphType>("codPapelProdutor");
			Field<StringGraphType>("rapelProdutorId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<PapelInputType>("papel");
			Field<RapelProdutorInputType>("rapelProdutor");
			
		}
	}
}