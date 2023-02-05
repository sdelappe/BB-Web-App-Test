using DBConnectionTest.Models;

namespace DBConnectionTest.Data
{
    public class DBInitializer
    {
        // This class initializes the database

        public static void Initialize(AppDBContext context)
        {
            // Look for any existing Book records
            if (context.Books.Any())
            {
                return; // DB has been seeded
            }

            var books = new Book[]
            {
                new Book
                {
                    Title="BloodMeridian",
                    PublishDate=DateTime.Parse("04-01-1985"),
                    Author=new Author{FirstName="Cormac",LastName="McCarthy"}
                },
                new Book
                {
                    Title="The Dog of the South",
                    PublishDate=DateTime.Parse("01-31-1979"),
                    Author=new Author{FirstName="Charles",LastName="Portis"}
                },
                new Book
                {
                    Title="Outline",
                    PublishDate=DateTime.Parse("05-15-2014"),
                    Author=new Author{FirstName="Rachel",LastName="Cusk"}
                },
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
