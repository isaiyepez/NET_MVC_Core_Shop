using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web2.Data
{
    public class SeedDb
    {
        private readonly DataContext context;
	private Random random;

	public SeedDb(DataContext context)
	{
    	this.context = context;
    	this.random = new Random();
	}

	public async Task SeedAsync()
	{
        //Se asegura de que la base de datos ya esté creada antes de ejecutarse
    	await this.context.Database.EnsureCreatedAsync();

    	if (!this.context.Products.Any())
    	{
        	this.AddProduct("First Product");
        	this.AddProduct("Second Product");
        	this.AddProduct("Third Product");
        	await this.context.SaveChangesAsync();
    	}
	}

	private void AddProduct(string name)
	{
    	this.context.Products.Add(new Product
    	{
        	Name = name,
        	Price = this.random.Next(100),
        	IsAvailabe = true,
        	Stock = this.random.Next(100)
    	});
	}
    }
}
