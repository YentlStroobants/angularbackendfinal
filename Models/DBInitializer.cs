using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularChallengeAPI.Data;

namespace AngularChallengeAPI.Models
{
    public class DBInitializer
    {
        public static void Initialize(ShopContext context)
        {
            context.Database.EnsureCreated();

            // Look for any products.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            //Add products
            context.AddRange(
                new Product { Naam = "Red pants", Prijs = 15.99, Beschrijving = "Rode broek", IsActief = true, AantalInStock = 30, NonFoodId = 1 },
                new Product { Naam = "Blue cap", Prijs = 5.99, Beschrijving = "Blauwe pet", IsActief = true, AantalInStock = 25, NonFoodId = 2 },
                new Product { Naam = "Green t-shirt", Prijs = 20.99, Beschrijving = "Groene t-shirt", IsActief = true, AantalInStock = 47, NonFoodId = 3 },
                new Product { Naam = "Protein powder", Prijs = 30.99, Beschrijving = "Proteine poeder voor snelle spieren!", IsActief = true, AantalInStock = 47, FoodId = 1 }
                );

            //NonFood
            NonFood Pants = new NonFood()
            {
                Size = "XL",
                Color = "Rood"
            };

            NonFood Cap = new NonFood()
            {
                Size = "L",
                Color = "Blauw"
            };

            NonFood Tshirt = new NonFood()
            {
                Size = "S",
                Color = "Groen"
            };

            context.Add(Tshirt);
            context.Add(Pants);
            context.Add(Cap);

            //Food
            Food Powder = new Food()
            {
                VervalDatum = "21 December 2022",
                Hoeveelheid = "1kg"
            };

            context.Add(Powder);

            context.SaveChanges();

            //Roles
            Role Admin = new Role()
            {
                Naam = "Admin"
            };

            Role SuperAdmin = new Role()
            {
                Naam = "SuperAdmin"
            };

            Role Klant = new Role()
            {
                Naam = "Klant"
            };

            context.Add(Admin);
            context.Add(SuperAdmin);
            context.Add(Klant);

            context.SaveChanges();

            //Add users
            User Jos = new User()
            {
                Naam = "Jos Vermeire",
                Email = "jos.vermeire@thomasmore.be",
                Wachtwoord = "JosVermeire76",
                Adres = "Ganzenlaan 3",
                Postcode = "2300",
                RoleId = 1,
            };

            User Marie = new User()
            {
                Naam = "Marie De Grote",
                Email = "marie.degrote@thomasmore.be",
                Wachtwoord = "Marie56deGrote",
                Adres = "kerkstraat 7",
                Postcode = "2240",
                RoleId = 2,
            };

            User Anna = new User()
            {
                Naam = "Anna Dubois",
                Email = "anna.dubois@thomasmore.be",
                Wachtwoord = "Max653",
                Adres = "Rozenstraat 45",
                Postcode = "2360",
                RoleId = 3,
            };

            User Ben = new User()
            {
                Naam = "Ben Wouters",
                Email = "ben.wouters@thomasmore.be",
                Wachtwoord = "jxt2FxCqVVhE",
                Adres = "kleinhoefstraat 5",
                Postcode = "2440",
                RoleId = 3,
            };

            context.Add(Jos);
            context.Add(Marie);
            context.Add(Anna);
            context.Add(Ben);

            context.SaveChanges();

            //Statusses
            Status Actief = new Status()
            {
                Naam = "Actief"
            };

            Status Betaald = new Status()
            {
                Naam = "Betaald"
            };

            context.Add(Actief);
            context.Add(Betaald);

            context.SaveChanges();


            //Orders
            Order order = new Order()
            {
                UserId = 1
            };

            Order order2 = new Order()
            {
                UserId = 2
            };

            context.Add(order);
            context.Add(order2);

            context.SaveChanges();

           
            //OrderProducts
            OrderProduct po = new OrderProduct()
            {
                OrderId = 1,
                ProductId = 1,
                Aantal = 5
            };

            OrderProduct po2 = new OrderProduct()
            {
                OrderId = 2,
                ProductId = 2,
                Aantal = 4
            };

            OrderProduct po3 = new OrderProduct()
            {
                OrderId = 2,
                ProductId = 3,
                Aantal = 2
            };

            context.Add(po);
            context.Add(po2);
            context.Add(po3);

            context.SaveChanges();

            //success!
        }
    }
}
