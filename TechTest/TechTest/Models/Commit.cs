namespace TechTest.Models;

using System.Text.Json.Serialization;
using System.Collections.Generic;

public class Commit
{
    [JsonPropertyName("SHA")]
    public string Sha { get; set; }

    [JsonPropertyName("Node_ID")]
    public string NodeId { get; set; }

    [JsonPropertyName("Commit")]
    public CommitDetails CommitDetails { get; set; }

    public string Url { get; set; }

    [JsonPropertyName("HTML_URL")]
    public string HtmlUrl { get; set; }

    [JsonPropertyName("Comments_URL")]
    public string CommentsUrl { get; set; }

    public Author Author { get; set; }
    public Committer Committer { get; set; }
    public List<Parent> Parents { get; set; }
}