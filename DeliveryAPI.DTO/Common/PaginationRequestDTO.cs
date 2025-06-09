using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.DTO.Common
{
    public record PaginationRequestDTO
    {
        [Range(1, int.MaxValue)]
        public int PageSize { get; init; }

        [Range(1, int.MaxValue)]
        public int PageNumber { get; init; }

        [MaxLength(200)]
        public string? Filter { get; init; }
    }
}
