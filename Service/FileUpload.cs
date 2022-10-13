using BlazorInputFile;

namespace BlazorUploadFile.Service
{
    public class FileUpload : IFileUpload
    {
        public readonly IWebHostEnvironment _environment;

        public FileUpload(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // methid for upload file to blazor server
        public async Task FileUploadAsync(IFileListEntry fileEntry)
        {
            // getting path to out server side folder
            string path = Path.Combine(_environment.ContentRootPath, "Upload", fileEntry.Name);

            // create MemoryStream for writting info on it
            MemoryStream ms = new MemoryStream();

            // copy information from file to our MemoryStream
            await fileEntry.Data.CopyToAsync(ms);

            // safety create FileStream for write our information to the server
            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                ms.WriteTo(file);
            }
        }
    }
}
