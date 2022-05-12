using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public abstract class Payment : Entity
{
    protected Payment(
        string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        Document document,
        Address address,
        Email email)
    {
        Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
        PaidDate = paidDate;
        ExpireDate = expireDate;
        Total = total;
        TotalPaid = totalPaid;
        Payer = payer;
        Document = document;
        Address = address;
        Email = email;

        AddNotifications(new Contract<Payment>()
            .Requires()
            .IsGreaterThan(0, Total, "Payment.Total", "Payment must be greater than zero.")
            .IsGreaterOrEqualsThan(Total, TotalPaid, "Payment.TotalPaid", "Total paid must be greater or equals than total."));
    }

    public string Number { get; }

    public DateTime PaidDate { get; }

    public DateTime ExpireDate { get; }

    public decimal Total { get; }

    public decimal TotalPaid { get; }

    public string Payer { get; }

    public Document Document { get; }

    public Address Address { get; }

    public Email Email { get; }
}
