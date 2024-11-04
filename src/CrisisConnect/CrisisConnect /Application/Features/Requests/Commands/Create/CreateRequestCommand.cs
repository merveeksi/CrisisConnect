using Application.Features.Requests.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Requests.Commands.Create;

public class CreateRequestCommand : IRequest<CreatedRequestResponse>
{ 
    public string Name { get; set; }
    public PriorityLevel PriorityLevel { get; set; }
    public RequestStatus Status { get; set; }
    public string Location { get; set; }
    public DateTime DateRequested { get; set; }
    

    public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, CreatedRequestResponse>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        private readonly RequestBusinessRules _requestBusinessRules;


        public CreateRequestCommandHandler(IRequestRepository requestRepository, IMapper mapper, RequestBusinessRules requestBusinessRules)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
            _requestBusinessRules = requestBusinessRules;
        }
        public async Task<CreatedRequestResponse> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {
            await _requestBusinessRules.RequestNameCannotBeDuplicatedWhenInserted(request.Name);
            
            Request requestEntity = _mapper.Map<Request>(request);
            requestEntity.Id = Guid.NewGuid();

            await _requestRepository.AddAsync(requestEntity);

            CreatedRequestResponse createdRequestResponse = _mapper.Map<CreatedRequestResponse>(requestEntity);
            return createdRequestResponse;
        }
    }
}