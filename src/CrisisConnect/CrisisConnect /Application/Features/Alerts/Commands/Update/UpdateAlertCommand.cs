using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using Domain.ValueObjects;
using MediatR;

namespace Application.Features.Alerts.Commands.Update;

public class UpdateAlertCommand : IRequest<UpdatedAlertResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetAlerts";
    public AlertId Id { get; set; }
    
    public string Name { get; set; }

    public class UpdateAlertCommandHandler : IRequestHandler<UpdateAlertCommand, UpdatedAlertResponse>
    {
        private readonly IAlertRepository _alertRepository;
        private readonly IMapper _mapper;

        public UpdateAlertCommandHandler(IAlertRepository alertRepository, IMapper mapper)
        {
            _alertRepository = alertRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedAlertResponse> Handle(UpdateAlertCommand request,
            CancellationToken cancellationToken)
        {
            Alert? alert = await _alertRepository.GetAsync(predicate: a => a.Id == request.Id, cancellationToken: cancellationToken);
            alert = _mapper.Map(request, alert);
            await _alertRepository.UpdateAsync(alert); //veritabanına kaydetme işlemi
            UpdatedAlertResponse
                response = _mapper
                    .Map<UpdatedAlertResponse>(
                        alert); //alert nesnesini UpdatedAlertResponse nesnesine dönüştürme işlemi
            return response;
        }
    }
}