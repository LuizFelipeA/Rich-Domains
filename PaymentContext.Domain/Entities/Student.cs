using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities;

public class Student : Entity
{
    private IList<Subscription> _subscriptions;
    
    public Student(
        Name name,
        Document document,
        Email email)
    {
        Name = name;
        Document = document;
        Email = email;
        _subscriptions = new List<Subscription>();

        AddNotifications(name, document, email);
    }

    public Name Name { get; set; }

    public Document Document { get; }

    public Email Email { get; }

    public Address Address { get; }

    public IReadOnlyCollection<Subscription> Subscriptions { get{ return _subscriptions.ToList(); } }

    public void AddSubscription(Subscription subscription)
    {
        bool hasSubscription = false;

        foreach (var sub in _subscriptions)
        {
            if(sub.Active)
                hasSubscription = true;
        }

        AddNotifications(new Contract<Student>()
            .Requires()
            .IsFalse(hasSubscription, "Student.Subscriptions", "You already have an active subscription.")
            .AreNotEquals(0, subscription.Payments.Count, "Student.Subscriptions.Payments", "Subscription does not have payments."));

        // if(hasSubscription)
        //     AddNotification("Student.Subscriptions", "You already have an active subscription.");

        _subscriptions.Add(subscription);
    }
}