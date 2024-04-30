using netConsoleTest.Models;
using Refit;

namespace netConsoleTest.RefitExamples
{
    public class RefitExample
    {
        private readonly IBlogApi refitApi = RestService.For<IBlogApi>("http://localhost:5029");

        public async Task Run()
        {
            // await Read();
            await edit(7);
        }
        private async Task Read()
        {
            var lst = await refitApi.GetBlogs();
            foreach (BlogDataModel ea in lst)
            {
                Console.WriteLine(ea.Blog_Author);
                Console.WriteLine(ea.Blog_Title);
                Console.WriteLine(ea.Blog_Content);
            }
        }

        private async Task edit(int id)
        {


            try
            {
                BlogDataModel item = await refitApi.GetBlog(id);
                Console.WriteLine(item.Blog_Author);
                Console.WriteLine(item.Blog_Title);
                Console.WriteLine(item.Blog_Content);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


        }

        private async Task Create(string title, string author, string content)
        {
            try
            {
                BlogDataModel blog = new BlogDataModel()
                {
                    Blog_Title = title,
                    Blog_Author = author,
                    Blog_Content = content
                };
                string message = await refitApi.CreateBlogs(blog);
                Console.WriteLine(message);
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }

        }

        private async Task delete(int id)
        {
            try
            {

                string message = await refitApi.DeleteBlog(id);
                Console.WriteLine(message);

            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }
    }
}