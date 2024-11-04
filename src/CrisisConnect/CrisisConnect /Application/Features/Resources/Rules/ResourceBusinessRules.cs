using Application.Features.Resources.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Enums;

namespace Application.Features.Resources.Rules;

public class ResourceBusinessRules : BaseBusinessRules
{
    private readonly IResourceRepository _resourceRepository;
    private readonly ICenterRepository _centerRepository;

    public ResourceBusinessRules(IResourceRepository resourceRepository, ICenterRepository centerRepository)
    {
        _resourceRepository = resourceRepository;
        _centerRepository = centerRepository;
    }
    public async Task CheckResourceAvailability(Guid resourceId, int requestedQuantity)
    {
        var resource = await _resourceRepository.GetAsync(r => r.Id == resourceId);
        if (resource == null)
            throw new BusinessException(ResourcesMessages.ResourceNotFound);

        if (resource.AvailableQuantity < requestedQuantity)
            throw new BusinessException(ResourcesMessages.EnoughResourcesNotAvailable);

        if (resource.IsReserved)
            throw new BusinessException(ResourcesMessages.ResourceReserved);
    }

    public async Task ValidateResourceAllocation(Guid resourceId, Guid centerId)
    {
        // Merkezin bu kaynağı alabilme yetkisi var mı?
        if (!await CanCenterAllocateResource(centerId, resourceId))
            throw new BusinessException(ResourcesMessages.ResourceNotTransferable);
        
        // Kaynak transfer edilebilir durumda mı?
        if (!await IsResourceTransferable(resourceId))
            throw new BusinessException(ResourcesMessages.ResourceNowNotTransferable);
    }

    public async Task CheckMinimumStockLevel(Guid resourceId, int quantityToRemove)
    {
        var resource = await _resourceRepository.GetAsync(r => r.Id == resourceId);
        if (resource.AvailableQuantity - quantityToRemove < resource.MinimumStockLevel)
            throw new BusinessException(ResourcesMessages.MinimumStockLevelViolation);
    }
    
    private async Task<bool> CanCenterAllocateResource(Guid centerId, Guid resourceId) 
    {
    // Merkezin kaynak tahsis yetkisini kontrol et
    var center = await _centerRepository.GetAsync(c => c.Id == centerId);
    if (center == null)
        return false;

    // Örnek kontroller:
    // 1. Merkezin aktif olup olmadığı
    if (!center.IsActive)
        return false;

    // 2. Merkezin kaynak tipi için yetkisi
    var resource = await _resourceRepository.GetAsync(r => r.Id == resourceId);
    if (resource == null)
        return false;

    // 3. Merkez tipine göre kaynak tahsis yetkisi kontrolü
    // Örneğin: Ana merkezler her kaynağı tahsis edebilir
    if (center.Type == CenterType.MainCenter)
        return true;
    
    return true; 
    }
    
    private async Task<bool> IsResourceTransferable(Guid resourceId)
    {
        var resource = await _resourceRepository.GetAsync(r => r.Id == resourceId);
        if (resource == null)
            return false;

        // Örnek transfer edilebilirlik kontrolleri:
        
        // 1. Kaynak aktif mi?
        if (!resource.IsActive)
            return false;

        // 2. Kaynak transfer için uygun durumda mı?
        if (resource.Status != ResourceStatus.Available)
            return false;

        // 3. Kaynağın transfer kısıtlaması var mı?
        if (resource.HasTransferRestriction)
            return false;

        // 4. Kaynak bozulabilir/son kullanma tarihli mi?
        if (resource.IsPerishable && resource.ExpirationDate <= DateTime.Now)
            return false;

        // 5. Hava durumu koşulları transfer için uygun mu?
        // Örnek: Soğuk zincir gerektiren kaynaklar için sıcaklık kontrolü
        if (resource.RequiresColdChain && !await IsWeatherSuitableForTransfer())
            return false;

        return true;
    }

    // Yardımcı metod - ihtiyaca göre eklenebilir
    private async Task<bool> IsWeatherSuitableForTransfer()
    {
        // Hava durumu kontrolü için harici servis kullanımı
        // Şimdilik örnek olarak true dönüyoruz
        return true;
    }
}