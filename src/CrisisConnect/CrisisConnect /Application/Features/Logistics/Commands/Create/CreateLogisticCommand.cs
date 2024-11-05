using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.Logistics.Commands.Create;

public class CreateLogisticCommand : IRequest<CreatedLogisticResponse>
{
    
    public string VehicleType { get; set; }
    public int Capacity { get; set; }
    public string StartLocation { get; set; }
    public string EndLocation { get; set; }
    public DateTime EstimatedArrivalTime { get; set; }
    


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
            
            await _logisticRepository.AddAsync(logistic);
            
            CreatedLogisticResponse createdLogisticResponse = _mapper.Map<CreatedLogisticResponse>(logistic);
            return createdLogisticResponse;
        }
    }
}