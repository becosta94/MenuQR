using BlazorInputFile;

namespace MenuQR.Application.Interfaces
{
    public interface IFileUpload
    {
        Task UploadAsync(IFileListEntry arquivo);
    }
}
