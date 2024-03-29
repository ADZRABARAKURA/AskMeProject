﻿namespace AskMe.Domain.Posts.Entities;

public class Post
{
    /// <summary>
    /// Post ID.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// User who recieve this post ID.
    /// </summary>
    public Guid RecieverId { get; init; }

    /// <summary>
    /// User who recieve this post name.
    /// </summary>
    public string RecieverName { get; init; }

    /// <summary>
    /// Value of post(Money).
    /// </summary>
    public decimal Value { get; init; }

    /// <summary>
    /// Currency of value.
    /// </summary>
    public string Currency { get; init; }

    /// <summary>
    /// Date when post value was paid to streamer.
    /// </summary>
    public DateTime? PaidDate { get; set; }

    /// <summary>
    /// Date of post. 
    /// </summary>
    public DateTime SentDate { get; init; }

    /// <summary>
    /// Post text.
    /// </summary>
    public string? Text { get; init; }

    /// <summary>
    /// Author username.
    /// </summary>
    public string AuthorName { get; init; }

    /// <summary>
    /// ID of post author.
    /// </summary>
    public Guid? AuthorId { get; init; }
}
