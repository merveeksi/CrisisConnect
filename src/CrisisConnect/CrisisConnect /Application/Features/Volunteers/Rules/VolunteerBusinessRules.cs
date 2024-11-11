using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Features.Volunteers.Rules;

public class VolunteerBusinessRules : BaseBusinessRules
{
    private readonly IVolunteerRepository _volunteerRepository;

    public VolunteerBusinessRules(IVolunteerRepository volunteerRepository)
    {
        _volunteerRepository = volunteerRepository;
    }

    public async Task VolunteerEmailCannotBeDuplicatedWhenInserted(string email)
    {
        Volunteer? volunteer = await _volunteerRepository.GetAsync(v => v.Email.Value == email);
        if (volunteer != null)
            throw new BusinessException("Volunteer email already exists.");
    }

    public async Task VolunteerShouldExistWhenSelected(Volunteer? volunteer)
    {
        if (volunteer == null)
            throw new BusinessException("Volunteer not found.");
    }
    
    public async Task IdentityNumberMustBeUnique(string identityNumber)
    {
        Volunteer? volunteer = await _volunteerRepository.GetAsync(v => v.IdentityNumber == identityNumber);
        if (volunteer != null)
            throw new BusinessException("Identity number already exists.");
    }

    public async Task VolunteerIdShouldExistWhenSelected(VolunteerId id)
    {
        Volunteer? volunteer = await _volunteerRepository.GetAsync(v => v.Id.Value == id);
        await VolunteerShouldExistWhenSelected(volunteer);
    }
}