namespace PT_Lab4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PT_Lab4.MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PT_Lab4.MyDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Books.AddOrUpdate(
               new Book(new Author("Jan", "Jasinski"), "Lambda", 2015, new Publisher("Swiat Ksiazki")),
               new Book(new Author("Kuba", "Kubczak"), "Programowanie od A do B", 2005, new Publisher("Pampam"))
               );
        }
    }
}
