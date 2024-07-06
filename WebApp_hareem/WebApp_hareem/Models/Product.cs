using System.ComponentModel.DataAnnotations;

namespace WebApp_hareem.Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string pname { get; set; }
		[Required]
		public string desc { get; set; }
		[Required]
		public int price{ get; set; }
	}
}
