using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMe.Desktop.Dtos;

public record AuthUserDto
{
    public Guid Id { get; init; }

    public TokenDto Token { get; init; }
}
