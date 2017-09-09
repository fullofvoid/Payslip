namespace PayslipApp.Service
{
    public interface ITaxCalculater
    {
        decimal CalculateIncomeTax(int anualSalary);
    }
}