using System.Text.Json.Serialization;

namespace Case.Core.DTO.Page;

public class PageResponse<T> where T : class
{
    [JsonPropertyName("data")]
    public virtual List<T> data { get; set; }
    [JsonPropertyName("totalItems")]
    public virtual int totalItems { get; set; }
}