using Core.Application.Pipelines.Authorization;
using Domain.ValueObjects;

namespace Application.Features.Users.Commands.Create;

public class CreatedUserResponse
{
    public int Id { get; set; }
    public FullName FullName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }

    public CreatedUserResponse()
    {
        FullName = new FullName(string.Empty, string.Empty);
        Email = string.Empty;
    }

    public CreatedUserResponse(int id, string firstName, string lastName, string email, bool status)
    {
        Id = id;
        FullName = new FullName(firstName, lastName);
        Email = email;
        Status = status;
    }
}