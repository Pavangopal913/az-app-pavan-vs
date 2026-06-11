using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Identity.Client;

namespace Mvc.StorageAccount.Demo.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient _blobServiceClient;
        private string containerName = "attendeeimages";
        public BlobStorageService(IConfiguration configuration, BlobServiceClient blobServiceClient)
        {
            _configuration = configuration;
            _blobServiceClient = blobServiceClient;
        }

        public async Task<string> UploadBlob(IFormFile formFile, string imageName, string? originalImageName = null)
        {
            var blobName = $"{imageName}{Path.GetExtension(formFile.FileName)}";
            var container = _blobServiceClient.GetBlobContainerClient(containerName);

            if (!String.IsNullOrEmpty(originalImageName))
            {
                await RemoveBlob(originalImageName);
            }

            using var memoryStream = new MemoryStream();
            formFile.CopyTo(memoryStream);
            memoryStream.Position = 0;
            var blob = container.GetBlobClient(blobName);
            await blob.UploadAsync(content: memoryStream, overwrite: true);
            return blobName;
        }

        public async Task<string> GetBlobUrl(string imageName)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);

            var blob = container.GetBlobClient(imageName);

            BlobSasBuilder blobSasBuilder = new()
            {
                BlobContainerName = blob.BlobContainerName,
                BlobName = blob.Name,
                ExpiresOn = DateTimeOffset.UtcNow.AddMinutes(2),
                Protocol = SasProtocol.Https,
                Resource = "b"
            };

            blobSasBuilder.SetPermissions(BlobSasPermissions.Read);

            return blob.GenerateSasUri(blobSasBuilder).ToString();
        }

        public async Task RemoveBlob(string imageName)
        {
            var container = _blobServiceClient.GetBlobContainerClient(containerName);
            var blob = container.GetBlobClient(imageName);
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }

        private async Task<BlobContainerClient> GetBlobContainerClient()
        {
            try
            {
                BlobContainerClient container = new BlobContainerClient(_configuration["StorageConnectionString"], containerName);
                await container.CreateIfNotExistsAsync();

                return container;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
