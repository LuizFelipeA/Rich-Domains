using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class Student
{
    public Student(
        Name name,
        Document document,
        Email email)
    {
        Name = name;
        Document = document;
        Email = email;
    }

    public Name Name { get; set; }

    public Document Document { get; }

    public Email Email { get; }

    public string Address { get; }

    public IReadOnlyCollection<Subscription> Subscription { get; }
}