using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Models;

namespace WebApplication1
{
    public class DBObject
    {
        public static void Initial(AppDBContent content)
        {          
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));



            if (!content.Category.Any())
            {
                content.AddRange(
                    new Ticket
                    {
                        Name = "Плохие парни",
                        ShortDesc = "Про авантюристов",
                        LongDesc = "Авантюристы начинают новую жизнь",
                        Price = 1100,
                        Img = "/img/badboys.jpg",
                        IsFavourite = true,
                        available = true,
                        Category = Categories["Мультфильмы"]
                    },
                    new Ticket
                    {
                        Name = "Доктор Стрендж",
                        ShortDesc = "Про мага",
                        LongDesc = "Мага исправляет мультивселенную",
                        Price = 1500,
                        Img = "/img/maga.jpg",
                        IsFavourite = false,
                        available = false,
                        Category = Categories["Фильм"]
                    },
                    new Ticket
                    {
                        Name = "Затерянный город",
                        ShortDesc = "Я хз, но там Ченнинг Таттум",
                        LongDesc = "Точно не могу дать описание. Посмотри в гугле",
                        Price = 900,
                        Img = "/img/city.jpg",
                        IsFavourite = true,
                        available = true,
                        Category = Categories["Фильм"]
                    });
            }
            content.SaveChanges();        
        }
        public static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories 
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category { CategoryName = "Мультфильмы", Desc = "Анимационные фильмы"},
                        new Category { CategoryName = "Фильм", Desc = "Фильмы"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.CategoryName, el);
                }
                return category;
            }
        }
    }
}
