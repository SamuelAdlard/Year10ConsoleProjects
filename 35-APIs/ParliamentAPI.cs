using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _35_APIs
{
    public class ParliamentAPI
    {
        public async static void GetData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get, 
                RequestUri = new Uri("https://members-api.parliament.uk/api/Members/Search?House=1&skip=0&take=20")
            };
            List<MP> MPs = new List<MP>();
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                JsonDocument document = JsonDocument.Parse(json);
                Console.WriteLine(document);
                var MPlist = document.RootElement.GetProperty("items").EnumerateArray();
                
                foreach (JsonElement element in MPlist)
                {
                    var value = element.GetProperty("value");
                    MP newMP = new MP
                    (
                        value.GetProperty("nameFullTitle").ToString(),
                        value.GetProperty("latestParty").GetProperty("name").ToString()
                    ); 
                    MPs.Add(newMP);
                }

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://members-api.parliament.uk/api/Members/Search?House=1&skip=0&take=20")
                };
            }
            
            PrintResult(MPs);

        }

        static void PrintResult(List<MP> MPs)
        {
            foreach (MP mp in MPs)
            {
                mp.Print();
            }
        }

    }
}
