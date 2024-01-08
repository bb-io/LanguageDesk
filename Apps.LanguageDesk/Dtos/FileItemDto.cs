using Newtonsoft.Json;

namespace Apps.LanguageDesk.Dtos;

public class FileItemDto
{
    [JsonProperty("1")]
    public FileContent _1 { get; set; }
}

public class FileContent
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("file")]
    public string File { get; set; }
}