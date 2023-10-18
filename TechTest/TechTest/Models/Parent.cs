using System.Text.Json.Serialization;

namespace TechTest.Models;

public class Parent
{
    public string Sha { get; set; }
    public string Url { get; set; }

    [JsonPropertyName("HTML_URL")]
    public string HtmlUrl { get; set; }
}