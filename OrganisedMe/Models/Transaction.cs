namespace OrganisedMe.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public decimal Amount { get; set; }
        public int CostCode { get; set; }
        public DateTime Date { get; set; }
        public int Account { get; set; }
        public string Narrative { get; set; }
    }
}
