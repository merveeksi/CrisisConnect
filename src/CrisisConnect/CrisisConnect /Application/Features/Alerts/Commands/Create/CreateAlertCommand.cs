using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Alerts.Commands.Create;

public class CreateAlertCommand:IRequest<CreatedAlertResponse>, ITransactionalRequest, ICacheRemoverRequest, ILoggableRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetAlerts";
    
    public string Name { get; set; }
    public string Description { get; set; }
    public int Type { get; set; }
    public int Severity { get; set; }
    public Address Address { get; set; }
    public AlertStatus Status { get; set; }
    public string Instructions { get; set; }
}

public class CreateAlertCommandHandler : IRequestHandler<CreateAlertCommand, CreatedAlertResponse>
{
    private readonly IAlertRepository _alertRepository;
    private readonly IMapper _mapper;

    public CreateAlertCommandHandler(IAlertRepository alertRepository, IMapper mapper)
    {
        _alertRepository = alertRepository;
        _mapper = mapper;
    }

    public async Task<CreatedAlertResponse>? Handle(CreateAlertCommand request, CancellationToken cancellationToken)
    {
        Alert alert = _mapper.Map<Alert>(request);
        alert.Id = Guid.NewGuid();
        
        await _alertRepository.AddAsync(alert);
        
        CreatedAlertResponse createdAlertResponse = _mapper.Map<CreatedAlertResponse>(alert);
        return createdAlertResponse;
    }
}