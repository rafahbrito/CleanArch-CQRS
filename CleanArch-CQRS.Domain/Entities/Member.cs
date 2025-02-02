
using CleanArch_CQRS.Domain.Validation;

namespace CleanArch_CQRS.Domain.Entities;
public sealed class Member : Entity
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Gender { get; private set; }
    public string? Email { get; private set; }
    public bool? IsActive { get; private set; }

    public Member(string firstName, string lastName, string gender, string email, bool? active)
    {
        Validate(firstName, lastName, gender, email, active);
    }

    public Member(int id, string firstName, string lastName, string gender, string email, bool? active)
    {
        DomainValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        Validate(firstName, lastName, gender, email, active);
    }

    public void Update(string firstName, string lastName, string gender, string email, bool? active)
    {
        Validate(firstName, lastName, gender, email, active);
    }

    private void Validate(string firstName, string lastName, string gender, string email, bool? active)
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(firstName), "FirstName is required.");
        DomainValidation.When(firstName.Length < 3, "Invalid FirstName, too short, minimum 3 characters.");
        DomainValidation.When(string.IsNullOrWhiteSpace(lastName), "LastName is required.");
        DomainValidation.When(lastName.Length < 3, "Invalid LastName, too short, minimum 3 characters.");
        DomainValidation.When(string.IsNullOrWhiteSpace(email), "Email is required.");
        DomainValidation.When(email.Length > 250, "Invalid Email, too long, maximum 250 characters.");
        DomainValidation.When(email.Length < 6, "Invalid Email, too short, minimum 6 characters.");
        DomainValidation.When(string.IsNullOrWhiteSpace(gender), "Gender is required.");
        DomainValidation.When(!active.HasValue, "Must define activity.");

        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Email = email;
        IsActive = active;
    }
}
