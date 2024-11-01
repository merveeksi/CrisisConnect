namespace Domain.Enums;

public enum RequestStatus
{
    Pending=1,
    Verified=2,
    Assigned=3,
    InProgress=4,
    PartiallyFulfilled=5,
    Fulfilled=6,
    Cancelled=7,
    Rejected=8
}