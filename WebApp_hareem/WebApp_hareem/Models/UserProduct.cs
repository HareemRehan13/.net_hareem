using System.ComponentModel.DataAnnotations;

namespace WebApp_hareem.Models
{
    public class UserProduct
    {
        [Key]
        private int Id { get; set; }
        [Required]
        public string pname { get; set; }
        [Required]
        public string desc { get; set; }
        [Required]
        public int price { get; set; }
        public string uname { get; set; }

        [RegularExpression ("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}")]
        public string uemail{ get; set; }

        [RegularExpression("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$")]
        public string ucontact { get; set; }
        [Required]
        public int uaddress { get; set; }
    }
}
