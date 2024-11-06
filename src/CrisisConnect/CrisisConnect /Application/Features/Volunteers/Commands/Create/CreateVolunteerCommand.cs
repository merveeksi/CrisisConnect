using Application.Features.Volunteers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.Volunteers.Commands.Create;

public class CreateVolunteerCommand : IRequest<CreatedVolunteerResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetVolunteers";

    public string FirstName { get; set; }
    public string Lastname { get; set; }
    public List<string> Skills { get; set; } 
    public string Location { get; set; }
    public decimal PhoneNumber { get; set; }
    public string IdentityNumber { get; set; }
    
    
    public class CreateVolunteerCommandHandler : IRequestHandler<CreateVolunteerCommand, CreatedVolunteerResponse>
    {
        private readonly IVolunteerRepository  _volunteerRepository;
        private readonly IMapper _mapper;
        private readonly VolunteerBusinessRules _volunteerBusinessRules;
        
        public CreateVolunteerCommandHandler(IMapper mapper, IVolunteerRepository volunteerRepository, VolunteerBusinessRules volunteerBusinessRules)
        {
            _volunteerRepository = volunteerRepository;
            _mapper = mapper;
            _volunteerBusinessRules = volunteerBusinessRules;
        }

        public async Task<CreatedVolunteerResponse> Handle(CreateVolunteerCommand request, CancellationToken cancellationToken)
        {
            await _volunteerBusinessRules.IdentityNumberMustBeUnique(request.IdentityNumber);
            
            Volunteer volunteer = _mapper.Map<Volunteer>(request);
            volunteer.Id = Guid.NewGuid();
            
            await _volunteerRepository.AddAsync(volunteer);
            
            CreatedVolunteerResponse createdVolunteerResponse = _mapper.Map<CreatedVolunteerResponse>(volunteer);
            return createdVolunteerResponse;
        }
    }
}