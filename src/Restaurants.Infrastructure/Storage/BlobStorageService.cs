using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using Restaurants.Domain.Interfaces;
using Restaurants.Infrastructure.Configoration;

namespace Restaurants.Infrastructure.Storage;

internal class BlobStorageService(IOptions<BlobStorageSettings> blobStorageSettingsOptions) : IBlobStorageService
{
    private readonly BlobStorageSettings _blobStorageSettings = blobStorageSettingsOptions.Value;

    public async Task<string> UploadToBlobAsync(Stream data, string fileName)
    {
      var blobServiceClient = new BlobServiceClient(_blobStorageSettings.ConnectionString);
      var blobContainerClient = blobServiceClient.GetBlobContainerClient(_blobStorageSettings.LogosContainerName);

        var blobClient = blobContainerClient.GetBlobClient(fileName);
        await blobClient.UploadAsync(data,true);

        var blobUri = blobClient.Uri.ToString();
        return blobUri;
    }
}
