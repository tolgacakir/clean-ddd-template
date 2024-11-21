namespace Domain.Aggregates.Transfers;

public enum TransferStatus
{
    None = 0,
    Created = 1,
    Scheduled = 2,
    Initiated = 3,
    Completed = 4,
    Failed = 5,
    Canceled = 6,
}