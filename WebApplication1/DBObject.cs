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
                        Name = "Дурная репутация 2",
                        ShortDesc = "Игра для PS3",
                        LongDesc = "Продолжение удивительных приключений курьера Коула Макграта, который после несчастного случая стал человеком-аккумулятором. В сиквеле Коул готовится ко встрече со своим антиподом по прозвищу Зверь. Для этого он отправляется в город Нью-Маре, чтобы проконсультироваться с неким профессором Вольфом.",
                        Price = 1100,
                        Img = "/img/Infamous2.jpg",
                        IsFavourite = true,
                        available = true,
                        Category = Categories["PS3"]
                    },
                    new Ticket
                    {
                        Name = "Слай Купер: Прыжок во времени",
                        ShortDesc = "Игра для PSVita",
                        LongDesc = "Продолжение удивительных приключений воришки енота и его банды. В новой игре героям предстоит востановить историю предков енота и путешествовать по различным временым эпохам - от дикого запада до каменого века, а также встретить предков енота Слая.",
                        Price = 1500,
                        Img = "/img/Sly4.jpg",
                        IsFavourite = false,
                        available = false,
                        Category = Categories["PSVita"]
                    },
                    new Ticket
                    {
                        Name = "Призрак Цусимы",
                        ShortDesc = "Игра для PS4",
                        LongDesc = "Действие игры происходит в 1274 году, во время первого монгольского вторжения в Японию, когда остров Цусима был захвачен и разорён Монгольской империей. Главный герой, японский самурай по имени Дзин Сакай, в одиночку даёт бой превосходящим силам монголов, опираясь на старые самурайские традиции и необычные методы борьбы. ",
                        Price = 3000,
                        Img = "/img/GhostTsusima.jpg",
                        IsFavourite = true,
                        available = true,
                        Category = Categories["PS4"]
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
                        new Category { CategoryName = "PS3", Desc = "Консоль 7 поколения"},
                        new Category { CategoryName = "PSVita", Desc = "Портативная консоль 8 поколения"},
                        new Category { CategoryName = "PS4", Desc = "Консоль 8 поколения"}
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
