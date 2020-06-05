// using System;
// using IronOcr;
// using System.Collections.Generic;
// using System.IO;

// namespace ISWebApp.Services
// {
//      public class Ironocr64
//     {
//         public string Nome { get; set; }
//         public string Extensao { get; set;}
//         public string Data { get; set; }
//     }
//     class IRonOcr
//     {
//          public string Root { get; set; } = BackFolder(AppDomain.CurrentDomain.BaseDirectory, 4) + @"\\Services\\OCR\\";
//            static string BackFolder(string path, int n)
//         {
//             for (int i = 0; i < n; i++)
//                 path = Directory.GetParent(path).FullName;
//             return path;
//         }
//         public void TestRead(string str)
//         {
//             var Ocr = new AdvancedOcr()
//             {
//                 Language = IronOcr.Languages.English.OcrLanguagePack,
//                 ColorSpace = AdvancedOcr.OcrColorSpace.GrayScale,
//                 EnhanceResolution = true,
//                 EnhanceContrast = true,
//                 CleanBackgroundNoise = true,
//                 ColorDepth = 4,
//                 RotateAndStraighten = false,
//                 DetectWhiteTextOnDarkBackgrounds = false,
//                 ReadBarCodes = true,
//                 Strategy = AdvancedOcr.OcrStrategy.Fast,
//                 InputImageType = AdvancedOcr.InputTypes.Document
//             };
//             // var results = Ocr.Read(Convert.FromBase64String(str));
//             var results = Ocr.ReadPdf(Convert.FromBase64String(str));

            
//             foreach (var page in results.Pages)
//             {
//                 // page object
//                 int page_number = page.PageNumber;
//                 String page_text = page.Text;
//                 int page_wordcount = page.WordCount;
//                 List<OcrResult.OcrBarcode> barcodes = page.Barcodes;
//                 System.Drawing.Image page_image = page.Image;
//                 int page_width_px = page.Width;
//                 int page_height_px = page.Height;
//                 foreach (var paragraph in page.Paragraphs)
//                 {
//                     // pages -> paragraphs
//                     int paragraph_number = paragraph.ParagraphNumber;
//                     String paragraph_text = paragraph.Text;
//                     System.Drawing.Image paragraph_image = paragraph.Image;
//                     int paragraph_x_location = paragraph.X;
//                     int paragraph_y_location = paragraph.Y;
//                     int paragraph_width = paragraph.Width;
//                     int paragraph_height = paragraph.Height;
//                     double paragraph_ocr_accuracy = paragraph.Confidence;
//                     string paragraph_font_name = paragraph.FontName;
//                     double paragraph_font_size = paragraph.FontSize;
//                     OcrResult.TextFlow paragrapth_text_direction = paragraph.TextDirection;
//                     double paragrapth_rotation_degrees = paragraph.TextOrientation;
//                     foreach (var line in paragraph.Lines)
//                     {
//                         // pages -> paragraphs -> lines
//                         int line_number = line.LineNumber;
//                         String line_text = line.Text;
//                         System.Drawing.Image line_image = line.Image;
//                         int line_x_location = line.X;
//                         int line_y_location = line.Y;
//                         int line_width = line.Width;
//                         int line_height = line.Height;
//                         double line_ocr_accuracy = line.Confidence;
//                         double line_skew = line.BaselineAngle;
//                         double line_offset = line.BaselineOffset;
//                         foreach (var word in line.Words)
//                         {
//                             // pages -> paragraphs -> lines -> words
//                             int word_number = word.WordNumber;
//                             String word_text = word.Text;
//                             System.Drawing.Image word_image = word.Image;
//                             int word_x_location = word.X;
//                             int word_y_location = word.Y;
//                             int word_width = word.Width;
//                             int word_height = word.Height;
//                             double word_ocr_accuracy = word.Confidence;
//                             String word_font_name = word.FontName;
//                             double word_font_size = word.FontSize;
//                             bool word_is_bold = word.FontIsBold;
//                             bool word_is_fixed_width_font = word.FontIsFixedWidth;
//                             bool word_is_italic = word.FontIsItalic;
//                             bool word_is_serif_font = word.FontIsSerif;
//                             bool word_is_underlined = word.FontIsUnderlined;
//                             foreach (var character in word.Characters)
//                             {
//                                 // pages -> paragraphs -> lines -> words -> characters
//                                 int character_number = character.CharacterNumber;
//                                 String character_text = character.Text;
//                                 System.Drawing.Image character_image = character.Image;
//                                 int character_x_location = character.X;
//                                 int character_y_location = character.Y;
//                                 int character_width = character.Width;
//                                 int character_height = character.Height;
//                                 double character_ocr_accuracy = character.Confidence;
//                             }
//                         }
//                     }
//                 }
//             }
           
//         }
//     }
// }