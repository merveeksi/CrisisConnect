using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Alerts.Commands.Delete;

public class DeleteAlertCommand: IRequest<DeletedAlertResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetAlerts";
    public Guid Id { get; set; }
    
    public class UpdateAlertCommandHandler : IRequestHandler<DeleteAlertCommand, DeletedAlertResponse>
    {
        private readonly IAlertRepository _alertRepository;
        private readonly IMapper _mapper;

        public UpdateAlertCommandHandler(IAlertRepository alertRepository, IMapper mapper)
        {
            _alertRepository = alertRepository;
            _mapper = mapper;
        }

        public async Task<DeletedAlertResponse> Handle(DeleteAlertCommand request,
            CancellationToken cancellationToken)
        {
            Alert? alert = await _alertRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            
            await _alertRepository.UpdateAsync(alert);
            
            DeletedAlertResponse response = _mapper.Map<DeletedAlertResponse>(alert); 
            return response;
        }
    }
}