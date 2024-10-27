using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Requests.Commands.Create;

public class CreateRequestCommand : IRequest<CreatedRequestResponse>
{
    public Guid ResourceId { get; set; }
    public Guid VolunteerId { get; set; }
    public PriorityLevel PriorityLevel { get; set; }
    public RequestStatus Status { get; set; }
    public string Location { get; set; }
    public DateTime DateRequested { get; set; }
    

    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, CreatedRequestResponse>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;


        public CreateRequestCommandHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<CreatedRequestResponse> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            Request requestEntity = _mapper.Map<Request>(request);
            requestEntity.Id = Guid.NewGuid();

            await _requestRepository.AddAsync(requestEntity);

            CreatedRequestResponse createdRequestResponse = _mapper.Map<CreatedRequestResponse>(requestEntity);
            return createdRequestResponse;
        }
    }
}