using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMe.UseCases.Common.Dtos.Post;

public record PostDto
{
    public int UserId { get; init; }
    public decimal Value { get; init; }
    public string Text { get; init; }
    public string Currency { get; init; }
    public string AuthorName { get; init; }
}
