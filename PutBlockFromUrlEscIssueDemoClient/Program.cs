// See https://aka.ms/new-console-template for more information

using System;
using System.Threading;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

Console.WriteLine("Hello, World!");

string? connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

if (connectionString == null) 
{
    Console.WriteLine("Set the environment variable AZURE_STORAGE_CONNECTION_STRING to your storage account connection string.");
    return;
}

BlobServiceClient blobServiceClient = new(connectionString);
BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("test-storage");
BlockBlobClient blobClient = containerClient.GetBlockBlobClient("test-file");
Uri uri = new("http://example.com");
var response = blobClient.SyncUploadFromUri(uri, true, CancellationToken.None);
 

