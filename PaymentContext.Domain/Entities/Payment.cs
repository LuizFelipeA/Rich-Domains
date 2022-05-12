namespace PaymentContext.Domain.Entities;

public abstract class Payment
{
    protected Payment(
        string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        string document,
        string address,
        string email)
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
    }

    public string Number { get; }

    public DateTime PaidDate { get; }

    public DateTime ExpireDate { get; }

    public decimal Total { get; }

    public decimal TotalPaid { get; }

    public string Payer { get; }

    public string Document { get; }

    public string Address { get; }

    public string Email { get; }
}