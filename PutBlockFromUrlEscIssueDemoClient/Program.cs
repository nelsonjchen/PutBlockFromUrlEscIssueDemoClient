// Please see README.md for more information.

using System;
using System.Globalization;
using System.IO;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;

var connectionString = Environment.GetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING");

if (connectionString == null)
{
    Console.WriteLine(
        "Set the environment variable AZURE_STORAGE_CONNECTION_STRING to your storage account connection string.");
    return;
}

Console.WriteLine("Start Download @ " + DateTime.Now.ToString(CultureInfo.CurrentCulture));

BlobServiceClient blobServiceClient = new(connectionString);
BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("some-container");
BlockBlobClient blobClient = containerClient.GetBlockBlobClient("test-file.dat");
// Azure unescapes the %2F in this URL unnecessarily.
Uri uri = new("https://put-block-from-url-esc-issue-demo-server-3vngqvvpoq-uc.a.run.app/red%2Fblue.txt");
var response = blobClient.SyncUploadFromUri(uri, true);
var dl = blobClient.Download();
Console.WriteLine($"====\n{new StreamReader(dl.Value.Content).ReadToEnd()}\n====\n");
Console.WriteLine("Finished @ " + DateTime.Now.ToString(CultureInfo.CurrentCulture));