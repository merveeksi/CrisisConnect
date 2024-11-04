using Application.Features.Centers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Centers.Rules;

public class CenterBusinessRules : BaseBusinessRules
{
        private readonly ICenterRepository _centerRepository;

        public CenterBusinessRules(ICenterRepository centerRepository)
        {
            _centerRepository = centerRepository;
        }
        
        public async Task CenterNameCannotBeDuplicatedWhenInserted(string name)
        {
            Center? result = await _centerRepository.GetAsync(predicate:c => c.Name.ToLower() == name.ToLower());
            if (result != null)
                throw new BusinessException(CentersMessages.CenterNameExists);
        }

        public async Task CheckCenterCapacity(int currentCapacity, int requestedCapacity)
        {
            if (currentCapacity < requestedCapacity)
                throw new BusinessException(CentersMessages.CenterCapacityInsufficient);
        }

        public async Task ValidateLocation(double latitude, double longitude, string city)
        {
            // Şehir sınırları içinde mi kontrolü
            if (!await IsLocationWithinCityBounds(latitude, longitude, city))
                throw new BusinessException(CentersMessages.CenterLocationInvalid);
        
            // Yakında başka merkez var mı kontrolü
            if (await IsAnotherCenterNearby(latitude, longitude))
                throw new BusinessException(CentersMessages.CenterAnotherNearby);
        }
        
        
        private async Task<bool> IsLocationWithinCityBounds(double latitude, double longitude, string city)
        {
            // Burada şehrin sınırlarını kontrol etmek için gerekli mantığı yazabilirim
            // Örneğin:
            // 1. Şehir sınırlarını bir konfigürasyon dosyasından okuyabilirim
            // 2. Harici bir servis kullanabilirim (Google Maps gibi)
            // 3. Veritabanında tanımlı sınırları kontrol edebilirim...
    
            // Örnek bir kontrol:
            switch (city.ToLower())
            {
                case "istanbul":
                    return latitude >= 40.8 && latitude <= 41.6 
                                            && longitude >= 28.2 && longitude <= 29.9;
                case "ankara":
                    return latitude >= 39.7 && latitude <= 40.2 
                                            && longitude >= 32.5 && longitude <= 33.5;
                // Diğer şehirler için benzer kontroller...
                default:
                    return false;
            }
        }

        private async Task<bool> IsAnotherCenterNearby(double latitude, double longitude)
        {
            // Merkezler arası mesafeyi kontrol etmek için gerekli mantığı yazabilirim
            // Örneğin:
            // 1. Veritabanındaki merkezlerin konumlarını okuyabilirim
            // 2. Harici bir servis kullanabilirim (Google Maps gibi)
            // 3. Merkezlerin konumlarını bir konfigürasyon dosyasından okuyabilirim...
    
            // Örnek bir kontrol:
            List<Center> centers = await _centerRepository.GetAllAsync();
            foreach (var center in centers)
            {
                if (CalculateDistance(center.Latitude, center.Longitude, latitude, longitude) < 5) // 5 km'den yakın merkez varsa
                    return true;
            }
            return false;
        }
        

// Mesafe hesaplama yardımcı metodu (Haversine formülü)
        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371; // Dünya yarıçapı km
            var dLat = ToRad(lat2 - lat1);
            var dLon = ToRad(lon2 - lon1);
    
            var a = Math.Sin(dLat/2) * Math.Sin(dLat/2) +
                    Math.Cos(ToRad(lat1)) * Math.Cos(ToRad(lat2)) *
                    Math.Sin(dLon/2) * Math.Sin(dLon/2);
            
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
            return R * c;
        }

        private double ToRad(double degree)
        {
            return degree * (Math.PI / 180);
        }
    }