using System.Linq;
using GraphQL.Types;
using ISS.Application.Models;
using ISS.Application.Helpers;
using ISS.GraphQL.ServiceExtentions;
using ISS.Application.Dto;

namespace ISS.GraphQL
{
    public class SinistroGraphicoType : ObjectGraphType<Sinistrographico>
    {
        public SinistroGraphicoType()
        {
            // Defining the name of the object
            Name = "sinistrografico";

            Field(x => x.QtdSinistro);
            Field(x => x.Produto);

        }
    }
    public class SinistroPaisType : ObjectGraphType<Sinistrographico>
    {
        public SinistroPaisType()
        {
            Name = "sinistroPais";

            Field(x => x.QtdSinistro);
            Field(x => x.Produto);
            Field(x => x.Pais);

        }
    }
    public class SinistroProvincia1Type : ObjectGraphType<Sinistrographico>
    {
        public SinistroProvincia1Type()
        {
            Name = "sinistroProvincia1";

            Field(x => x.QtdSinistro);
            Field(x => x.Provincia);
            Field(x => x.IsPago);

        }
    }
    public class SinistroProvinciaType : ObjectGraphType<Sinistrographico>
    {
        public SinistroProvinciaType()
        {
            Name = "sinistroProvincia";

            Field(x => x.QtdSinistro);
            Field(x => x.Produto);
            Field(x => x.Provincia);

        }
    }
    public class SinistroMunicipioType : ObjectGraphType<Sinistrographico>
    {
        public SinistroMunicipioType()
        {
            Name = "sinistroMunicipio";

            Field(x => x.QtdSinistro);
            Field(x => x.Produto);
            Field(x => x.Municipio);

        }
    }
    public class SinistroContinenteType : ObjectGraphType<Sinistrographico>
    {
        public SinistroContinenteType()
        {
            Name = "sinistroContinente";

            Field(x => x.QtdSinistro);
            Field(x => x.Produto);
            Field(x => x.Continente);

        }
    }
}

