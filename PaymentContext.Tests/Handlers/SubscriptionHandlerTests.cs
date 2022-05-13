using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests.Handlers;

[TestClass]
public class SubscriptionHandlerTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenDocumentExists()
    {
        var handler = new SubscriptionHandler(new MockStudentRepository());

        var command = new CreateBoletoSubscriptionCommand();

        command.FirstName = "LP";
        command.LastName = "LPSurname";
        command.Document = "99999999999";
        command.Email = "bruce@wayne.com";
        command.BarCode = "123456565";
        command.BoletoNumber = "45454545";
        command.PaymentNumber = "23232323";
        command.PaidDate = DateTime.Now;
        command.ExpireDate = DateTime.Now.AddDays(1);
        command.Total = 100;
        command.TotalPaid = 100;
        command.Payer = "Bruce Wayne";
        command.PayerDocument = "99999999999";
        command.PayerDocumentType = EDocumentType.CPF;
        command.PayerEmail = "bruce@wayne.com";
        command.Street = "wayne street";
        command.Number = "12345";
        command.Neighborhood = "wayne neigh";
        command.City = "wayne city";
        command.State = "wayne state";
        command.Country = "wayne country";
        command.ZipCode = "00000000";

        handler.Handle(command);
        Assert.AreEqual(false, handler.IsValid);
    }
}
