using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Dtos;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers;

public class SubscriptionHandler : 
    Notifiable<Notification>,
    IHandler<CreateBoletoSubscriptionCommand>
{
    private readonly IStudentRepository _repository;

    public SubscriptionHandler(IStudentRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
    {
        // Fail Fast Validations -> (Avoiding no need hits on the Database)
        if(!FailFastValidations(command))
            return new CommandResult(false, "Something went wrong. Please, try again later;");

        DatabaseValidations(command);

        // Building objects and Relationships
        var student = BuildStudentEntity(command);
        
        if(!IsValid)
            return new CommandResult(false, "Something went wrong.");

        // Save information
        _repository.CreateSubscription(student);

        return new CommandResult(true, "Successful subscription.");
    }

    private bool FailFastValidations(CreateBoletoSubscriptionCommand command)
    {
        command.Validate();

        if(!command.IsValid)
        {
            AddNotifications(command);
        }

        return command.IsValid;
    }

    private void DatabaseValidations(CreateBoletoSubscriptionCommand command)
    {
        if(_repository.DocumentExists(command.Document))
            AddNotification("Document", "The document is already in use.");
        
        if(_repository.EmailExists(command.Email))
            AddNotification("Email", "This email is already in use.");
    }

    private ValueObjectsDto BuildValueObjects(CreateBoletoSubscriptionCommand command)
    {
        var name = new Name(command.FirstName, command.LastName);

        var document = new Document(command.Document, command.PayerDocumentType);

        var email = new Email(command.Email);

        var address = new Address(
            command.Street,
            command.Number,
            command.Neighborhood,
            command.City,
            command.State,
            command.Country,
            command.ZipCode);

        var response = new ValueObjectsDto
        {
            Name = name,
            Email = email,
            Address = address,
            Document = document
        };

        return response;
    }

    private Student BuildStudentEntity(CreateBoletoSubscriptionCommand command)
    {
        var valueObjects = BuildValueObjects(command);

        var student = new Student(
            valueObjects.Name,
            valueObjects.Document,
            valueObjects.Email);

        var subscription = new Subscription(DateTime.Now.AddMonths(1));

        var payment = new BoletoPayment(
            command.BarCode, 
            command.BoletoNumber,
            command.Number,
            command.PaidDate,
            command.ExpireDate,
            command.Total,
            command.TotalPaid,
            command.Payer,
            valueObjects.Document,
            valueObjects.Address,
            valueObjects.Email);

            // Grouping notifications
            AddNotifications(
                valueObjects.Name,
                valueObjects.Document,
                valueObjects.Email,
                valueObjects.Address,
                subscription,
                payment);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            return student;
    }
}
