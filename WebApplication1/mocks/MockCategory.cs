using WebApplication1.Interface;
using WebApplication1.Models;

namespace WebApplication1.mocks
{
    public class MockCategory : ITicketCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
            {
                new Category { CategoryName = "Мультфильмы", Desc = "Анимационные фильмы"},
                new Category { CategoryName = "Фильм", Desc = "Фильмы"}
            };
            }
        }
    }
}
