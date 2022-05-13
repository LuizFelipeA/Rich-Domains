using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities;

public class BoletoPayment : Payment
{
    public BoletoPayment(
        string barCode,
        string boletoNumber,
        string number,
        DateTime paidDate,
        DateTime expireDate,
        decimal total,
        decimal totalPaid,
        string payer,
        Document document,
        Address address,
        Email email)
        : base(
            number,
            paidDate,
            expireDate,
            total,
            totalPaid,
            payer,
            document,
            address,
            email)
    {
        BarCode = barCode;
        BoletoNumber = boletoNumber;
    }

    public string BarCode { get; }

    public string BoletoNumber { get; }
}
