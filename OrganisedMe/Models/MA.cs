namespace OrganisedMe.Models
{
    public class MA
    {
        public CostCode CostCode { get; set; }
        public string? Account { get; set; }
        public Type Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public decimal MonthlyMovement { get; set; }

        public MA(CostCode CostCode, string? Account, Type Type, decimal Amount, DateTime Date, decimal MonthlyMovement = (decimal)0.0)
        {
            this.CostCode = CostCode;
            this.Account = Account;
            this.Type = Type;
            this.Amount = Amount;
            this.Date = Date;
            this.MonthlyMovement = MonthlyMovement;
        }
    }


}
