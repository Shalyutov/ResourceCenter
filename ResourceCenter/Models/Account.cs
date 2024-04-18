using System.ComponentModel.DataAnnotations;

namespace ResourceCenter.Models
{
    public class Account 
    {
        public int Id { get; set; }
        [Required]
        public string Number { get; set; } = null!;
        [Required]
        public DateTime? Opened { get; set; } = null!;
        [Required]
        public DateTime? Closed { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        [Required]
        public double? Area { get; set; } = null!;

        public virtual List<Resident> Residents { get; set; } = [];
        public virtual List<ResidentAccount> ResidentAccounts { get; set; } = [];
    }
}
