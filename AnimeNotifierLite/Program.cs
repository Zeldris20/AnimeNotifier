using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrl = "https://api.jikan.moe/v4/seasons/2023/Fall";

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(jsonResponse);
                JArray data = (JArray)json["data"];

                for (int i = 0; i < data.Count; i++)
                {
                    string title = (string)data[i]["title"];
                    Console.WriteLine($"{i + 1}. {title}");
                }

                Console.Write("Select an anime by entering its number: ");
                if (int.TryParse(Console.ReadLine(), out int userChoice) && userChoice >= 1 && userChoice <= data.Count)
                {
                    int selectedAnimeId = (int)data[userChoice - 1]["mal_id"];
                    string selectedAnimeUrl = $"https://api.jikan.moe/v4/anime/{selectedAnimeId}/full";
                    HttpResponseMessage detailedResponse = await client.GetAsync(selectedAnimeUrl);

                    if (detailedResponse.IsSuccessStatusCode)
                    {
                        string detailedJsonResponse = await detailedResponse.Content.ReadAsStringAsync();
                        JObject detailedJson = JObject.Parse(detailedJsonResponse);

                        // Accessing properties from the detailed JSON response
                        int year = (int)detailedJson["data"]["year"];
                        string day = (string)detailedJson["data"]["broadcast"]["day"];
                        string time = (string)detailedJson["data"]["broadcast"]["time"];
                        string timezone = (string)detailedJson["data"]["broadcast"]["timezone"];

                        Console.WriteLine("Selected Anime Details:");
                        Console.WriteLine($"Year: {year}");
                        Console.WriteLine($"Day: {day}");
                        Console.WriteLine($"Time: {time}");
                        Console.WriteLine($"Timezone: {timezone}");
                    }
                    else
                    {
                        Console.WriteLine("Error fetching detailed data from API: " + detailedResponse.StatusCode);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Error fetching data from API: " + response.StatusCode);
            }
        }
    }
}