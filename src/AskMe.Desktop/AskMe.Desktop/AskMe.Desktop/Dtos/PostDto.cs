using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMe.Desktop.Dtos;

public record PostDto
{
    public string Currency { get; init; }

    public decimal Value { get; init; }

    public string Author { get; init; }

    public DateTime CreationDate { get; init; }
}
