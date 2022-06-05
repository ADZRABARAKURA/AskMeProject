using System.ComponentModel.DataAnnotations;

namespace AskMe.Domain.Posts.Entities;

/// <summary>
/// Content that a user can post on their profile.
/// </summary>
public class Publication
{
    /// <summary>
    /// Publication id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Publication title.
    /// </summary>
    [MaxLength(255)]
    [Required]
    public string Title { get; set; }

    /// <summary>
    /// Publication content.
    /// </summary>
    [MaxLength(2000)]
    public string Content { get; set; }

    /// <summary>
    /// Creation date.
    /// </summary>
    [Required]
    public DateTime CreationDate { get; init; }

    /// <summary>
    /// Publication last edition date.
    /// </summary>
    public DateTime? EditDate { get; set; }

    /// <summary>
    /// users with which subscription can view this publication. 
    /// If it costs <c>null</c>, then everyone can view.
    /// </summary>
    public Subscription? Subscription { get; set; }
}
