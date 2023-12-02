
using AzureOpenAIConnector;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChatGpt
{
     class Program
    {
       public static string URL = "https://api.openai.com/v1/engines/text-davinci-003/completions";
       public static  string key = "API";
    
       public static async Task Main(string[] args)
          
        {
            string Question = Console.ReadLine();
            string respo = await StartAI(URL, key, Question);
            await Console.Out.WriteLineAsync(respo);

        }
        public static async Task<string> StartAI(string url,string key,string Question)
        {
            var requestQ = new
            {
                prompt = Question,
                max_tokens = 50,
            };
            string json = JsonConvert.SerializeObject(requestQ);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var res = await client.PostAsync(url, content);

                string result = await res.Content.ReadAsStringAsync();
                return result;
            }                                             
        }                                                     
    }                                                         
}