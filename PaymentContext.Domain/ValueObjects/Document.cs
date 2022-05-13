using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects;

public class Document : ValueObject
{
    public Document(string number, EDocumentType type)
    {
        Type = type;
        Number = number;

        AddNotifications(new Contract<Document>()
            .Requires()
            .IsTrue(ValidateDocument(), "Document.Number", "Invalid document."));
    }

    public string Number { get; }

    public EDocumentType Type { get; set; }

    private bool ValidateDocument()
    {
        if(Type == EDocumentType.CNPJ && Number.Length == 14)
            return true;

        if(Type == EDocumentType.CPF && Number.Length == 11)
            return true;

        return false;
    }
}
