using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL.Type
{
    public class ModuloCoreType : ObjectGraphType<ModuloCore>
    {
        public ModuloCoreType()
        {
            // Defining the name of the object
            Name = "moduloCore";

            Field(x => x.IdModuloCore, nullable: true);
            Field(x => x.Designacao, nullable: true);
            Field(x => x.Link, nullable: true);
            Field(x => x.DataCriacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.DataAtualizacao, nullable: true, type: typeof(DateTimeGraphType));
            Field(x => x.EstadoId, nullable: true);
            Field(x => x.UltModificacaoPorId, nullable: true);
            FieldAsync<EstadoType>("estado", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<Estado>(c.Source.EstadoId)));
            FieldAsync<ListGraphType<LicencaModuloType>>("licencaModulo", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<LicencaModulo>(x => x.Where(e => e.HasValue(c.Source.IdModuloCore)))));
            FieldAsync<ListGraphType<ModuloCoreDireccaoType>>("moduloCoreDireccao", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<ModuloCoreDireccao>(x => x.Where(e => e.HasValue(c.Source.IdModuloCore)))));
            FieldAsync<ListGraphType<OperacoesCrudpessoaType>>("operacoesCrudpessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<OperacoesCrudpessoa>(x => x.Where(e => e.HasValue(c.Source.IdModuloCore)))));
            FieldAsync<ListGraphType<PapelModuloPessoaType>>("papelModuloPessoa", resolve: async c => c.Resolve(await c.GetRepository().GetAsync<PapelModuloPessoa>(x => x.Where(e => e.HasValue(c.Source.IdModuloCore)))));
            
        }
    }

    public class ModuloCoreInputType : InputObjectGraphType
	{
		public ModuloCoreInputType()
		{
			// Defining the name of the object
			Name = "moduloCoreInput";
			
            //Field<StringGraphType>("idModuloCore");
			Field<StringGraphType>("designacao");
			Field<StringGraphType>("link");
			Field<DateTimeGraphType>("dataCriacao");
			Field<DateTimeGraphType>("dataAtualizacao");
			Field<StringGraphType>("estadoId");
			Field<StringGraphType>("ultModificacaoPorId");
			Field<EstadoInputType>("estado");
			Field<ListGraphType<LicencaModuloInputType>>("licencaModulo");
			Field<ListGraphType<ModuloCoreDireccaoInputType>>("moduloCoreDireccao");
			Field<ListGraphType<OperacoesCrudpessoaInputType>>("operacoesCrudpessoa");
			Field<ListGraphType<PapelModuloPessoaInputType>>("papelModuloPessoa");
			
		}
	}
}