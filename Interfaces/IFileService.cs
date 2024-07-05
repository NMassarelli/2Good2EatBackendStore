using Microsoft.AspNetCore.Components.Forms;

namespace _2Good2EatStore.Data.Interfaces
{
    public interface IFileService
    {
        int GetReadStreamSize();
        Task<string> MoveFileToRoot(IBrowserFile file);
    }
}
