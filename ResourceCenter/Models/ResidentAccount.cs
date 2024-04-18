namespace ResourceCenter.Models
{
    public class ResidentAccount
    {
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
    }
}
