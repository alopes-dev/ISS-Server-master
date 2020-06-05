using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class CargoType : ObjectGraphType<Cargo>
    {
        public CargoType()
        {
            // Defining the name of the object
            Name = "cargo";

            Field(x => x.IdCargo, nullable: true);
            Field(x => x.CodCargo, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CargoPublico, nullable: true, type: typeof(BooleanGraphType));
            FieldAsync<ListGraphType<PessoaProfissaoType>>("pessoaProfissao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PessoaProfissao>(x => x.Where(e => e.HasValue(c.Source.IdCargo)))));
            FieldAsync<ListGraphType<PosicaoType>>("posicao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Posicao>(x => x.Where(e => e.HasValue(c.Source.IdCargo)))));
            FieldAsync<ListGraphType<SeccaoType>>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(x => x.Where(e => e.HasValue(c.Source.IdCargo)))));
            
        }
    }

    public class CargoInputType : InputObjectGraphType
	{
		public CargoInputType()
		{
			// Defining the name of the object
			Name = "cargoInput";
			
            //Field<StringGraphType>("idCargo");
			Field<StringGraphType>("codCargo");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("designacao");
			Field<BooleanGraphType>("cargoPublico");
			Field<ListGraphType<PessoaProfissaoInputType>>("pessoaProfissao");
			Field<ListGraphType<PosicaoInputType>>("posicao");
			Field<ListGraphType<SeccaoInputType>>("seccao");
			
		}
	}
}