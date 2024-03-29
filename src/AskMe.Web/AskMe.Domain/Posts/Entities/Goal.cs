﻿using System.ComponentModel.DataAnnotations;

namespace AskMe.Domain.Posts.Entities;

/// <summary>
/// Fundraising for the described purpose.
/// </summary>
public class Goal
{
    /// <summary>
    /// Goal id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Related user Id.
    /// </summary>
    public Guid UserId { get; init; }

    /// <summary>
    /// Goal title.
    /// </summary>
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// Goal creation date.
    /// </summary>
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Goal value.
    /// </summary>
    [Range(0, 10000000)]
    [Required]
    public decimal Value { get; set; }

    /// <summary>
    /// Currently earned goal value.
    /// </summary>
    [Range(0, 10000000)]
    public decimal CurrentValue { get; set; }
}
