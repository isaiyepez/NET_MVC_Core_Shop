using System.ComponentModel.DataAnnotations;
using Shop.Web2.Data.Entities;

public class Country : IEntity
{
	public int Id { get; set; }

	[MaxLength(50, ErrorMessage = "The field {0} only can contain {1} characters length.")]
	[Required]
	[Display(Name = "Country")]
	public string Name { get; set; }
}