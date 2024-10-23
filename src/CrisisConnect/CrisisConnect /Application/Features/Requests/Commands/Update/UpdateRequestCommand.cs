using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Requests.Commands.Update;

public class UpdateRequestCommand : IRequest<UpdatedRequestResponse>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public class UpdateRequestCommandHandler : IRequestHandler<UpdateRequestCommand, UpdatedRequestResponse>
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public UpdateRequestCommandHandler(IRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedRequestResponse> Handle(UpdateRequestCommand request,
            CancellationToken cancellationToken)
        {
            Request? requestEntity = await _requestRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            requestEntity = _mapper.Map(request, requestEntity);
            await _requestRepository.UpdateAsync(requestEntity); //veritabanına kaydetme işlemi
            UpdatedRequestResponse
                response = _mapper
                    .Map<UpdatedRequestResponse>(
                        requestEntity); //request nesnesini UpdatedRequestResponse nesnesine dönüştürme işlemi
            return response;
        }
    }
}