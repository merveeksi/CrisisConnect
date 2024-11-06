using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Logistics.Commands.Update;

public class UpdateLogisticCommand : IRequest<UpdatedLogisticResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetLogistics";
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public class UpdateLogisticCommandHandler : IRequestHandler<UpdateLogisticCommand, UpdatedLogisticResponse>
    {
        private readonly ILogisticRepository _logisticRepository;
        private readonly IMapper _mapper;

        public UpdateLogisticCommandHandler(ILogisticRepository logisticRepository, IMapper mapper)
        {
            _logisticRepository = logisticRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedLogisticResponse> Handle(UpdateLogisticCommand request,
            CancellationToken cancellationToken)
        {
            Logistic? logistic = await _logisticRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            logistic = _mapper.Map(request, logistic);
            await _logisticRepository.UpdateAsync(logistic); //veritabanına kaydetme işlemi
            UpdatedLogisticResponse
                response = _mapper
                    .Map<UpdatedLogisticResponse>(
                        logistic); //logistic nesnesini UpdatedLogisticResponse nesnesine dönüştürme işlemi
            return response;
        }
    }
}