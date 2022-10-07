using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;


// namespace API{
//     class Cars{
//         public string? Model_Name { get; set; }
//         public string? Make_Name { get; set; }
//         public int Model_ID { get; set; }
//     }

//     public class Program{
//         private static readonly HttpClient client = new HttpClient();
        
//         static async Task Main(string[] args){
//             await GetCars();
//         }

//         static async Task GetCars(){
//             while (true){
//                 try{
//                     Console.WriteLine("Enter Car Manufacturer");
//                     string? manufacturer = Console.ReadLine();

//                     if(string.IsNullOrWhiteSpace(manufacturer)){
//                         break;
//                     }

//                     var result = await client.GetStringAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/getmodelsformake/{manufacturer.ToLower()}?format=json");
//                     var resultRead = await result.Content.ReadAsStringAsync();

//                     Console.WriteLine(resultRead);


//                     Console.WriteLine($"The {resultRead?.Make_Name} {resultRead?.Model_Name} has an ID of {resultRead?.Model_ID}");
//                 }
//                 catch (HttpRequestException e){
//                     Console.WriteLine($"Request exception: {e.Message}");
//                 }
//             }
//         }
//     }
// }

// private static readonly HttpClient client = new HttpClient();

// https://vpic.nhtsa.dot.gov/api/vehicles/getallmanufacturers?format=json
// private static async Task ProcessRepositories(){


//     while (true)
//     {
//         try
//         {
//             Console.WriteLine("Enter Car Manufacturer");

//             var carName = Console.ReadLine();

//             if (string.IsNullOrWhiteSpace(carName))
//             {
//                 break;
//             }

//             var result = await client.GetStringAsync($"https://vpic.nhtsa.dot.gov/api/vehicles/GetModelsForMake/{carName.ToLower()}?format=json");
//             var resultRead = JsonConvert.DeserializeObject<Root>(result);
//         }

//         catch (Exception)
//         {
//             Console.WriteLine("ERROR. Please enter a valid car manufacturer.");
//         }
//     }

// }

