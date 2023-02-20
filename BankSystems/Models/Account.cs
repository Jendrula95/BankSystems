using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID { get; set; }
        [Required]
        [Display(Name = "Nazwa Konta")]

        public string Name { get; set; }
        
        [Display(Name = "Numer Konta")]
        public int AccountNumber { get; set; }
        [Required]
        [Display(Name = "Środki")]
        public decimal Value { get; set; }
        
        public int CurrencyID { get; set; }
        [Required]
        [Display(Name = "Waluta")]
        public Currency Currency { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }



    }
}
