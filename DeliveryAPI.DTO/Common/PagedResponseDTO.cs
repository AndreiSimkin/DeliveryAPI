namespace DeliveryAPI.DTO.Common
{
    public record PagedResponseDTO<T>
    {
        public required IReadOnlyList<T> Items { get; init; }

        /// <summary>
        /// Номер страницы.
        /// </summary>
        public required int PageNumber { get; init; }

        /// <summary>
        /// Размер страницы.
        /// </summary>
        public required int PageSize { get; init; }

        /// <summary>
        /// Общее количество страниц.
        /// </summary>
        public required int PageCount { get; init; }
    }
}
