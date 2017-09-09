
namespace PayslipApp.Service
{
    public class TaxCalculater: ITaxCalculater
    {

        public static readonly TaxBracket[] TaxBrackets = new TaxBracket[]
            {
                new TaxBracket() {BracketStart = 180000, TaxRate = 0.45M, PreBracketTax = 54547 },
                new TaxBracket() {BracketStart = 80000,  TaxRate = 0.37M, PreBracketTax = 17547 },
                new TaxBracket() {BracketStart = 37000,  TaxRate = 0.325M,PreBracketTax = 3572 },
                new TaxBracket() {BracketStart = 18200,  TaxRate = 0.19M, PreBracketTax = 0 }
            };

        public decimal CalculateIncomeTax(int anualSalary)
        {
            foreach (var taxBracket in TaxBrackets)
            {
                if (anualSalary > taxBracket.BracketStart)
                {
                    return (taxBracket.PreBracketTax +((anualSalary - taxBracket.BracketStart)* taxBracket.TaxRate));
                }
            }
            return 0;
        }

    }
    public class TaxBracket
    {
        public decimal BracketStart { get; set; }
        public decimal TaxRate { get; set; }
        public decimal PreBracketTax { get; set; }
    }
}
