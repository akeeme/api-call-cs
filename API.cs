using System.Net.Http.Json;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Text.Json.Serialization;

namespace API{
    class Cars{
        [JsonPropertyName("Model_Name")]
        public string? Model_Name { get; set; }

        [JsonPropertyName("Make_Name")]
        public string? Make_Name { get; set; }

        [JsonPropertyName("Model_ID")]
        public int Model_ID { get; set; }
    }

    class CarResponse{
        [JsonPropertyName("Count")]
        public int Count { get; set; }

        [JsonPropertyName("Message")]
        public string? Message { get; set; }

        [JsonPropertyName("SearchCriteria")]
        public string? SearchCriteria { get; set; }

        [JsonPropertyName("Results")]
        public List<Cars>? Results { get; set; }
    }

    public class Program{
        private static readonly HttpClient client = new HttpClient();
        
        static async Task Main(string[] args){
            await GetCars();
        }

        static async Task GetCars(){
            while (true){
                try{
                    Console.WriteLine("Enter Car Manufacturer");
                    string? manufacturer = Console.ReadLine();


                    if(string.IsNullOrWhiteSpace(manufacturer)){
                        break;
                    }

                    Console.WriteLine("Amount of cars to display");
                    int amount = int.Parse(Console.ReadLine()!);


                    // var result = await client.GetAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/{manufacturer.ToLower()}?format=json").Result.Content.ReadAsStringAsync();
                    // var resultRead = JsonSerializer.Deserialize<Cars>(result);

                    var result = await client.GetFromJsonAsync<CarResponse>($"https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/{manufacturer.ToLower()}?format=json", new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    if(result?.Count == 0){
                        Console.WriteLine("No cars found!");
                        continue;
                    }

                    if(result?.Count < amount){
                        amount = result.Count;
                    }

                    Console.WriteLine("Make\t\t|\t\tModel\t\t|\t\tID");
                    
                    for (int i = 0; i < amount; i++){
                        Console.WriteLine($"{result?.Results?[i]?.Make_Name}\t\t\t\t{result?.Results?[i]?.Model_Name}\t\t\t\t{result?.Results?[i]?.Model_ID}");
                    }
                }
                catch (HttpRequestException e){
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}