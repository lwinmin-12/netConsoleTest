
using netConsoleTest.Models;

namespace netConsoleTest.EFCoreExamples
{
    public class EFCoreTest
    {

        private readonly AppDbContext _appDbContext = new AppDbContext();
        public void Run()
        {

        }
        public void Read()
        {

            List<BlogDataModel> lst = _appDbContext.Blog.ToList();

            foreach (BlogDataModel blog in lst)
            {
                Console.WriteLine(blog.Blog_Id);
                Console.WriteLine(blog.Blog_Title);
                Console.WriteLine(blog.Blog_Author);
                Console.WriteLine(blog.Blog_Content);
            }

        }

        public void Edit(int id)
        {
            BlogDataModel? item = _appDbContext.Blog.FirstOrDefault<BlogDataModel>(item => item.Blog_Id == id);

            if (item == null)
            {
                Console.WriteLine("No data found");
                return;
            }

            Console.WriteLine(item.Blog_Id);
            Console.WriteLine(item.Blog_Title);
        }

        public void Create(int id, string title, string author, string content)
        {
            BlogDataModel blog = new BlogDataModel()
            {
                Blog_Id = id,
                Blog_Title = title,
                Blog_Author = author,
                Blog_Content = content
            };
            _appDbContext.Blog.Add(blog);
            int result = _appDbContext.SaveChanges();

            string message = result > 0 ? "Saving Successful" : "Saving Failed.";

            Console.WriteLine(message);

        }

        public void Update(int id, string title, string author, string content)
        {
            BlogDataModel? item = _appDbContext.Blog.FirstOrDefault<BlogDataModel>(item => item.Blog_Id == id);
            if (item == null)
            {
                Console.WriteLine("No data found");
                return;
            }

            item.Blog_Title = title;
            item.Blog_Author = author;
            item.Blog_Content = content;

            int result = _appDbContext.SaveChanges();
            string message = result > 0 ? "Update successful " : "Update Failed";
            Console.WriteLine(message);

        }

        public void Delete(int id)
        {
            BlogDataModel? item = _appDbContext.Blog.FirstOrDefault<BlogDataModel>(item => item.Blog_Id == id);

            if (item == null)
            {
                Console.WriteLine("No data found");
                return;
            }

            _appDbContext.Blog.Remove(item);
            int result = _appDbContext.SaveChanges();

            string message = result > 0 ? "Delete successful " : "Delete Failed";
            Console.WriteLine(message);
        }
    }
}