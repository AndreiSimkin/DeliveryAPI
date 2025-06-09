﻿namespace DeliveryAPI.Common.Models
{
    public class PagedResult<T>
    {
        public required IReadOnlyList<T> Items { get; init; }

        public required int PageNumber { get; init; }

        public required int PageSize { get; init; }

        public required int PageCount { get; init; }
    }
}
