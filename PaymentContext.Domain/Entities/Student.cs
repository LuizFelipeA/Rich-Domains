namespace PaymentContext.Domain.Entities;

public class Student
{
    public Student(
        string firstName,
        string lastName,
        string document,
        string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Document = document;
        Email = email;
    }

    public string FirstName { get; }

     public string LastName { get; }

     public string Document { get; }

     public string Email { get; }

     public string Address { get; }

     public IReadOnlyCollection<Subscription> Subscription { get; }
}