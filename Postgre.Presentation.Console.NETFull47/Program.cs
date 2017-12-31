using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Postgre.Domain.Entities;
using Postgre.Persistence.NETFull70.EF62;
using Output = System.Console;

namespace Postgre.Presentation.Console.NETFull47
{
    class Program
    {
        private static string _provider;

        static void Main(string[] args)
        {
            Output.WriteLine("*** {0} ***", Assembly.GetExecutingAssembly().GetName().Name);

            Output.WriteLine("");
            GetByDapper();

            Output.WriteLine("");
            GetByEFCore20();

            Output.WriteLine("");
            GetByEF62();

            Output.WriteLine("");
            Output.WriteLine("Press a key...");
            Output.ReadKey();
        }

        private static readonly string[] Customers = new[]
        {
            "4-LOM",
            "Aayla Secura",
            "Admiral Ackbar",
            "Admiral Thrawn",
            "Ahsoka Tano",
            "Anakin Solo",
            "Asajj Ventress",
            "Aurra Sing",
            "Senator Bail Organa",
            "Barriss Offee",
            "Bastila Shan",
            "Ben Skywalker",
            "Bib Fortuna",
            "Biggs Darklighter",
            "Boba Fett",
            "Bossk",
            "Brakiss",
            "C-3PO",
            "Cad Bane",
            "Cade Skywalker",
            "Callista Ming",
            "Captain Rex",
            "Carnor Jax",
            "Chewbacca",
            "Clone Commander Cody",
            "Count Dooku",
            "Darth Bane",
            "Darth Krayt",
            "Darth Maul",
            "Darth Nihilus",
            "Darth Vader",
            "Dash Rendar",
            "Dengar",
            "Durge",
            "Emperor Palpatine",
            "Exar Kun",
            "Galen Marek",
            "General Crix Madine",
            "General Dodonna",
            "General Grievous",
            "General Veers",
            "Gilad Pellaeon",
            "Grand Moff Tarkin",
            "Greedo",
            "Han Solo",
            "IG 88",
            "Jabba The Hutt",
            "Jacen Solo",
            "Jaina Solo",
            "Jango Fett",
            "Jarael",
            "Jerec",
            "Joruus C'Baoth",
            "Ki-Adi-Mundi",
            "Kir Kanos",
            "Kit Fisto",
            "Kyle Katarn",
            "Kyp Durron",
            "Lando Calrissian",
            "Luke Skywalker",
            "Luminara Unduli",
            "Lumiya",
            "Mace Windu",
            "Mara Jade",
            "Mission Vao",
            "Natasi Daala",
            "Nom Anor",
            "Obi-Wan Kenobi",
            "Padmé Amidala",
            "Plo Koon",
            "Pre Vizsla",
            "Prince Xizor",
            "Princess Leia",
            "PROXY",
            "Qui-Gon Jinn",
            "Quinlan Vos",
            "R2-D2",
            "Rahm Kota",
            "Revan",
            "Satele Shan",
            "Savage Opress",
            "Sebulba",
            "Shaak Ti",
            "Shmi Skywalker",
            "Talon Karrde",
            "Ulic Qel-Droma",
            "Visas Marr",
            "Watto",
            "Wedge Antilles",
            "Yoda",
            "Zam Wesell",
            "Zayne Carrick",
            "Zuckuss"
        };

        private static void GetByEF62()
        {
            _provider = "EF Full 6.2";

            try
            {
                IList<Customer> clientes;

                using (var ctx = new MainContext())
                {
                    //insert new customers
                    foreach (var customer in Customers.OrderBy(t => Guid.NewGuid()).Take(10))
                    {
                        ctx.Customers.Add(new Customer() { Name = $"{customer} by ({_provider})" });
                    }

                    ctx.SaveChanges();

                    //get all customers
                    clientes = ctx.Customers.ToList();
                }

                foreach (var cliente in clientes)
                {
                    Output.WriteLine("Cliente: {0}", cliente.Name);
                }

                Output.WriteLine("Entity Framework Full 6.2 ==> WORKS! =)");

            }
            catch (Exception e)
            {
                Output.WriteLine("Entity Framework Full 6.2 ==> DON'T WORKS! =(");
                Output.WriteLine(e);
                throw;
            }

        }

        private static void GetByEFCore20()
        {
        }

        private static void GetByDapper()
        {
        }
    }
}
