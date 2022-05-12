namespace PaymentContext.Domain.Entities;

public class CreditCardPayment : Payment
{
    public CreditCardPayment(
        string cardHolderName,
        string cardNumber,
        string lastTransactionNumber,
        string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        string document,
        string address,
        string email)
        : base(
            number,
            paidDate,
            expireDate,
            total,
            totalPaid,
            payer,
            document,
            address,
            email)
    {
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;
        LastTransactionNumber = lastTransactionNumber;
    }

    public string CardHolderName { get; }

    public string CardNumber { get; }

    public string LastTransactionNumber { get; }
}
