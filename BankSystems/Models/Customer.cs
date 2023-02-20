using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class Customer
    {
        //Unique ID Required
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        [Required]
        [Display(Name = "Nazwa")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }
        [Required, RegularExpression(@"^[^\s]+$", ErrorMessage = "Nie używaj spacji")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Role { get; set; }







    }
}
