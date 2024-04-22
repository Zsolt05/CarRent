using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public static class SeedData
    {
        private static readonly Random random = new Random();

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var passwordValidator = serviceProvider.GetRequiredService<IPasswordValidator<IdentityUser>>();

            //nevek amibol a generalas kozben valaszt a program
            List<string> nameList = new List<string> { "Kiss Péter", "Holló Henrik", "Nagy László", "Sivatag Ferenc" };

            //minden inditáskor 5 felhasznalot general
            for (int i = 0; i < 5; i++)
            {
                var user = new IdentityUser { UserName = GenerateUsername(nameList)};

                //jelszo generalas
                string password = GenerateRandomPassword();

                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                }
                else
                {
                }
            }
        }

        private static string GenerateUsername(List<string> nameList)
        {
            //peldanevek listajabol nevvalasztas
            string selectedName = nameList[random.Next(nameList.Count)];

            //a felhasznalonevhez a nev elso harom karakteret valasztja ki
            string firstThreeChars = selectedName.Substring(0, Math.Min(selectedName.Length, 3));

            //plusz general egy haromjegyu random szamot
            string randomNumber = random.Next(100, 1000).ToString();

            //a kettot osszefuzve pedig kesz a felhasznalonev (a fnev letrehozas elvet meg lecserelhetjuk)
            string username = $"{firstThreeChars}{randomNumber}";

            return username;
        }

        private static string GenerateName(List<string> nameList)
        {
            //peldanevek listajabol nevvalasztas
            string selectedName = nameList[random.Next(nameList.Count)];

            return selectedName;
        }

        private static string GenerateRandomPassword()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

            StringBuilder password = new StringBuilder();
            for (int i = 0; i < 10; i++) //10 karakteres lesz a jelszo
            {
                password.Append(validChars[random.Next(validChars.Length)]);
            }

            //kovetelmenyek csekkolasa: minimum 1 nagybetu, minimum 1 szam)
            if (!password.ToString().Any(char.IsUpper) || !password.ToString().Any(char.IsDigit))
            {
                //ha nem felel meg, uj jelszot general
                return GenerateRandomPassword();
            }

            return password.ToString();
        }
    }
}
