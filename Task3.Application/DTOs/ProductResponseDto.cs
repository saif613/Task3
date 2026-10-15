using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Application.DTOs
{
    public record ProductResponseDto(
    int Id,
    string Name,
    decimal? Price
);
}
