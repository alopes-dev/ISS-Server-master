using System;
// using Tesseract;
using System.Diagnostics;
using System.IO;
//using iTextSharp.text.pdf;
//using iTextSharp.text;
//using iTextSharp.text.pdf.parser;
using System.Text;
using ISWebLib.Extensions;
//using Org.BouncyCastle.Asn1.Tsp;
using System.Drawing;
// using iTextSharp.text.pdf;
// using iTextSharp.text.pdf.parser;

namespace ISWebApp.Services
{
    public class OCRProcessor
    {

        public string Root { get; set; } = BackFolder(AppDomain.CurrentDomain.BaseDirectory, 4) + @"\\Services\\OCR\\";
        // public string ImgRead(string str)
        // {
        //     // try
        //     // {
        //     //     var logger = new FormattedConsoleLogger();
        //     //     using (var engine = new TesseractEngine($@"{Root}tesseracteng/tesseractocr/tessdata", "eng", EngineMode.Default))
        //     //     {
        //     //         using (var img = Pix.LoadFromFile(str))
        //     //         {
        //     //             using (logger.Begin("Processar a Imagem"))
        //     //             {
        //     //                 using (var page = engine.Process(img))
        //     //                 {
        //     //                     return page.GetText();
        //     //                 }
        //     //             }
        //     //         }
        //     //     }
        //     // }
        //     // catch (Exception e)
        //     // {
        //     //     return e.ToString();
        //     // }

        // }
        static string BackFolder(string path, int n)
        {
            for (int i = 0; i < n; i++)
                path = Directory.GetParent(path).FullName;
            return path;
        }
        // public string PdfReader(string base64)
        // {
        // //    var reader = new PdfReader(Convert.FromBase64String(base64));
        // //    string text = string.Empty;
        // //    for (int page = 1; page <= reader.NumberOfPages; page++)
        // //    {
        // //        text += PdfTextExtractor.GetTextFromPage(reader, page);
        // //    }
        // //    reader.Close();
        // //    return text;
        // }
    }
}
