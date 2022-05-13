using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Dtos;

public class ValueObjectsDto
{
    public Name Name { get; set; }

    public Email Email { get; set; }

    public Address Address { get; set; }

    public Document Document { get; set; }
}
