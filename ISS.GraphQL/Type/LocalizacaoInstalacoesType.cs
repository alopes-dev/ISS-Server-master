using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class LocalizacaoInstalacoesType : ObjectGraphType<LocalizacaoInstalacoes>
    {
        public LocalizacaoInstalacoesType()
        {
            // Defining the name of the object
            Name = "localizacaoInstalacoes";

            Field(x => x.IdLocalizacaoInstalacao, nullable: true);
            Field(x => x.TipoInstalacoesId, nullable: true);
            Field(x => x.EnderecoId, nullable: true);
            Field(x => x.InstalacaoId, nullable: true);
            Field(x => x.CodLocalizacaoInstalacoes, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EnderecoType>("endereco", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Endereco>(c.Source.EnderecoId)));
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<InstalacoesType>("instalacao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Instalacoes>(c.Source.InstalacaoId)));
            FieldAsync<TipoInstalacoesType>("tipoInstalacoes", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<TipoInstalacoes>(c.Source.TipoInstalacoesId)));
            
        }
    }

    public class LocalizacaoInstalacoesInputType : InputObjectGraphType
	{
		public LocalizacaoInstalacoesInputType()
		{
			// Defining the name of the object
			Name = "localizacaoInstalacoesInput";
			
            //Field<StringGraphType>("idLocalizacaoInstalacao");
			Field<StringGraphType>("tipoInstalacoesId");
			Field<StringGraphType>("enderecoId");
			Field<StringGraphType>("instalacaoId");
			Field<StringGraphType>("codLocalizacaoInstalacoes");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EnderecoInputType>("endereco");
			Field<EstadoInputType>("estado");
			Field<InstalacoesInputType>("instalacao");
			Field<TipoInstalacoesInputType>("tipoInstalacoes");
			
		}
	}
}