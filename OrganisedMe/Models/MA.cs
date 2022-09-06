namespace OrganisedMe.Models
{
    public class MA
    {
        public CostCode CostCode { get; set; }
        public string? Account { get; set; }
        public Type Type { get; set; }

        public List<MADetails> Details { get; set; }


        public MA(CostCode CostCode, string? Account, Type Type)
        {
            this.CostCode = CostCode;
            this.Account = Account;
            this.Type = Type;

        }
    }

    public class MADetails 
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public decimal MonthlyMovement { get; set; }

        public MADetails(decimal Amount, DateTime Date, decimal MonthlyMovement = (decimal)0.0)
        {
            this.Amount = Amount;
            this.Date = Date;
            this.MonthlyMovement = MonthlyMovement;
        }

    }



}
