using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities;

[TestClass]
public class StudentTests
{
    [TestMethod]
    public void TestMethod1()
    {
        var student = new Student(
            firstName: "LP",
            lastName: "god",
            document: "000.000.000-00",
            email: "lp@lp.com");

        // student.FirstName = "";
    }
}
