using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBookShare.Models
{
    public class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.BookMaster.Any())
            {
                context.Add(
                    new User { UserName = "DhruvDhiman", Password = "Password@123" }
                    );
                
                
            }
            context.SaveChanges();
            if (!context.BookMaster.Any())
            {
                context.Add(
                    new BookMaster
                    {
                        Author = "J. K. Rowling",
                        Title = "Harry Potter and the Sorcerer's Stone",
                        ShortDescription = "Harry Potter",
                        LongDescription = "Harry Potter and the Philosopher's Stone is a fantasy novel written by British author J. K. Rowling. It is the first novel in the Harry Potter series and Rowling's debut novel, first published in 1997 by Bloomsbury. It was published in the United States as Harry Potter and the Sorcerer's Stone by Scholastic Corporation in 1998.",
                        AvailableCount = 10,
                        Price = 0,
                        ImageNumber = 1,
                        UserId = context.User.FirstOrDefault(u => u.UserName == "DhruvDhiman").UserId
                    }    
                    );
                
            }
            context.SaveChanges();
        }
    }
}
