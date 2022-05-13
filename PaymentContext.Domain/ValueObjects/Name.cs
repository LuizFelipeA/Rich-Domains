using Flunt.Validations;
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

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsGreaterThan(FirstName, 3, "Name.FirstName", "The first name field must have at least three characters.")
            .IsGreaterThan(LastName, 3, "Name.LastName", "The last name field must have at least three characters."));
    }

    public string FirstName { get; }

    public string LastName { get; }
}