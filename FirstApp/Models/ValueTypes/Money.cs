using FirstApp.Models.Enums;

namespace FirstApp.Models.ValueTypes;

public class Money
{
    public Money() : this(0.00m, Currency.EUR)
    {
    }
    
    public Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }
    
    private decimal _amount;

    public decimal Amount
    {
        get => _amount;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Amount cannot be negative");
            }
            _amount = value;
        }
    }
    public Currency Currency { get; set; }

    public override string ToString()
    {
        return $"{Amount:F2} {Currency}";
    }
}