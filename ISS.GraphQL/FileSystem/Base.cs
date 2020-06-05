using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FileSystem.FileSystem
{
    public class Base
    {
        public List<string> GetAllFtpFiles(string url)
        {
            try
            {
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create($"ftp://172.16.16.84/PessoaDocumento/{url}");
                ftpRequest.Credentials = new NetworkCredential("administrator", "hotelh.123");
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());

                List<string> directories = new List<string>();

                string line = streamReader.ReadLine();
                while (!string.IsNullOrEmpty(line))
                {
                    var lineArr = line.Split('/');
                    line = lineArr[lineArr.Count() - 1];
                    directories.Add(line);
                    line = streamReader.ReadLine();
                }

                streamReader.Close();

                return directories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void upload(string user, string docType, string fileName, string fileExtensao)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://172.16.16.84/PessoaDocumento/{user}/{docType}/{fileName}.{fileExtensao}");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential("administrator", "hotelh.123");
            byte[] bytes = System.IO.File.ReadAllBytes($"D:/Nada/Tesseract/pdf/{fileName}.{fileExtensao}");
            request.ContentLength = bytes.Length;
            using (Stream request_stream = request.GetRequestStream())
            {
                request_stream.Write(bytes, 0, bytes.Length);
                request_stream.Close();
            }
        }
        public string Download(string url)
        {

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://172.16.16.84/PessoaDocumento/{url}");
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential("administrator", "hotelh.123");
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
            reader.ReadToEnd();
            reader.Close();
            response.Close();
            return ($"Download Complete, status {response.StatusDescription}");
        }
        public string DeleteFile(string url)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://172.16.16.84/PessoaDocumento/{url}");
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential("administrator", "hotelh.123");
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                return response.StatusDescription;
            }
        }
        public string GetDirFile(string url)
        {
            List<string> liArquivos = new List<string>();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://172.16.16.84/PessoaDocumento/{url}");
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential("administrator", "hotelh.123");
            request.UsePassive = true;
            request.UseBinary = true;
            request.KeepAlive = true;
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Stream responseStream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    liArquivos = reader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>();
                }
            }
            foreach (string item in liArquivos)
            {
                return (item + "<br />");
            }
            return (liArquivos + "<br>");
        }
        // public IDirectoryContents GetDirectoryContents(string subpath)
        // {

        //     FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://www.contoso.com/");
        //     request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        //     request.Credentials = new NetworkCredential ("anonymous","janeDoe@contoso.com");
        //     FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        //     Stream responseStream = response.GetResponseStream();
        //     StreamReader reader = new StreamReader(responseStream);
        //     reader.ReadToEnd();
        //     // return ($"Directory List Complete, status {response.StatusDescription}");
        //     reader.Close();
        //     response.Close();
        // }

    }
}
