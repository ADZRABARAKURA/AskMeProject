using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace AskMe.Web.Web;

public class SystemTextJsonHelper : IJsonHelper
{
    private readonly JsonSerializerOptions htmlSafeJsonSerializerOptions;

    public SystemTextJsonHelper(IOptions<JsonOptions> options)
    {
        htmlSafeJsonSerializerOptions = GetHtmlSafeSerializerOptions(options.Value.SerializerOptions);
    }

    public static string GetAssemblyLocationByType(Type type) =>
            Path.Combine(AppContext.BaseDirectory, $"{type.Assembly.GetName().Name}.xml");

    public IHtmlContent Serialize(object value)
    {
        var json = JsonSerializer.Serialize(value, htmlSafeJsonSerializerOptions);
        return new HtmlString(json);
    }

    private static JsonSerializerOptions GetHtmlSafeSerializerOptions(JsonSerializerOptions serializerOptions)
    {
        if (serializerOptions.Encoder is null || serializerOptions.Encoder == JavaScriptEncoder.Default)
        {
            return serializerOptions;
        }

        return new JsonSerializerOptions(serializerOptions)
        {
            Encoder = JavaScriptEncoder.Default,
        };
    }
}
