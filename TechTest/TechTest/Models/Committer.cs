﻿using System.Text.Json.Serialization;

namespace TechTest.Models;

public class Committer
{
    public string Name { get; set; }
    public string Email { get; set; }

    [JsonPropertyName("Date")]
    public DateTime Date { get; set; }
}