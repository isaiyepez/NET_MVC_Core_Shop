using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Shop.Web2.Data.Entities;

namespace Shop.Web2.Data
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} only can contain a maximum {1} characters")]
	    [Required]
        public string Name { get; set; }

        //Decorator C=CURRENCY shows system value for currency
        //Apply format in edith mode means that it is only applied for showing
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Last Purchase")]
        public DateTime? LastPurchase { get; set; }

        [Display(Name = "Last Sale")]
        public DateTime? LastSale { get; set; }

        [Display(Name = "Is Availabe?")]
        public bool IsAvailabe { get; set; }

        //N2 will show number not currency, no $ symbol
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public double Stock { get; set; }

        //To create a relationship between USER and PRODUCT.
        //In a one-to many relationship, it is enough to quote the "one" object 
        //to the "many" object as following;
        public User User { get; set; }
    }
}
