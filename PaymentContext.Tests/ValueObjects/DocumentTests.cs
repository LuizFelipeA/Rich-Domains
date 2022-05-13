using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects;

[TestClass]
public class DocumentTests
{
    // Red, Green, Refactor
    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CNPJ);
        Assert.IsTrue(!doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCNPJIsValid()
    {
        var doc = new Document("12345678904444", EDocumentType.CNPJ);
        Assert.IsTrue(doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsInvalid()
    {
        var doc = new Document("123", EDocumentType.CPF);
        Assert.IsTrue(!doc.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCPFIsValid()
    {
        var doc = new Document("12345687536", EDocumentType.CPF);
        Assert.IsTrue(doc.IsValid);
    }
}
