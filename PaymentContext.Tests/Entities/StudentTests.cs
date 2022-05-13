using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    private readonly Name _name;

    private readonly Document _document;

    private readonly Email _email;

    private readonly Address _address;

    private readonly Student _student;

    private readonly Subscription _subscription;

    public StudentTests()
    {
        _name = new Name("Bruce", "Wayne");
        _document = new Document("13653862555", EDocumentType.CPF);
        _email = new Email("lp@lp.com");
        _address = new Address("Wayne street", "000", "Wayne Neigh", "Gotham city", "Wayne state", "USA", "9999");
        _student = new Student(_name, _document, _email);
        _subscription = new Subscription(null);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenHadActiveSubscription()
    {
        var payment = new PayPalPayment("12345678", "87654321", DateTime.Now, DateTime.Now.AddDays(5), 197, 197, "Batman", _document, _address, _email);

        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenSubscriptionHasNoPayment()
    {
        var subscription = new Subscription(null);

        _student.AddSubscription(subscription);
        Assert.IsTrue(!_student.IsValid);
    }

    [TestMethod]
    public void ShouldReturnSuccessWhenAddSubscription()
    {
        var payment = new PayPalPayment("12345678", "87654321", DateTime.Now, DateTime.Now.AddDays(5), 197, 197, "Batman", _document, _address, _email);

        _subscription.AddPayment(payment);
        _student.AddSubscription(_subscription);

        Assert.IsTrue(_student.IsValid);
    }
}
