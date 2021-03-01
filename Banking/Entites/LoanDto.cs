namespace Banking.Entites
{
    public class Loan
    {
        public Loan(decimal amount, double duration)
        {
            Amount = amount;
            Duration = duration;
        }

        public decimal Amount { get; }
        public double Duration { get; }
    }
}