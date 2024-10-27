namespace Domain.Entities;

public class RequestResource
{
        public Guid RequestId { get; set; }
        public Request? Request { get; set; }
    
        public Guid ResourceId { get; set; }
        public Resource? Resource { get; set; }
}