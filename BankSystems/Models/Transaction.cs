using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
       

        public class Transaction
        {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }

            [Required]
            [Display(Name = "Nazwa Przelewu")]
            public string TransactionType { get; set; }

            [Required]
            [Display(Name = "Środki")]
            public decimal Value { get; set; }
             [Required]
            [Display(Name = "Numer Konta do Przelewu")]
            public int DestAccount { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
    }

