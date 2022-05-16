using WebApplication1.Models;

namespace WebApplication1.Interface
{
    public interface ITicketCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
