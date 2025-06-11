using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAPI.DTO.Common
{
    public record OrderStatusInfoDTO
    {
        public required int Id { get; init; }

        public required string Name { get; init; }

        public required string DisplayName { get; init; }
    }
}
