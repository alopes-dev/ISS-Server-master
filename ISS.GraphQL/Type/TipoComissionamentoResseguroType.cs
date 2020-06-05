using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class TipoComissionamentoResseguroType : ObjectGraphType<TipoComissionamentoResseguro>
    {
        public TipoComissionamentoResseguroType()
        {
            // Defining the name of the object
            Name = "tipoComissionamentoResseguro";

            Field(x => x.IdTipoComissionamentoResseguro, nullable: true);
            Field(x => x.ComissionamentoId, nullable: true);
            Field(x => x.CodTipoComissionamentoResseguro, nullable: true);
            Field(x => x.ContratoId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.Designacao, nullable: true);
            FieldAsync<ComissionamentoType>("comissionamento", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Comissionamento>(c.Source.ComissionamentoId)));
            FieldAsync<ContratoType>("contrato", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Contrato>(c.Source.ContratoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            
        }
    }

    public class TipoComissionamentoResseguroInputType : InputObjectGraphType
	{
		public TipoComissionamentoResseguroInputType()
		{
			// Defining the name of the object
			Name = "tipoComissionamentoResseguroInput";
			
            //Field<StringGraphType>("idTipoComissionamentoResseguro");
			Field<StringGraphType>("comissionamentoId");
			Field<StringGraphType>("codTipoComissionamentoResseguro");
			Field<StringGraphType>("contratoId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("designacao");
			Field<ComissionamentoInputType>("comissionamento");
			Field<ContratoInputType>("contrato");
			Field<EstadoInputType>("estado");
			
		}
	}
}