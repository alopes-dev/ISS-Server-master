using System;
using System.Collections.Generic;
using Tesseract;
using System.Diagnostics;
using System.IO;
namespace ISWebApp.Services
{
  public interface Ocr
  {
   void Processardocumentos();
   void Print(ResultIterator iter);
  }

}