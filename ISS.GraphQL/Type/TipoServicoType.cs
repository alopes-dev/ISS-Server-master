using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoServicoType : ObjectGraphType<TipoServico>
    {
        public TipoServicoType()
        {
            // Defining the name of the object
            Name = "tipoServico";

            Field(x => x.IdTipoServico, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.CodTipoServico, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CaminhoIcone, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<PrecosAtosMedicosType>>("precosAtosMedicos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PrecosAtosMedicos>(x => x.Where(e => e.HasValue(c.Source.IdTipoServico)))));
            FieldAsync<ListGraphType<ServicoType>>("servico", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Servico>(x => x.Where(e => e.HasValue(c.Source.IdTipoServico)))));
            FieldAsync<ListGraphType<TipoContratoType>>("tipoContrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoContrato>(x => x.Where(e => e.HasValue(c.Source.IdTipoServico)))));
            
        }
    }

    public class TipoServicoInputType : InputObjectGraphType
	{
		public TipoServicoInputType()
		{
			// Defining the name of the object
			Name = "tipoServicoInput";
			
            //Field<StringGraphType>("idTipoServico");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("codTipoServico");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("caminhoIcone");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<PrecosAtosMedicosInputType>>("precosAtosMedicos");
			Field<ListGraphType<ServicoInputType>>("servico");
			Field<ListGraphType<TipoContratoInputType>>("tipoContrato");
			
		}
	}
}