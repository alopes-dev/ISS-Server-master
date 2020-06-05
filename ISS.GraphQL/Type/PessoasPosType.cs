using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PessoasPosType : ObjectGraphType<PessoasPos>
    {
        public PessoasPosType()
        {
            // Defining the name of the object
            Name = "pessoasPos";

            Field(x => x.IdPessoasPos, nullable: true);
            Field(x => x.PessoaId, nullable: true);
            Field(x => x.CodPessoasPos, nullable: true);
            Field(x => x.Posid, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.TipoPessoaId, nullable: true);
            Field(x => x.TipoProdutorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<PessoaType>("pessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pessoa>(c.Source.PessoaId)));
            FieldAsync<PosType>("pos", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Pos>(c.Source.Posid)));
            FieldAsync<TipoPessoaType>("tipoPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoPessoa>(c.Source.TipoPessoaId)));
            FieldAsync<TipoProdutorType>("tipoProdutor", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoProdutor>(c.Source.TipoProdutorId)));
            
        }
    }

    public class PessoasPosInputType : InputObjectGraphType
	{
		public PessoasPosInputType()
		{
			// Defining the name of the object
			Name = "pessoasPosInput";
			
            //Field<StringGraphType>("idPessoasPos");
			Field<StringGraphType>("pessoaId");
			Field<StringGraphType>("codPessoasPos");
			Field<StringGraphType>("posid");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("tipoPessoaId");
			Field<StringGraphType>("tipoProdutorId");
			Field<EstadoInputType>("estado");
			Field<PessoaInputType>("pessoa");
			Field<PosInputType>("pos");
			Field<TipoPessoaInputType>("tipoPessoa");
			Field<TipoProdutorInputType>("tipoProdutor");
			
		}
	}
}