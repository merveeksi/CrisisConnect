using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Logistics.Commands.Create;

public class CreateLogisticCommand : IRequest<CreatedLogisticResponse>
{
    public string Name { get; set; }
    public string Destination { get; set; } 
    public DateTime EstimatedArrival { get; set; }
    public TransportStatus CurrentStatus { get; set; }
    


    public class CreateCommandhandler : IRequestHandler<CreateLogisticCommand, CreatedLogisticResponse>
    {
        private readonly ILogisticRepository _logisticRepository;
        private readonly IMapper _mapper;


        public CreateCommandhandler(ILogisticRepository logisticRepository, IMapper mapper)
        {
            _logisticRepository = logisticRepository;
            _mapper = mapper;
        }

        public async Task<CreatedLogisticResponse>? Handle(CreateLogisticCommand request, CancellationToken cancellationToken)
        {
            Logistic logistic = _mapper.Map<Logistic>(request);
            logistic.Id = Guid.NewGuid();
            
            _logisticRepository.AddAsync(logistic);
            
            CreatedLogisticResponse createdLogisticResponse = _mapper.Map<CreatedLogisticResponse>(logistic);
            return createdLogisticResponse;
        }
    }
}