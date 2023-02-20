using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BankSystem.Models;

namespace BankSystem .Data
{
    public static class SeedData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                if (context.Customers.Any())
                {
                    return;
                }

                var customers = new Customer[]
                {
                    new  Customer { CustomerName = "user",  CustomerEmail = "user@user1.pl", Password = "user1", Adress = "Długa1"},
                    new  Customer { CustomerName = "userr",  CustomerEmail = "user@user2.pl", Password = "user2",Adress = "Długa2"},
                };

                foreach (Customer customer in customers)
                {
                    context.Customers.Add(customer);
                }
                context.SaveChanges();

                

                var currencies = new Currency[]
                {
                    new Currency { CurrencyName ="PLN"},
                    new Currency { CurrencyName ="EUR"},
                    new Currency { CurrencyName ="USD"}
                };

                ICollection<Currency> currencies1 = new List<Currency>
                {
                    currencies[1],
                    currencies[2]
                };

                ICollection<Currency> categories2 = new List<Currency>
                {
                    currencies[1],
                    currencies[0]
                };

                var accounts = new Account[]
                {
                    new  Account {AccountNumber = 123456789,  Name= "TEST", Value = 40},
                    new  Account {AccountNumber = 123456788,Name= "TEST2", Value = 50}
                };

                foreach (Account account in accounts)
                {
                    context.Accounts.Add(account);
                }
                context.SaveChanges();

               
            }

        }
    }
}