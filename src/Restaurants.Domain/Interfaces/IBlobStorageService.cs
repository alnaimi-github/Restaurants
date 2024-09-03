namespace Restaurants.Domain.Interfaces;

public interface IBlobStorageService
{
    string? GetBlobSasUrl(string? bloburl);
    Task<string> UploadToBlobAsync(Stream data,string fileName);
}
