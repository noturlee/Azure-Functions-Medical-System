using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace ConsolePOE
{

    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=sast10033808;AccountKey=x/P4l6aKIHS/8Ew1P2Ll2JbqwyPCzYVsdZT+ZGfB/gjy7vKVFGjePgUrbZUZ4+1Xaj42/UKF3yHi+AStlfFYbg==;EndpointSuffix=core.windows.net";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);

            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            CloudQueue queue = queueClient.GetQueueReference("sast10033808");

            await queue.CreateIfNotExistsAsync();

            string data1 = "7401113333081:Clicks Gateway:05 April 2022:ab3ds6sgbss8wsaz6xcv";
            string data2 = "8708094444087:01 January 2021:Dischem Pavillion:1y5df4z354f3f24g43g";
            string data3 = "0403765412873:02 May 2021:Clicks Pavillion:tyva2wji9y7lc5hf7an4";
            string data4 = "0404285075085:03 June 2021:Ghandi Hospital:x42p51q757w235z325";
            string data5 = "9708095554064:Fort Napier:04 February 2021:958734tg34tg34t543\n";

            List<string> dataList = new List<string>
            {
                data1,
                data2,
                data3,
                data4,
                data5
            };

            foreach (var data in dataList)
            {
                FormatMessage(data);
                CloudQueueMessage message = new CloudQueueMessage(data);
                await queue.AddMessageAsync(message);
            }

            Console.WriteLine("Messages added to the queue.");
        }

        static void FormatMessage(string data)
        {
            string[] parts = data.Split(':');

            if (parts.Length != 4)
            {
                throw new ArgumentException("Invalid data format.");
            }

            if (parts[0].Length == 13 && parts[3].Length==18)
            {
                // Format 1: Id:VaccinationCenter:VaccinationDate:VaccineSerialNumber
                Console.WriteLine("Message format detected: Id:VaccinationCenter:VaccinationDate:VaccineSerialNumber");
            }
            else if (parts[0].Length == 13 &&parts[2].Contains(" "))
            {
                // Format 2: Id:VaccinationDate:VaccinationCenter:VaccineBarCode
                Console.WriteLine("Message format detected: Id:VaccinationDate:VaccinationCenter:VaccineBarCode");
            }
            else
            {
                Console.WriteLine("Unusual Format detected");
            }
        }

    }
}
