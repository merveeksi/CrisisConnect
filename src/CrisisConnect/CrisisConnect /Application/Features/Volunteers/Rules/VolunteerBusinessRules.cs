using Application.Features.Volunteers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Volunteers.Rules;

public class VolunteerBusinessRules : BaseBusinessRules
{
    private readonly IVolunteerRepository _volunteerRepository;
    
    public VolunteerBusinessRules(IVolunteerRepository volunteerRepository)
    {
        _volunteerRepository = volunteerRepository;
    }
    
    public async Task IdentityNumberMustBeUnique(string identityNumber)
    {
        var exists = await _volunteerRepository.GetAsync(v => v.IdentityNumber == identityNumber);
        if (exists != null)
            throw new BusinessException(VolunteersMessages.VolunteerExists);
    }

    public async Task CheckVolunteerQualifications(Guid volunteerId, string requiredQualification)
    {
        var volunteer = await _volunteerRepository.GetAsync(v => v.Id == volunteerId);
        if (!volunteer.Qualifications.Contains(requiredQualification))
            throw new BusinessException(VolunteersMessages.VolunteerNotQualificationExists);
    }

    public async Task ValidateWorkHours(Guid volunteerId, DateTime startTime, DateTime endTime)
    {
        // Maksimum çalışma saati kontrolü
        if (!await IsWithinWorkHourLimits(volunteerId, startTime, endTime))
            throw new BusinessException(VolunteersMessages.MaximumWorkingHoursAreExceeded);
        
        // Çakışan görev kontrolü
        if (await HasConflictingAssignment(volunteerId, startTime, endTime))
            throw new BusinessException(VolunteersMessages.VolunteerHasAnotherAssignment);
    }
    
    private async Task<bool> IsWithinWorkHourLimits(Guid volunteerId, DateTime startTime, DateTime endTime)
    {
        // Burada çalışma saatleri kontrolü için gerekli logiği yaz.
        return true;
    }

    private async Task<bool> HasConflictingAssignment(Guid volunteerId, DateTime startTime, DateTime endTime)
    {
        // Burada çakışan görev kontrolü için gerekli logiği yaz.
        return false; 
    }

}