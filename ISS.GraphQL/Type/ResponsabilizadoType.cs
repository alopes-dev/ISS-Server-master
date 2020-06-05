using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ResponsabilizadoType : ObjectGraphType<Responsabilizado>
    {
        public ResponsabilizadoType()
        {
            // Defining the name of the object
            Name = "responsabilizado";

            Field(x => x.IdResponsabilizado, nullable: true);
            Field(x => x.Percentagem, nullable: true, type: typeof(FloatGraphType));
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.SinistroId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.IsTaxa, nullable: true, type: typeof(BooleanGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.CodResponsabilizado, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<SinistroType>("sinistro", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Sinistro>(c.Source.SinistroId)));
            
        }
    }

    public class ResponsabilizadoInputType : InputObjectGraphType
	{
		public ResponsabilizadoInputType()
		{
			// Defining the name of the object
			Name = "responsabilizadoInput";
			
            //Field<StringGraphType>("idResponsabilizado");
			Field<FloatGraphType>("percentagem");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("sinistroId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<BooleanGraphType>("isTaxa");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("codResponsabilizado");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<SinistroInputType>("sinistro");
			
		}
	}
}