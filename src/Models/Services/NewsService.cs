using News.Models.Base;
using News.Models.Data;

namespace News.Models.Services
{
    public class NewsService : EntityBaseRepository<News>, INewsService
    {
        public NewsService(AppDbContext context):base(context)
        {
         }
    }
}