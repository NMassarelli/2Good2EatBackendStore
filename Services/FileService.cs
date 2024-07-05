using _2Good2EatStore.Data.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using System.Reflection.Metadata;

namespace _2Good2EatStore.Data.Services
{
    public class FileService(IWebHostEnvironment webHostEnvironment) : IFileService
    {

        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
        public const int ReadStreamSizeMax = 5000000;

        public int GetReadStreamSize()
        {
            return ReadStreamSizeMax;
        }
        public async Task<string> MoveFileToRoot(IBrowserFile file)
        {
            try
            {
                FileInfo fileInfo = new(file.Name);
                var fileName = file.Name + fileInfo.Extension;
                var folderDirectory = $"{_webHostEnvironment.WebRootPath}\\Images";
                var path = Path.Combine(_webHostEnvironment.WebRootPath, "Images", fileName);
    
                var memoryStream = new MemoryStream();
                await file.OpenReadStream(ReadStreamSizeMax).CopyToAsync(memoryStream);

                if (!Directory.Exists(folderDirectory))
                {
                    Directory.CreateDirectory(folderDirectory);
                }

                await using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    memoryStream.WriteTo(fs);
                }


                return path;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message, e);
            }
        }

    }
}
