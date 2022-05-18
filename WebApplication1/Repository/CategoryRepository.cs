using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CategoryRepository : ITicketCategory
    {
        private readonly AppDBContent appDBContent;
        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
        
    }
}
