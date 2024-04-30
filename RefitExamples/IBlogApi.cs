using netConsoleTest.Models;
using Refit;

namespace netConsoleTest.RefitExamples
{
    public interface IBlogApi
    {
        [Get("/api/Blog")]
        Task<List<BlogDataModel>> GetBlogs();

        [Get("/api/Blog/{id}")]
        Task<BlogDataModel> GetBlog(int id);

        [Post("/api/Blog")]
        Task<string> CreateBlogs(BlogDataModel blog);

        [Put("/api/Blog/{id}")]
        Task<string> UpdateBlogs(int id, BlogDataModel blog);

        [Delete("/api/Blog/{id}")]
        Task<string> DeleteBlog(int id);


    }
}