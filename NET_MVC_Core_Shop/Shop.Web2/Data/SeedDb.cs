using Microsoft.AspNetCore.Identity;
using Shop.Web2.Helper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web2.Data
{
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly Random random;
        private readonly IUserHelper userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("isainokia@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Isai",
                    LastName = "Nokia",
                    Email = "isainokia@gmail.com",
                    UserName = "isainokia@gmail.com"
                };

                var result = await this.userHelper.AddUserAsync(user, "antares155");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.Products.Any())
            {
                this.AddProduct("First Product", user);
                this.AddProduct("Second Product", user);
                this.AddProduct("Third Product", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}