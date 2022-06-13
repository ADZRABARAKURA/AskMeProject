using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMe.Desktop.Dtos;

public record AuthDto
{
    public string Identifier { get; init; }

    public string Password { get; init; }
}
