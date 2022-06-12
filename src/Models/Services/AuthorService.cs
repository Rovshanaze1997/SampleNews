using News.Models.Base;
using News.Models.Data;

namespace News.Models.Services
{
    public class AuthorService : EntityBaseRepository<Author>, IAuthorService
    {
        public AuthorService(AppDbContext context) : base(context)
        {
            
        }
    }
}