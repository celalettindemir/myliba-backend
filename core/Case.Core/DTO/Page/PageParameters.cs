using System.Text.Json.Serialization;

namespace Case.Core.DTO.Page;

public class PageParameters
{
    const int maxPageSize = 50;
    [JsonPropertyName("page")]
    private int _page { get; set; } = 0;
    private int _pageSize = 10;
    [JsonPropertyName("page")]
    public int page
    {
        get
        {
            return _page;
        }
        set
        {
            _page = value-1;
        }
    }
    [JsonPropertyName("size")]
    public int size
    {
        get
        {
            return _pageSize;
        }
        set
        {
            _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}