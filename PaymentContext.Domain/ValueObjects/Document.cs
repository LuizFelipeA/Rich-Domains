using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType type)
    {
        Type = type;
        Number = number;
    }

    public string Number { get; }

    public EDocumentType Type { get; set; }
}
