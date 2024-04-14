using netConsoleTest.Models;
using Newtonsoft.Json;

namespace netConsoleTest.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            await Read();
        }

        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5029/api/Blog");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();

                // JsonConvert.SerializeObject();  //c# object to json
                // JsonConvert.DeserializeObject();  // json to c# object

                List<BlogDataModel> lst = JsonConvert.DeserializeObject<List<BlogDataModel>>(jsonStr)!;

                foreach (BlogDataModel ea in lst)
                {
                    Console.WriteLine(ea.Blog_Author);
                    Console.WriteLine(ea.Blog_Title);
                    Console.WriteLine(ea.Blog_Content);
                }
            }
        }
    }

}