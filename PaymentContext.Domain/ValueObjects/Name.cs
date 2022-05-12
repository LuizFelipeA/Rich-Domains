using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Name : ValueObject
{
    public Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;

        if(string.IsNullOrEmpty(FirstName))
            AddNotification("Name.FirstName", "Invalid name.");
    }

    public string FirstName { get; }

    public string LastName { get; }
}