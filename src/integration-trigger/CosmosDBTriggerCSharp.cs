using System;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;


namespace Company.Function
{

    public class Order
    {
        public string id { get; set; }
        public string product { get; set; }
        public long quantity { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

    }
    public static class CosmosDBTriggerCSharp1
    {
        [FunctionName("CosmosDBTriggerCSharp1")]
        public static void Run([CosmosDBTrigger(
            databaseName: "FlavoredOfficeSupplies",
            collectionName: "Orders",
            ConnectionStringSetting = "demomtcappdevipaascdb_DOCUMENTDB",
            CreateLeaseCollectionIfNotExists = true,
            LeaseCollectionName = "leases")]IReadOnlyList<Document> input, ILogger log)
        {
            // URL for finalizer logic app
            string URL    = System.Environment.GetEnvironmentVariable($"orderProcessorLAEP");
            // APIM key
            string apiKey = System.Environment.GetEnvironmentVariable($"APIMKey");
            
            // TODO put code in here to ignore a delete case
            if (input != null && input.Count > 0)
            {
                log.LogInformation("Documents modified " + input.Count);
                log.LogInformation("First document Id " + input[0].Id);
            }
        
            // Process incoming order
            foreach (Document doc in input)
            {
                log.LogInformation("received doc: " + doc);

                Order order = new Order();
                order.id        = doc.GetPropertyValue<string>("id");
                order.product   = doc.GetPropertyValue<string>("product");
                order.quantity  = doc.GetPropertyValue<long>("quantity");
                order.email     = doc.GetPropertyValue<string>("email");
                
                // MOCK call to get address info
                order.address   = "123 Somewhere Ln.";
                order.firstName = "John";
                order.lastName  = "Doe";
                
                string jsonString = JsonConvert.SerializeObject(order);

                log.LogInformation("Updated order: " + jsonString);

                HttpClient client = new HttpClient();

                var request = new HttpRequestMessage() 
                {
                    RequestUri = new Uri(URL),
                    Method = HttpMethod.Post,
                    Content = new StringContent(jsonString)                        
                };

                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);

                HttpResponseMessage response = client.SendAsync(request).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.            
            }                               
        }
    }