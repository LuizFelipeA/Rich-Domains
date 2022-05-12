using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.ValueObjects;

public class Document
{
    public Document(string number, EDocumentType type)
    {
        Type = type;
        Number = number;
    }

    public string Number { get; set; }

    public EDocumentType Type { get; set; }
}
