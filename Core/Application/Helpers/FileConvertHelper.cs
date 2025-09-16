using Microsoft.AspNetCore.Http;

namespace Application.Helpers;

public static class FileConvertHelper
{
    public static async Task<byte[]> ConvertToByteArrayAsync(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return Array.Empty<byte>();
        using (var ms = new System.IO.MemoryStream())
        {
            await file.CopyToAsync(ms);
            return ms.ToArray();
        }
    }
}
