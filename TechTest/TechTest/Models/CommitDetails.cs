using System.Text.Json.Serialization;

namespace TechTest.Models;

public class CommitDetails
{
    public Author Author { get; set; }
    public Committer Committer { get; set; }
    public DateTime Date { get; set; }

    [JsonPropertyName("Message")]
    public string Message { get; set; }

    public Tree Tree { get; set; }

    [JsonPropertyName("Comment_Count")]
    public int CommentCount { get; set; }

    public Verification Verification { get; set; }
}