using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Queries;

[TestClass]
public class StudentQueriesTests
{
    private IList<Student> _students;

    public StudentQueriesTests()
    {
        _students = new List<Student>();

        for (int student = 0; student <= 10; student++)
        {
            _students.Add(
                new Student(
                    new Name("Student", student.ToString()),
                    new Document("99999999999", EDocumentType.CPF),
                    new Email(student.ToString() + "@lp.com")));
        }
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentDoNotExists()
    {
        var expression = StudentQueries.GetStudentInfo("12345678911");

        var student = _students.AsQueryable().Where(expression).FirstOrDefault();

        Assert.AreEqual(null, student);
    }

    [TestMethod]
    public void ShouldReturnNullWhenDocumentExists()
    {
        var expression = StudentQueries.GetStudentInfo("99999999999");

        var student = _students.AsQueryable().Where(expression).FirstOrDefault();

        Assert.AreNotEqual(null, student);
    }
}
