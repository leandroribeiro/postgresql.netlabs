using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Postgre.Domain.Entities;
using Postgre.NetCore.Dapper.Infrastructure;
using Postgre.Persistence.EFCore20;
using Output = System.Console;

namespace Postgre.Presentation.Console.NETCore20
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

            //this doesn't works because Entity Framework 6.2 is unssuported on .NET Core
            Output.WriteLine("Entity Framework 6.2 ==> DON'T WORKS! =(");
            
        }

        private static void GetByEFCore20()
        {
            _provider = "EF Core 2.0";

            try
            {
                IList<Customer> clientes;

                
                using (var ctx = new DesignTimeDbContextFactory().CreateDbContext(new string[] { }))
                {
                    //insert new customers
                    foreach (var customer in Customers.OrderBy(t => Guid.NewGuid()).Take(10))
                    {
                        ctx.Customers.Add(new Customer() { Name = $"{customer} by ({_provider})" });
                    }

                    ctx.SaveChanges();

                    //get all customers
                    clientes = ctx.Customers.ToList().Where(x=>x.Name.Contains(_provider)).ToList();
                }
                
                foreach (var cliente in clientes)
                {
                    Output.WriteLine("Cliente: {0}", cliente.Name);
                }

                Output.WriteLine("Entity Framework Core 2.0 ==> WORKS! =)");
            }
            catch (Exception e)
            {
                Output.WriteLine("Entity Framework Core 2.0 ==> DON'T WORKS! =(");
                Output.WriteLine(e);
                throw;
            }

         
        }

        private static void GetByDapper()
        {
            _provider = "Dapper";

            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

                var connectionStringConfig = builder.Build();

                var repository = new CustomerRepository(connectionStringConfig.GetConnectionString(
                    "MainContext"));
                foreach (var customer in Customers.OrderBy(t => Guid.NewGuid()).Take(10))
                {
                    //insert new customers
                    repository.Add(new Customer() { Name = $"{customer} by ({_provider})" });
                }

                //get all customers
                IList<Customer> clientes = repository.FindAll().ToList().Where(x => x.Name.Contains(_provider)).ToList(); ;

                foreach (var cliente in clientes)
                {
                    Output.WriteLine("Cliente: {0}", cliente.Name);
                }

                Output.WriteLine("Dapper ==> WORKS! =)");

            }
            catch (Exception e)
            {
                Output.WriteLine("Dapper ==> DON'T WORKS! =(");
                Output.WriteLine(e);
                throw;
            }
            

            
        }
    }
}
