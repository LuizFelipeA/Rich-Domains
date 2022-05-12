using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    private IList<Subscription> _subscription;
    
    public Student(
        Name name,
        Document document,
        Email email)
    {
        Name = name;
        Document = document;
        Email = email;
        _subscription = new List<Subscription>();
    }

    public Name Name { get; set; }

    public Document Document { get; }

    public Email Email { get; }

    public Address Address { get; }

    public IReadOnlyCollection<Subscription> Subscription { get; }
}