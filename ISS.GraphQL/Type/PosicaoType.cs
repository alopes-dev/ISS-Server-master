using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PosicaoType : ObjectGraphType<Posicao>
    {
        public PosicaoType()
        {
            // Defining the name of the object
            Name = "posicao";

            Field(x => x.IdPosicao, nullable: true);
            Field(x => x.CodPosicao, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataActualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DireccaoId, nullable: true);
            Field(x => x.DepartamentoId, nullable: true);
            Field(x => x.SectorId, nullable: true);
            Field(x => x.SeccaoId, nullable: true);
            Field(x => x.CargoId, nullable: true);
            Field(x => x.FuncaoId, nullable: true);
            FieldAsync<CargoType>("cargo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cargo>(c.Source.CargoId)));
            FieldAsync<DireccaoType>("direccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Direccao>(c.Source.DireccaoId)));
            FieldAsync<FuncaoType>("funcao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Funcao>(c.Source.FuncaoId)));
            FieldAsync<SeccaoType>("seccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Seccao>(c.Source.SeccaoId)));
            
        }
    }

    public class PosicaoInputType : InputObjectGraphType
	{
		public PosicaoInputType()
		{
			// Defining the name of the object
			Name = "posicaoInput";
			
            //Field<StringGraphType>("idPosicao");
			Field<StringGraphType>("codPosicao");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataActualizacao");
			Field<StringGraphType>("direccaoId");
			Field<StringGraphType>("departamentoId");
			Field<StringGraphType>("sectorId");
			Field<StringGraphType>("seccaoId");
			Field<StringGraphType>("cargoId");
			Field<StringGraphType>("funcaoId");
			Field<CargoInputType>("cargo");
			Field<DireccaoInputType>("direccao");
			Field<FuncaoInputType>("funcao");
			Field<SeccaoInputType>("seccao");
			
		}
	}
}