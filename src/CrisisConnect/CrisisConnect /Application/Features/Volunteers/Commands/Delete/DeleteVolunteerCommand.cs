using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Volunteers.Commands.Delete;

public class DeleteVolunteerCommand: IRequest<DeletedVolunteerResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetVolunteers";
    public Guid Id { get; set; }
    
    public class UpdateVolunteerCommandHandler : IRequestHandler<DeleteVolunteerCommand, DeletedVolunteerResponse>
    {
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IMapper _mapper;

        public UpdateVolunteerCommandHandler(IVolunteerRepository volunteerRepository, IMapper mapper)
        {
            _volunteerRepository = volunteerRepository;
            _mapper = mapper;
        }

        public async Task<DeletedVolunteerResponse> Handle(DeleteVolunteerCommand request,
            CancellationToken cancellationToken)
        {
            Volunteer? volunteer = await _volunteerRepository.GetAsync(predicate: v => v.Id == request.Id, cancellationToken: cancellationToken);
            
            await _volunteerRepository.UpdateAsync(volunteer);
            
            DeletedVolunteerResponse response = _mapper.Map<DeletedVolunteerResponse>(volunteer); 
            return response;
        }
    }
}