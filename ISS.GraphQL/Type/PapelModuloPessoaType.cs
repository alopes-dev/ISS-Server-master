using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class PapelModuloPessoaType : ObjectGraphType<PapelModuloPessoa>
    {
        public PapelModuloPessoaType()
        {
            // Defining the name of the object
            Name = "papelModuloPessoa";

            Field(x => x.IdPapelModuloPessoa, nullable: true);
            Field(x => x.ModuloCoreId, nullable: true);
            Field(x => x.CodPapelModuloPessoa, nullable: true);
            Field(x => x.PapelPessoaId, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ModuloCoreType>("moduloCore", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModuloCore>(c.Source.ModuloCoreId)));
            FieldAsync<PapelPessoaType>("papelPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelPessoa>(c.Source.PapelPessoaId)));
            FieldAsync<ListGraphType<PapelModuloFuncionalidadeType>>("papelModuloFuncionalidade", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelModuloFuncionalidade>(x => x.Where(e => e.HasValue(c.Source.IdPapelModuloPessoa)))));
            
        }
    }

    public class PapelModuloPessoaInputType : InputObjectGraphType
	{
		public PapelModuloPessoaInputType()
		{
			// Defining the name of the object
			Name = "papelModuloPessoaInput";
			
            //Field<StringGraphType>("idPapelModuloPessoa");
			Field<StringGraphType>("moduloCoreId");
			Field<StringGraphType>("codPapelModuloPessoa");
			Field<StringGraphType>("papelPessoaId");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<EstadoInputType>("estado");
			Field<ModuloCoreInputType>("moduloCore");
			Field<PapelPessoaInputType>("papelPessoa");
			Field<ListGraphType<PapelModuloFuncionalidadeInputType>>("papelModuloFuncionalidade");
			
		}
	}
}