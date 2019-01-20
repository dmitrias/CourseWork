using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Data;


namespace Task2.Models
{
    public class RecepieInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.RecepieCollection.Any())
            {
                context.RecepieCollection.AddRange(
                    new Recepie {
                        Caption = "Ведро c болтами",
                        Category = "Cars",
                        Description = "Корч",
                        Ingridients = "Говно, палки, хомуты, изолента, резинки для денег, болты (начинка).",
                        Text = "Каким-то боком все совместить, проверить. Повторять, пока не заведется.",
                        ImageURL = "https://pp.userapi.com/c840534/v840534093/5a5cb/ETnKJW7Nb68.jpg",
                        DateOfLastUpdate = DateTime.Now
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
