using System.ComponentModel.DataAnnotations;

namespace ExamenJunior.Models
{
	public class Product
	{
		public string ProductId { get; set; }
        public ProductCategory? refProductCategory { get; set; }
		public string ProductDescription { get; set; }
		public int Stock { get; set; }
		public decimal Price { get; set; }
		public bool HaveECDiscount { get; set; }
		public bool IsActive { get; set; }
	}
}
