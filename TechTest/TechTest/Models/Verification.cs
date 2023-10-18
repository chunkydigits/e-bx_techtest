using Newtonsoft.Json;

namespace TechTest.Models;

public class Verification
{
    [JsonProperty("Verified")]
    public bool Verified { get; set; }

    [JsonProperty("Reason")]
    public string Reason { get; set; }

    [JsonProperty("Signature")]
    public object Signature { get; set; }  

    [JsonProperty("Payload")]
    public object Payload { get; set; }    
}