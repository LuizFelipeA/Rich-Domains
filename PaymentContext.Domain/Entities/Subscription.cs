namespace PaymentContext.Domain.Entities;

public class Subscription
{
    private IList<Payment> _payments;
    
    public Subscription(
        DateTime? expireDate)
    {
        CreateDate = DateTime.Now;
        LastUpdateDate = DateTime.Now;
        ExpireDate = expireDate;
        Active = true;
        _payments = new List<Payment>();
    }

    public DateTime CreateDate { get; }

    public DateTime LastUpdateDate { get; private set; }

    public DateTime? ExpireDate { get; }

    public bool Active { get; private set; }

    public List<Payment> Payments { get; }

    public void AddPayment(Payment payment)
    {
        _payments.Add(payment);
    }

    public void Activete()
    {
        Active = true;
        LastUpdateDate = DateTime.Now;
    }

    public void Inactivate()
    {
        Active = false;
        LastUpdateDate = DateTime.Now;
    }
}
