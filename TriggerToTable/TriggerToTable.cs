using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class QueueTriggerFunction
{
    [FunctionName("QueueTriggerFunction")]
    public static async Task Run([QueueTrigger("sast10033808", Connection = "AzureWebJobsStorage")] string myQueueItem, ILogger log)
    {
        string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
        string tableName = "VaccData";

        try
        {
            string id = ExtractValue(myQueueItem, @"\b\d{13}\b");
            string vaccinationCenter = ExtractValue(myQueueItem, @"(?<=:)[A-Za-z\s]+(?=:)");
            string vaccinationDate = ExtractValue(myQueueItem, @"\d{1,2}\s+(?:January|February|March|April|May|June|July|August|September|October|November|December)\s+\d{4}");
            string vaccineSerialNumberOrBarcode = ExtractValue(myQueueItem, @"(?<=:)[A-Za-z0-9\s]+(?=$)");

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(vaccinationCenter) || string.IsNullOrEmpty(vaccinationDate) || string.IsNullOrEmpty(vaccineSerialNumberOrBarcode))
            {
                log.LogInformation("Invalid data format");
            }
            else
            {
                await InsertEntity(storageAccount, tableName, id, vaccinationCenter, vaccinationDate, vaccineSerialNumberOrBarcode);
                log.LogInformation("Data inserted into table storage");
            }
        }
        catch (Exception ex)
        {
            log.LogInformation($"Invalid data format: {myQueueItem}");
        }
    }

    static async Task InsertEntity(CloudStorageAccount storageAccount, string tableName, string id, string vaccinationCenter, string vaccinationDate, string vaccineSerialNumberOrBarcode)
    {
        CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
        CloudTable table = tableClient.GetTableReference(tableName);
        await table.CreateIfNotExistsAsync();

        CustomEntity entity = new CustomEntity(id, vaccinationCenter, vaccinationDate, vaccineSerialNumberOrBarcode);
        TableOperation insertOperation = TableOperation.Insert(entity);
        await table.ExecuteAsync(insertOperation);
    }

    public class CustomEntity : TableEntity
    {
        public CustomEntity(string id, string vaccinationCenter, string vaccinationDate, string vaccineSerialNumberOrBarcode)
        {
            RowKey = id;

            PartitionKey = "ID";
            VaccinationCenter = vaccinationCenter;
            VaccinationDate = vaccinationDate;
            VaccineSerialNumberOrBarcode = vaccineSerialNumberOrBarcode;
        }

        public CustomEntity() { }

        public string VaccinationCenter { get; set; }
        public string VaccinationDate { get; set; }
        public string VaccineSerialNumberOrBarcode { get; set; }
    }

    private static string ExtractValue(string input, string pattern)
    {
        Match match = Regex.Match(input, pattern);
        return match.Success ? match.Value.Trim() : null;
    }
}
