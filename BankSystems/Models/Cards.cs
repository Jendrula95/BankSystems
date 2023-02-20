using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class Cards
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CardsID { get; set; }
        [Required]

        public string  CardName { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }

        public Account Account { get; set; }
        public int AccountId { get; set; }
    }
}
