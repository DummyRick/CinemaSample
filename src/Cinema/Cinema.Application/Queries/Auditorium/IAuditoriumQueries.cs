﻿using Cinema.Application.Queries.Auditorium.Models;

namespace Cinema.Application.Queries.Auditorium
{
    public interface IAuditoriumQueries
    {
        Task<IEnumerable<AuditoriumReadModel>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<AuditoriumReadModel?> GetSingleAsync(int id, CancellationToken cancellationToken = default);
    }
}