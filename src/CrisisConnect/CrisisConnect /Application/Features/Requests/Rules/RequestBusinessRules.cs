using Application.Features.Requests.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Requests.Rules;

public class RequestBusinessRules : BaseBusinessRules
{
    private readonly IRequestRepository _requestRepository;
    
    public RequestBusinessRules(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }
    
    public async Task RequestNameCannotBeDuplicatedWhenInserted(string name)
    {
        Request? result = await _requestRepository.GetAsync(predicate:r => r.Name.ToLower() == name.ToLower());
        if (result != null)
            throw new BusinessException(RequestsMessages.RequestNameExists);
    }
    
    public async Task CheckRequestCapacity(int currentCapacity, int requestedCapacity)
    {
        if (currentCapacity < requestedCapacity)
            throw new BusinessException(RequestsMessages.RequestCapacityInsufficient);
    }
    
    public async Task ValidateLocation(double latitude, double longitude, string city)
    {
        // Şehir sınırları içinde mi kontrolü
        if (!await IsLocationWithinCityBounds(latitude, longitude, city))
            throw new BusinessException(RequestsMessages.RequestLocationInvalid);
        
        // Yakında başka merkez var mı kontrolü
        if (await IsAnotherRequestNearby(latitude, longitude))
            throw new BusinessException(RequestsMessages.RequestAnotherNearby);
    }
    
    private async Task<bool> IsLocationWithinCityBounds(double latitude, double longitude, string city)
    {
        // Şehir sınırları içinde mi 
        return true;
    }

    private async Task<bool> IsAnotherRequestNearby(double latitude, double longitude)
    {
        // Yakında başka bir merkez var mı 
        return false;
    }
}