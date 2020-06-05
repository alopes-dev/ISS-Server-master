
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Xml2CSharp;
using AutoMapper;
using ISWebApp.GraphQL.Fatca;
using System.Data.SqlClient;
using Dapper;
using ISS.Application.Models;

namespace  catfa
{
    public  class Fatc
    {
          public IEnumerable<Endereco> sqlrt()
        {

            using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
            {
                var sqlQuery = $"select * from Endereco ";
                var automovel = con.Query<Endereco>(sqlQuery);
                return automovel;
            }
        }
       public async Task  GeneratFatca()
       {
            Utility utility = new Utility();
            var customerlist = utility.GetCustomerList();
            //var xmlfromLINQ = new XElement("Address",
            //            from c in customerlist
            //            select new XElement("Address",
            //                new XElement("AddressFree", c.AddressFree),
            //                new XElement("CountryCode", c.CountryCode)
            //                ));
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.ConformanceLevel = ConformanceLevel.Auto;

            var configuracao = new MapperConfiguration(cfg => cfg.AddProfile<FatcaProfile>());
            var mapper = configuracao.CreateMapper();
            var t=mapper.Map < IEnumerable<Endereco>, IEnumerable<Address>>(sqlrt());
            using (XmlWriter writer = XmlWriter.Create(@"C:\Users\SNIR_DEV00\Documents\internacional-seguros\ISWebApp.GraphQL\Fatca\test.xml", setting))
            {
                writer.WriteStartElement("Address");
                foreach (var cust in t)
                {
                    writer.WriteStartElement("Address");
                    writer.WriteElementString("AddressFree", cust.AddressFree);
                    writer.WriteElementString("CountryCode", cust.CountryCode);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.Flush();
            }
        }
        public static async Task SaveFile(string filePath, string fileToReadPath)
        {
            var path = filePath;
            var file = new FileStream(path, FileMode.CreateNew);
            file.Close();
            string resultado = string.Empty;
            foreach (var linha in await File.ReadAllLinesAsync(fileToReadPath))
            {
                if (linha.Contains("//end"))
                {
                    resultado += linha.Substring(0, linha.IndexOf("//end"));
                    break;
                }
                resultado += linha;
            }
            File.WriteAllText(filePath, resultado);
        }
        public class Utility
        {
            public List<Address> GetCustomerList()
            {
                List<Address> customers = new List<Address>();
                customers.Add(new Address { AddressFree="AS",CountryCode="12" });
                customers.Add(new Address { AddressFree = "DF", CountryCode = "12" });
                customers.Add(new Address { AddressFree = "KIU", CountryCode = "121" });
                customers.Add(new Address { AddressFree = "IPO", CountryCode = "12" });
                customers.Add(new Address { AddressFree = "OP", CountryCode = "12" });

                return customers;
            }
        }

        public List<TModel> GetCustomerList<TModel> ()
            where TModel : class, new()
        {


         List<TModel> models = new List<TModel>();
         models.Add(new TModel {  });
              
        return models;
        }
        
    }
}
