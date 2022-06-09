using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMe.UseCases.Common.Dtos.Post;

/// <summary>
/// Update publication DTO.
/// </summary>
public record UpdatePublicationDto
{
    /// <summary>
    /// Publication id.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Publication header.
    /// </summary>
    public string Header { get; init; }

    /// <summary>
    /// Publication content.
    /// </summary>
    public string Content { get;  init; }

    /// <summary>
    /// Id of subscription related to Publication. 
    /// </summary>
    public Guid? SubscriptionId { get; init; }
}
