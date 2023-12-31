﻿namespace ShopCenter.Domain.SeedOfWork;

public interface IUnitOfWork
{
    ITripRepository TripRepository { get; }
    IDelayReportRepository DelayReportRepository { get; }
    IDelayQueueRepository DelayQueueRepository { get; }
    IOrderRepository OrderRepository { get; }
    IAgentRepository AgentRepository { get; }
}
