using System.Net.Http.Json;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Text.Json.Serialization;

namespace NewAPI{
    class Cars{
        [JsonPropertyName("Model_Name")]
        public string? Model_Name { get; set; }

        [JsonPropertyName("Make_Name")]
        public string? Make_Name { get; set; }

        [JsonPropertyName("ID")]
        public int Model_ID { get; set; }
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

                    // var result = await client.GetAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/{manufacturer.ToLower()}?format=json").Result.Content.ReadAsStringAsync();
                    // var resultRead = JsonSerializer.Deserialize<Cars>(result);

                    var result = await client.GetFromJsonAsync<Cars>($"https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/{manufacturer.ToLower()}?format=json", new JsonSerializerOptions(JsonSerializerDefaults.Web));

                    Console.WriteLine(result!.Make_Name);

                    // make list to contain all the cars inside response
                    // var cars = new List<Cars>();

                    // add cars to list
                    // cars.Add(resultRead!);

                    // loop through cars list

                    // print length of list
                    // Console.WriteLine($"There are {cars.Count} cars in the list");


                    // foreach (var car in cars){
                    //     Console.WriteLine($"The {car.Make_Name} {car.Model_Name} has an ID of {car.Model_ID}");
                    // }

                    // print response object to console for debugging
                    // Console.WriteLine(result);
    
                    // Console.WriteLine($"The {result?.Make_Name} {result?.Model_Name} has an ID of {result?.Model_ID}");
                }
                catch (HttpRequestException e){
                    Console.WriteLine($"Request exception: {e.Message}");
                }
            }
        }
    }
}