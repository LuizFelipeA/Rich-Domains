using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Address : ValueObject
{
    public string Street { get; }

    public string Number { get; }

    public string Neighborhood { get; }

    public string City { get; }

    public string State { get; }

    public string Country { get; }

    public string ZipCode { get; set; }
}
