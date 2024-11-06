using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Logistics.Commands.Delete;

public class DeleteLogisticCommand: IRequest<DeletedLogisticResponse>, ICacheRemoverRequest
{
    public string? CacheKey => "";
    public bool BypassCache => false;
    public string? CacheGroupKey => "GetLogistics";
    public Guid Id { get; set; }
    
    public class UpdateLogisticCommandHandler : IRequestHandler<DeleteLogisticCommand, DeletedLogisticResponse>
    {
        private readonly ILogisticRepository _logisticRepository;
        private readonly IMapper _mapper;

        public UpdateLogisticCommandHandler(ILogisticRepository logisticRepository, IMapper mapper)
        {
            _logisticRepository = logisticRepository;
            _mapper = mapper;
        }

        public async Task<DeletedLogisticResponse> Handle(DeleteLogisticCommand request,
            CancellationToken cancellationToken)
        {
            Logistic? logistic = await _logisticRepository.GetAsync(predicate: l => l.Id == request.Id, cancellationToken: cancellationToken);
            
            await _logisticRepository.UpdateAsync(logistic);
            
            DeletedLogisticResponse response = _mapper.Map<DeletedLogisticResponse>(logistic); 
            return response;
        }
    }
}