using ISS.Application.Dto;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace FileSystem.FileSystem
{
    public class FileSystemManager : IFileInfo, IFileProvider
    {

        #region Default
        public string Path { get; set; }
        public string PhysicalPath => throw new NotImplementedException();
        public string Name => System.IO.Path.GetFileName(Path);
        public bool Exists => File.Exists(Path) || Directory.Exists(Path);
        public long Length => Exists && !IsDirectory ? new FileInfo(Path).Length : -1;
        public DateTime ModifiedOn => !string.IsNullOrEmpty(Path) ? File.GetLastWriteTime(Path) : default;
        public bool IsDirectory => Directory.Exists(Path);
        public DateTimeOffset LastModified => throw new NotImplementedException();
        public IFileInfo GetFileInfo(string subpath)
        {
            throw new NotImplementedException();
        }

        public IDirectoryContents GetDirectoryContents(string subpath)
        {
            throw new NotImplementedException();
        }

        public IChangeToken Watch(string filter)
        {
            throw new NotImplementedException();
        }
        public Stream CreateReadStream()
        {
            return
             IsDirectory
                 ? throw new InvalidOperationException($"Não é possível abrir '{Path}' para leitura porque é um diretório.")
                 : Exists
                     ? File.OpenRead(Path)
                     : throw new InvalidOperationException($"Não é possível abrir '{Path}' para leitura porque o arquivo não existe.");
        }
        #endregion

        #region Config
        public string baseUrl = "ftp://172.16.16.84/";
        public string user = "administrator";
        public string password = "hotelh.123";

        public Dictionary<string, string> mapTypes = new Dictionary<string, string> {
            { "mp3", "audios" },
            { "wav", "audios" },
            { "mp4a", "audios" },
            { "wmv", "audios" },
            { "mp4", "videos" },
            { "vob", "videos" },
            { "avi", "videos" },
            { "webm", "videos" },
            { "flv", "videos" },
            { "mkv", "videos" },
            { "mov", "videos" },
            { "pdf", "documentos" },
            { "txt", "documentos" },
            { "docx", "documentos" },
            { "jpg", "imagens" },
            { "gif", "imagens" },
            { "bmp", "imagens" },
            { "svg", "imagens" },
            { "exif", "imagens" },
            { "bitmap", "imagens" },
            { "png", "imagens" },
        };

        #endregion
        public FileSystemManager SetPath(string p)
        {
            this.Path = p;
            return this;
        }

        public FtpWebRequest FtpWebConnector(string url, string method)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create($"{baseUrl}{url}");
            ftpRequest.Method = method;
            ftpRequest.Credentials = new NetworkCredential(user, password);
            return ftpRequest;
        }


        public FtpWebResponse FtpWebGet(string url, string method)
            => (FtpWebResponse)this.FtpWebConnector(url, method).GetResponse();


        public List<string> GetAllFtpFiles(string url)
        {
            try
            {
                FtpWebResponse response = this.FtpWebGet(url, WebRequestMethods.Ftp.ListDirectory);
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

                // streamReader.Close();
                return directories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<string> GetAllFtps()
        {
            try
            {
                FtpWebResponse response = this.FtpWebGet($"Documento/", WebRequestMethods.Ftp.ListDirectory);
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

                // streamReader.Close();
                return directories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region create Dir
        public string CreateUserDirStruct(string id, string dirprincipal)
        {
            try
            {
                    var res = CreateDir($"Documento/{dirprincipal}");
                    var re = CreateDir($"Documento/{res}/{id}");
                    CreateDir($"{re}/audios");
                    CreateDir($"{re}/videos");
                    CreateDir($"{re}/imagens");
                    CreateDir($"{re}/documentos");
    
                return ($"Documento/{dirprincipal}/{id}/");
            }
            catch (Exception e)
            {
                return ("Erro: " + e.Message);
            }

        }

        public string CreateDir(string url)
        {
            var rt = GetAllFtps();
            var t = rt.Contains(url);
            if (t == true) { this.FtpWebGet(url, WebRequestMethods.Ftp.MakeDirectory); }
            else { return url; }
            return url;
        }

        #endregion

        #region Operations
        public FtpWebRequest DeleteFile(string url)
        {
            return this.FtpWebConnector(url, WebRequestMethods.Ftp.DeleteFile);
        }
        public string Upload(string url, FileDto file)
        {

            // url // .../.../

            // url// .../.../documentos/pdf/
            url += $"/{this.MapTypes(file.Extensao)}/{Guid.NewGuid()}-{file.Nome}.{file.Extensao.Replace(".", "")}";
            var request = this.FtpWebConnector(url, WebRequestMethods.Ftp.UploadFile);
            byte[] bytes = Convert.FromBase64String(file.Data);
            request.ContentLength = bytes.Length;
            using (Stream request_stream = request.GetRequestStream())
            {
                request_stream.Write(bytes, 0, bytes.Length);
                request_stream.Close();
            }
            return ("sucesso");
        }
        public string Upload(string url, ICollection<FileDto> files)
        {

            // url // .../.../

            // url// .../.../documentos/pdf/
            foreach (var file in files)
            {
                var purl = $"/{this.MapTypes(file.Extensao)}/{Guid.NewGuid()}-{file.Nome}.{file.Extensao.Replace(".", "")}";
                var request = this.FtpWebConnector(url + purl, WebRequestMethods.Ftp.UploadFile);
                byte[] bytes = Convert.FromBase64String(file.Data);
                request.ContentLength = bytes.Length;
                using (Stream request_stream = request.GetRequestStream())
                {
                    request_stream.Write(bytes, 0, bytes.Length);
                    request_stream.Close();
                }
            }
            return ("sucesso");
        }
        public string DownloadFile(string url)
        {
            var response = this.FtpWebGet(url, WebRequestMethods.Ftp.DownloadFile);
            Stream esponseStream = response.GetResponseStream();
            byte[] buffer = new byte[2048];
            return ($"status {response.StatusDescription}");
        }
        public string MapTypes(string str)
        {
            // Verificar a str
            if (string.IsNullOrEmpty(str)) return null;
            // Verificar .pdf / pdf
            str = str.Replace(".", "");
            return mapTypes.FirstOrDefault(x => x.Key == str).Value;
        }
        #endregion
    }
}