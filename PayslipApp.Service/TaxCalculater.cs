
namespace PayslipApp.Service
{
    public class TaxCalculater: ITaxCalculater
    {

        public static readonly TaxBracket[] TaxBrakets = new TaxBracket[]
            {
                new TaxBracket() {BraketStart = 180000, TaxRate = 0.45M, PreBracketTax = 54547 },
                new TaxBracket() {BraketStart = 80000,  TaxRate = 0.37M, PreBracketTax = 17547 },
                new TaxBracket() {BraketStart = 37000,  TaxRate = 0.325M,PreBracketTax = 3572 },
                new TaxBracket() {BraketStart = 18200,  TaxRate = 0.19M, PreBracketTax = 0 }
            };

        public decimal CalculateIncomeTax(int anualSalary)
        {
            foreach (var taxBraket in TaxBrakets)
            {
                if (anualSalary > taxBraket.BraketStart)
                {
                    return (taxBraket.PreBracketTax +((anualSalary - taxBraket.BraketStart)* taxBraket.TaxRate));
                }
            }
            return 0;
        }

    }
    public class TaxBracket
    {
        public decimal BraketStart { get; set; }
        public decimal TaxRate { get; set; }
        public decimal PreBracketTax { get; set; }
    }
}
