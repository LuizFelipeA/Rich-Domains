using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public Address(
        string street,
        string number,
        string neighborhood,
        string city,
        string state,
        string country,
        string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;

        AddNotifications(new Contract<Address>()
            .Requires()
            .IsGreaterThan(Street, 3, "Address.Street", "The street field must contain at least 3 characters"));
    }

    public string Street { get; }

    public string Number { get; }

    public string Neighborhood { get; }

    public string City { get; }

    public string State { get; }

    public string Country { get; }

    public string ZipCode { get; set; }
}
