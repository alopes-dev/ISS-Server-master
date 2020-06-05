using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using Dapper;
using ISS.Application;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using Syncfusion.XlsIO;
using OfficeOpenXml.Style;
using Newtonsoft.Json;
using ISWebApp.GraphQL.Models.Excel;
using ISS.Application.Models;

namespace ISS.GraphQL
{
    public class Excel
    {
        public Dictionary<string, string> tou()
        {
            var cilindragem = sqlrt<CilindragemAutomovel>("CilindragemAutomovel");
            Dictionary<string, string> mapTypes = new Dictionary<string, string>();
            foreach (var dr in cilindragem)
            {
                mapTypes.Add(dr.Cilindragem, dr.IdCilindragemAutomovel);
            }
            return mapTypes;
        }
        public IEnumerable<TModel> sqlrt<TModel>(String Tabela)
        {

            using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
            {
                var sqlQuery = $"select * from {Tabela} ";
                var automovel = con.Query<TModel>(sqlQuery);
                return automovel;
            }
        }
        public IEnumerable<TModel> sqljoin<TModel>(String Tabela, string codicao, string returno, string func)
        {

            using (var con = new SqlConnection("Data Source=172.16.16.18;Initial Catalog=DBIS_PRE_PROD;User ID=sa;Password=snirdb@2019;MultipleActiveResultSets=True;"))
            {
                var sqlQuery = $"select {returno} from {Tabela} where {codicao}  {func}";
                var automovel = con.Query<TModel>(sqlQuery);
                return automovel;
            }
        }
        public IList<dadosmodels> dt(string caminhoNomeSalvar)
        {

            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                var conteudo = Convert.FromBase64String(caminhoNomeSalvar);
                MemoryStream stream = new MemoryStream(conteudo);
                IApplication application = excelEngine.Excel;
                //FileStream fileStream = new FileStream($@"{caminhoNomeSalvar}", FileMode.Open);
                IWorkbook workbook = application.Workbooks.Open(stream, ExcelOpenType.Automatic);
                stream.Dispose();
                IWorksheet worksheet = workbook.Worksheets[0];
                IList<dadosmodels> automovels = worksheet.ExportData<dadosmodels>(1, 1, worksheet.UsedRange.LastRow, workbook.Worksheets[0].UsedRange.LastColumn);
                //using (StreamWriter file = File.CreateText(@"C:\Users\SNIR_DEV00\Documents\internacional-seguros\ISWebApp.GraphQL\Excel\automovel.json"))
                //{
                //    JsonSerializer serializer = new JsonSerializer();
                //    serializer.Serialize(file, automovels);
                //}
                return automovels;
            }
           
        }
         public string dp(String caminhoNomeSalvar)
          {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                FileStream fileStream = new FileStream($@"{caminhoNomeSalvar}", FileMode.Open);
                IWorkbook workbook = application.Workbooks.Open(fileStream, ExcelOpenType.Automatic);
                IWorksheet worksheet = workbook.Worksheets[2];
                IList<modelopessoa> pessoa = worksheet.ExportData<modelopessoa>(1, 1, worksheet.UsedRange.LastRow, workbook.Worksheets[2].UsedRange.LastColumn);
                using (StreamWriter file = File.CreateText(@"F:\pessoa.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, pessoa);
                }
            }
            return @"F:\pessoa.json";
        }
        public void CreatePanilha(string caminhoNomeSalvar, string nome, string[] cabecalhos, string[] valores)
        {
            FileInfo caminhoNomeArquivo = new FileInfo(caminhoNomeSalvar);
            ExcelPackage arquivoExcel = new ExcelPackage(caminhoNomeArquivo);
            ExcelWorksheet planilha = arquivoExcel.Workbook.Worksheets.Add(nome);
            int linha = 1;
            int coluna = 1;
            int linhaInicioTabela;
            int tam = cabecalhos.Length - 1;

            planilha.Cells.Style.Font.Name = "Arial";
            planilha.Cells.Style.Font.Size = 11;
            linhaInicioTabela = linha;
            planilha.Cells[linha, coluna, linha, coluna + tam].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[linha, coluna, linha, coluna + tam].Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
            planilha.Cells[linha, coluna, linha, coluna + tam].Style.Font.Color.SetColor(Color.White);
            planilha.Cells[linha, coluna, linha, coluna + tam].Style.Font.Bold = true;
            planilha.Cells[linha, coluna, linha, coluna + tam].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            foreach (var cabecalho in cabecalhos)
            {
                planilha.Cells[linha, coluna++].Value = cabecalho;
                linha++;
            }
            linha++;
            foreach (var valor in valores)
            {
                coluna = 1;
                planilha.Cells[linha, coluna++].Value = valor;

            }
            coluna = 1;
            planilha.Cells[linhaInicioTabela, coluna, linha - 1, coluna + tam].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            planilha.Cells[linhaInicioTabela, coluna, linha - 1, coluna + tam].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            planilha.Cells[linhaInicioTabela, coluna, linha - 1, coluna + tam].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            planilha.Cells[linhaInicioTabela, coluna, linha - 1, coluna + tam].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            planilha.Cells[linhaInicioTabela, coluna, linha - 1, coluna + tam].AutoFitColumns();
            arquivoExcel.Save();
            arquivoExcel.SaveAs(caminhoNomeArquivo);
            arquivoExcel.Dispose();
        }
        /*
        public void Gerarar(String caminhoNomeSalvar)
        {
            FileInfo caminhoNomeArquivo = new FileInfo(caminhoNomeSalvar);

            ExcelPackage arquivoExcel = new ExcelPackage(caminhoNomeArquivo);
            ExcelWorksheet planilha = arquivoExcel.Workbook.Worksheets.Add("ExAutomovel");
            ExcelWorksheet planilha1 = arquivoExcel.Workbook.Worksheets.Add("CadAutomovel");

            int linha = 1;
            int coluna = 1;
            int linhaInicioTabela;
            int linha1 = 1;
            int coluna1 = 1;
            int linhaInicioTabela1;
            planilha.Cells.Style.Font.Name = "Arial";
            planilha.Cells.Style.Font.Size = 11;
            planilha1.Cells.Style.Font.Name = "Arial";
            planilha1.Cells.Style.Font.Size = 11;
            linhaInicioTabela1 = linha1;
            linhaInicioTabela = linha;
            planilha.Cells[linha, coluna, linha, coluna + 11].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha.Cells[linha, coluna, linha, coluna + 11].Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
            planilha.Cells[linha, coluna, linha, coluna + 11].Style.Font.Color.SetColor(Color.White);
            planilha.Cells[linha, coluna, linha, coluna + 11].Style.Font.Bold = true;
            planilha.Cells[linha, coluna, linha, coluna + 11].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            planilha.Cells[linha, coluna++].Value = "MARCA";
            planilha.Cells[linha, coluna++].Value = "MODELO";
            planilha.Cells[linha, coluna++].Value = "CILINDRAGEM";
            planilha.Cells[linha, coluna++].Value = "CLASSIFICACAO";
            planilha.Cells[linha, coluna++].Value = "PAIS";
            planilha.Cells[linha, coluna++].Value = "TIPO MATRICULA";
            planilha.Cells[linha, coluna++].Value = "TIPODEPINTURA";
            planilha.Cells[linha, coluna++].Value = "MOEDA";
            planilha.Cells[linha, coluna++].Value = "NIVERDEMPENHO";
            planilha.Cells[linha, coluna++].Value = "TIPOCORPO";
            planilha.Cells[linha, coluna++].Value = "TIPOMOTOR";
            planilha.Cells[linha, coluna++].Value = "LADO VOLANTE";

            linha++;
            planilha1.Cells[linha1, coluna1, linha1, coluna1 + 26].Style.Fill.PatternType = ExcelFillStyle.Solid;
            planilha1.Cells[linha1, coluna1, linha1, coluna1 + 26].Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
            planilha1.Cells[linha1, coluna1, linha1, coluna1 + 26].Style.Font.Color.SetColor(Color.White);
            planilha1.Cells[linha1, coluna1, linha1, coluna1 + 26].Style.Font.Bold = true;
            planilha1.Cells[linha1, coluna1, linha1, coluna1 + 26].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            planilha1.Cells[linha1, coluna1++].Value = "MATRICULA";
            planilha1.Cells[linha1, coluna1++].Value = "PAISDAMATRICULA";
            planilha1.Cells[linha1, coluna1++].Value = "DATADAPRIMEIRAMATRICULA";
            planilha1.Cells[linha1, coluna1++].Value = "CLASSIFICACAO";
            planilha1.Cells[linha1, coluna1++].Value = "POTENCIA";
            planilha1.Cells[linha1, coluna1++].Value = "TIPODEUSO";
            planilha1.Cells[linha1, coluna1++].Value = "COR";
            planilha1.Cells[linha1, coluna1++].Value = "TIPOPINTURA";
            planilha1.Cells[linha1, coluna1++].Value = "NUMERODELUGARES";
            planilha1.Cells[linha1, coluna1++].Value = "PESOBRUTO";
            planilha1.Cells[linha1, coluna1++].Value = "MOEDADEARQUISICAO";
            planilha1.Cells[linha1, coluna1++].Value = "NUMERODOMOTOR";
            planilha1.Cells[linha1, coluna1++].Value = "PROPRETARIO";
            planilha1.Cells[linha1, coluna1++].Value = "CONDUTOR";
            planilha1.Cells[linha1, coluna1++].Value = "CILINDRAGEM";
            planilha1.Cells[linha1, coluna1++].Value = "NUMEROCHASSI";
            planilha1.Cells[linha1, coluna1++].Value = "VALOREMNOVO";
            planilha1.Cells[linha1, coluna1++].Value = "MOEDADECOMPRAACTUAL";
            planilha1.Cells[linha1, coluna1++].Value = "VELOCIDADE(Km/h)";
            planilha1.Cells[linha1, coluna1++].Value = "LADODOVOLANTE";
            planilha1.Cells[linha1, coluna1++].Value = "NIVELDODESEMPENHO";
            planilha1.Cells[linha1, coluna1++].Value = "TIPODECORPO";
            planilha1.Cells[linha1, coluna1++].Value = "TIPODECAIXADEVELOCIDADE";
            planilha1.Cells[linha1, coluna1++].Value = "TIPODEMOTOR";
            planilha1.Cells[linha1, coluna1++].Value = "VALOREACTUAL";
            planilha1.Cells[linha1, coluna1++].Value = "ANODOVEICULO";
            planilha1.Cells[linha1, coluna1++].Value = "PESO";
            linha1++;
            var cilindragem = sqlrt<CilindragemAutomovel>("CilindragemAutomovel");
            var classificacao = sqlrt<ClassificacaoAutomovel>("ClassificacaoAutomovel");
            var pais = sqlrt<Pais>("Pais");
            var tipomatricula = sqlrt<TipoMatricula>("TipoMatricula");
            var moeda = sqlrt<Moeda>("Moeda");
            var tipopintura = sqlrt<TipoPintura>("TipoPintura");
            var NIVELDODESEMPENHO = sqlrt<NivelDesempenho>("NivelDesempenho");
            var TIPOCORPO = sqlrt<TipoCorpo>("TipoCorpo");
            var TIPOMOTOR = sqlrt<TipoMotor>("TipoMotor");
            var ladovolante = sqlrt<LadoVolante>("LadoVolante");
            var marca = sqlrt<MarcaAutomovel>("MarcaAutomovel");
            var modelo = sqlrt<ModeloAutomovel>("ModeloAutomovel");
            var marcamodelo = sqljoin<ExemplarModelo>("ModeloAutomovel,MarcaAutomovel", "ModeloAutomovel.MArcaAutomovelID=MarcaAutomovel.IdMarcaAutomovel", "Modelo,Marca", "order by Marca");
            var linhas = marcamodelo.Count() > cilindragem.Count() ? marcamodelo.Count() : cilindragem.Count();

            for (int i = 0; i < linhas; ++i)
            {
                coluna = 1;
                planilha.Cells[linha, coluna++].Value = marca.ElementAtOrDefault(i)?.Marca;
                planilha.Cells[linha, coluna++].Value = modelo.ElementAtOrDefault(i)?.Modelo;
                planilha.Cells[linha, coluna++].Value = cilindragem.ElementAtOrDefault(i)?.Cilindragem;
                planilha.Cells[linha, coluna++].Value = classificacao.ElementAtOrDefault(i)?.Categoria;
                planilha.Cells[linha, coluna++].Value = pais.ElementAtOrDefault(i)?.NomePais;
                planilha.Cells[linha, coluna++].Value = tipomatricula.ElementAtOrDefault(i)?.Designacao;
                planilha.Cells[linha, coluna++].Value = tipopintura.ElementAtOrDefault(i)?.TipoFinalizacao;
                planilha.Cells[linha, coluna++].Value = moeda.ElementAtOrDefault(i)?.Designacao;
                planilha.Cells[linha, coluna++].Value = NIVELDODESEMPENHO.ElementAtOrDefault(i)?.Designacao;
                planilha.Cells[linha, coluna++].Value = TIPOCORPO.ElementAtOrDefault(i)?.Designacao;
                planilha.Cells[linha, coluna++].Value = TIPOMOTOR.ElementAtOrDefault(i)?.Designacao;
                planilha.Cells[linha, coluna++].Value = ladovolante.ElementAtOrDefault(i)?.Designacao;


                linha++;
            }
            coluna = 1;
            coluna1 = 1;

            planilha.Cells[linhaInicioTabela, coluna, linha - 1, coluna + 11].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            planilha.Cells[linhaInicioTabela, coluna, linha - 1, coluna + 11].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            planilha.Cells[linhaInicioTabela, coluna, linha - 1, coluna + 11].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            planilha.Cells[linhaInicioTabela, coluna, linha - 1, coluna + 11].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            planilha.Cells[linhaInicioTabela, coluna, linha - 1, coluna + 11].AutoFitColumns();
            planilha1.Cells[linhaInicioTabela1, coluna1, linha1 - 1, coluna1 + 26].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            planilha1.Cells[linhaInicioTabela1, coluna1, linha1 - 1, coluna1 + 26].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            planilha1.Cells[linhaInicioTabela1, coluna1, linha1 - 1, coluna1 + 26].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            planilha1.Cells[linhaInicioTabela1, coluna1, linha1 - 1, coluna1 + 26].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            planilha1.Cells[linhaInicioTabela1, coluna1, linha1 - 1, coluna1 + 26].AutoFitColumns();
            arquivoExcel.Save();
            arquivoExcel.SaveAs(caminhoNomeArquivo);
            arquivoExcel.Dispose();
        }*/
        public List<dadosmodels> AddAutomovel(string path)
        {
            var file = File.ReadAllText(path);
            var objDeserialized = JsonConvert.DeserializeObject<List<dadosmodels>>(file);
            return objDeserialized;
        }
         public List<modelopessoa> AddPessoa(string path)
        {
            var file = File.ReadAllText(path);
            var objDeserialized = JsonConvert.DeserializeObject<List<modelopessoa>>(file);
            return objDeserialized;
        }
    }
}