using BlazorInputFile;

namespace BlazorUploadFile.Service
{
    public interface IFileUpload
    {
        Task FileUploadAsync(IFileListEntry file);
    }
}
