using System.Net.Mime;
using System.Text;
using netConsoleTest.Models;
using Newtonsoft.Json;

namespace netConsoleTest.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            // await Read();
            // await Edit(9);
            // await Create("gg test 3", "gg test 3", "gg test 3");
            // await Update(9, "gg test update", "gg test update", "gg test update");
            await Delete(9);

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
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Edit(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5029/api/Blog/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();

                // JsonConvert.SerializeObject();  //c# object to json
                // JsonConvert.DeserializeObject();  // json to c# object

                BlogDataModel item = JsonConvert.DeserializeObject<BlogDataModel>(jsonStr)!;

                Console.WriteLine(item.Blog_Author);
                Console.WriteLine(item.Blog_Title);
                Console.WriteLine(item.Blog_Content);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
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

            string jsonBlog = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);


            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("http://localhost:5029/api/Blog", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();

                Console.WriteLine(await response.Content.ReadAsStringAsync());


                // JsonConvert.SerializeObject();  //c# object to json
                // JsonConvert.DeserializeObject();  // json to c# object

                // BlogDataModel item = JsonConvert.DeserializeObject<BlogDataModel>(jsonStr)!;

                // Console.WriteLine(item.Blog_Author);
                // Console.WriteLine(item.Blog_Title);
                // Console.WriteLine(item.Blog_Content);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
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

            string jsonBlog = JsonConvert.SerializeObject(blog);
            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);


            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync($"http://localhost:5029/api/Blog/{id}", httpContent);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();

                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

        }


        public async Task Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"http://localhost:5029/api/Blog/{id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();

                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }

        }
    }

}