using MiX.ResourceData.Client;


string resourceDataUri = "http://resourcedata.int.development.domain.local";
long assetId = 958802356208365568;

await ResourceDataClient.RegisterRepositoryAsync(resourceDataUri).ConfigureAwait(false);

var latestTripForAsset = (await ResourceDataClient.Trips.GetLatestAsync(new List<long>() { assetId }, 1).ConfigureAwait(false)).FirstOrDefault();

if (DateTime.UtcNow.Subtract(latestTripForAsset.EndDateTime).TotalHours > 5)
    Console.WriteLine("Trip is too old, there is a problem");

Console.Read();