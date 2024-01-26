
namespace netConsoleTest.EFCoreExamples
{
    public class EFCoreTest{

        private readonly AppDbContext _appDbContext =  new AppDbContext();
        public void Run() {

        }
        public void Read () {

            var lst = _appDbContext.Blog.ToList();

        }
    }
}