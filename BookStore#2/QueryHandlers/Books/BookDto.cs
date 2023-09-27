using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryHandlers.Books
{
    public record BookDto
    {
        public long Id { get; init; }
        public required string Title { get; init; }
        public string? Description { get; init; }
        public required int Count { get; init; }
        public required decimal Price { get; init; }
    }
}
