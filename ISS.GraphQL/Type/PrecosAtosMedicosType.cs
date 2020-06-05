using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PrecosAtosMedicosType : ObjectGraphType<PrecosAtosMedicos>
    {
        public PrecosAtosMedicosType()
        {
            // Defining the name of the object
            Name = "precosAtosMedicos";

            Field(x => x.IdPrecosAtosMedicos, nullable: true);
            Field(x => x.Moeda, nullable: true);
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.IdAtosMedicos, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.IdCambio, nullable: true);
            Field(x => x.TipoServico, nullable: true);
            Field(x => x.CodPrecosAtosMedicos, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<AtosMedicosType>("idAtosMedicosNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<AtosMedicos>(c.Source.IdAtosMedicos)));
            FieldAsync<CambioType>("idCambioNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Cambio>(c.Source.IdCambio)));
            FieldAsync<MoedaType>("moedaNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Moeda>(c.Source.Moeda)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<TipoServicoType>("tipoServicoNavigation", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoServico>(c.Source.TipoServico)));
            
        }
    }

    public class PrecosAtosMedicosInputType : InputObjectGraphType
	{
		public PrecosAtosMedicosInputType()
		{
			// Defining the name of the object
			Name = "precosAtosMedicosInput";
			
            //Field<StringGraphType>("idPrecosAtosMedicos");
			Field<StringGraphType>("moeda");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("idAtosMedicos");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("idCambio");
			Field<StringGraphType>("tipoServico");
			Field<StringGraphType>("codPrecosAtosMedicos");
			Field<EstadoInputType>("estado");
			Field<AtosMedicosInputType>("idAtosMedicosNavigation");
			Field<CambioInputType>("idCambioNavigation");
			Field<MoedaInputType>("moedaNavigation");
			Field<PessoaInputType>("pessoa");
			Field<TipoServicoInputType>("tipoServicoNavigation");
			
		}
	}
}