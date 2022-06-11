using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMe.UseCases.Common.Dtos.Post;

/// <inheritdoc cref="Domain.Posts.Entities.Goal"/>
public record GoalDto
{
    /// <summary>
    /// Goal id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Goal title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Related user id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Goal creation date.
    /// </summary>
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Goal value.
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// Currently earned goal value.
    /// </summary>
    public decimal CurrentValue { get; set; }
}
