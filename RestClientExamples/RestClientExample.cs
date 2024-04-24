using System.Net.Mime;
using System.Text;
using netConsoleTest.Models;
using Newtonsoft.Json;
using RestSharp;

namespace netConsoleTest.RestClientExamples
{
    public class RestClientExample
    {

        private readonly string _url = "http://localhost:5029/api/Blog";
        public async Task Run()
        {
            // await Read();
            // await Edit(9);
            // await Create("gg test 3", "gg test 3", "gg test 3");
            // await Update(9, "gg test update", "gg test update", "gg test update");
            await Read();

        }

        private async Task Read()
        {
            RestRequest restRequest = new RestRequest(_url, Method.Get);
            RestClient restClient = new RestClient();
            RestResponse response = await restClient.ExecuteAsync(restRequest);
            // HttpClient client = new HttpClient();
            // HttpResponseMessage response = await client.GetAsync($"{_url}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;

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
            else
            {
                Console.WriteLine(response.Content);
            }
        }

        public async Task Edit(int id)
        {
            RestRequest restRequest = new RestRequest($"{_url}/{id}", Method.Get);
            RestClient restClient = new RestClient();
            RestResponse response = await restClient.ExecuteAsync(restRequest);
            // HttpResponseMessage response = await client.GetAsync($"{_url}/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;

                // JsonConvert.SerializeObject();  //c# object to json
                // JsonConvert.DeserializeObject(); å // json to c# object

                BlogDataModel item = JsonConvert.DeserializeObject<BlogDataModel>(jsonStr)!;

                Console.WriteLine(item.Blog_Author);
                Console.WriteLine(item.Blog_Title);
                Console.WriteLine(item.Blog_Content);
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }

        public async Task Create(string Author, string Title, string Content)
        {

            BlogDataModel blog = new BlogDataModel()
            {
                Blog_Author = Author,
                Blog_Title = Title,
                Blog_Content = Content
            };

            // string jsonBlog = JsonConvert.SerializeObject(blog);

            // HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            // HttpClient client = new HttpClient();
            // HttpResponseMessage response = await client.PostAsync($"{_url}", httpContent);

            RestRequest restRequest = new RestRequest(_url, Method.Post);
            restRequest.AddBody(blog);
            RestClient restClient = new RestClient();
            RestResponse response = await restClient.ExecuteAsync(restRequest);


            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;

                Console.WriteLine(response.Content);


                // JsonConvert.SerializeObject();  //c# object to json
                // JsonConvert.DeserializeObject();  // json to c# object

                // BlogDataModel item = JsonConvert.DeserializeObject<BlogDataModel>(jsonStr)!;

                // Console.WriteLine(item.Blog_Author);
                // Console.WriteLine(item.Blog_Title);
                // Console.WriteLine(item.Blog_Content);
            }
            else
            {
                Console.WriteLine(response.Content);
            }
        }

        public async Task Update(int id, string Author, string Title, string Content)
        {
            BlogDataModel blog = new BlogDataModel()
            {
                Blog_Author = Author,
                Blog_Title = Title,
                Blog_Content = Content
            };

            // string jsonBlog = JsonConvert.SerializeObject(blog);
            // HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            // HttpClient client = new HttpClient();
            // HttpResponseMessage response = await client.PutAsync($"{_url}/{id}", httpContent);


            RestRequest restRequest = new RestRequest($"{_url}/{id}", Method.Patch);
            restRequest.AddBody(blog);
            RestClient restClient = new RestClient();
            RestResponse response = await restClient.ExecuteAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;

                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.Content);
            }

        }


        public async Task Delete(int id)
        {
            // HttpClient client = new HttpClient();
            // HttpResponseMessage response = await client.DeleteAsync($"{_url}/{id}");

            RestRequest restRequest = new RestRequest($"{_url}/{id}", Method.Delete);
            RestClient restClient = new RestClient();
            RestResponse response = await restClient.ExecuteAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;

                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.Content);
            }

        }
    }

}