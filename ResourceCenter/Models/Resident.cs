using System.ComponentModel.DataAnnotations;

namespace ResourceCenter.Models
{
    public class Resident
    {
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = null!;
        [Required]
        public int? Number { get; set; } = null!;
        [Required]
        public ResidentType? ResidentType { get; set; } = null!;

        public virtual List<Account> Accounts { get; set; } = [];
        public virtual List<ResidentAccount> ResidentAccounts { get; set; } = [];
    }

    public enum ResidentType
    {
        Person, Organisation
    }
}
