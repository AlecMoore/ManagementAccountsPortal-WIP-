namespace OrganisedMe.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public Type Type { get; set; }
        public decimal Amount { get; set; }
        public CostCode CostCode { get; set; }
        public DateTime Date { get; set; }
        public string? Account { get; set; }
        public string? Narrative { get; set; }
    }

    public enum CostCode 
    { 
        IOMBank = 1200,
        IOMBankHoliday = 1201,
        IncomePim = 4000,
        IncomeAlec = 4001,
        BankInterest = 4002,
        Mortgage = 5000,
        ManagementFee = 5001,
        RatesProperty = 5002,
        RatesCouncil = 5003,
        Electricity = 5004,
        Gas = 5005,
        Internet = 5006,
        Car = 5007,
        CarInsurance = 5008,
        Household = 5009,
        Medical = 5010,
        Food = 5011,
        EatingOut = 5012,
        Drinks = 5013,
        Entertainment = 5014,
        Holiday = 5015,
        Gifts = 5016,
        Fuel = 5017
    }

    public enum Type
    {
        Income = 0,
        Expense = 1,
        Asset = 2
    }

}
