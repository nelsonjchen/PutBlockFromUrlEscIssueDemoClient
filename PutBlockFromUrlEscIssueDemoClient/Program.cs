// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;


string? connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

if (connectionString == null) 
{
    Console.WriteLine("Set the environment variable AZURE_STORAGE_CONNECTION_STRING to your storage account connection string.");
    return;
}

BlobServiceClient blobServiceClient = new(connectionString);
BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("some-container");
BlockBlobClient blobClient = containerClient.GetBlockBlobClient("test-file");
Uri uri = new("https://put-block-from-url-esc-issue-demo-server-3vngqvvpoq-uc.a.run.app");
var response = blobClient.SyncUploadFromUri(uri, true);
var dl = blobClient.Download();
Console.WriteLine($"====\n{new StreamReader(dl.Value.Content).ReadToEnd()}\n====\n") ;
 

